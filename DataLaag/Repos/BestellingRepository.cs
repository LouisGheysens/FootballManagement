using BusinessLogic;
using BusinessLogic.Exceptions;
using BusinessLogic.Interface;
using BusinessLogic.Model;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLaag.Repos {
    public class BestellingRepository : IBestellingRepository {

        public bool BestaatBestelling(Bestelling bestelling) {
            SqlConnection conn = DbConnection.CreateConnection();
            string query = "SELECT COUNT(1) FROM bestellingen WHERE Id = @Id";
            using (SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    bool result = false;
                    cmd.CommandText = query;
                    cmd.Parameters.Add(new SqlParameter("@Id", System.Data.SqlDbType.Int));
                    cmd.Parameters["@Id"].Value = bestelling.BestelNummer;

                    Console.WriteLine();
                    result = (int)cmd.ExecuteScalar() == 1 ? true : false;
                    return result;
                }
                catch (Exception ex) {
                    throw new BestellingRepositoryADOException("BestellingRepository: BestaatBestelling - gefaald!", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        public bool BestaatBestelling(int id) {
            SqlConnection conn = DbConnection.CreateConnection();
            string query = "SELECT COUNT(1) FROM [Football].[dbo].[bestellingen] WHERE id = @id";
            using (SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    bool result = false;
                    cmd.CommandText = query;
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int));
                    cmd.Parameters["@id"].Value = id;

                    Console.WriteLine();
                    result = (int)cmd.ExecuteScalar() == 1 ? true : false;
                    return result;
                }
                catch (Exception ex) {
                    throw new BestellingRepositoryADOException("BestellingRepository: BestaatBestelling - gefaald!", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }


        public Bestelling GeefBestelling(int id) {
            SqlConnection conn = DbConnection.CreateConnection();
            string sql = "SELECT * FROM klant k INNER JOIN bestellingen  b  ON k.Id = b.id WHERE k.Id = @id";
            Klant k = null;
            using (SqlCommand cmd = new(sql, conn)) {
                try {
                    conn.Open();
                    cmd.Parameters.Add("@Id", SqlDbType.Int);
                    cmd.Parameters["@Id"].Value = id;
                    IDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    if (k == null) {
                        k = new Klant((int)reader["Id"], (string)reader["Naam"], (string)reader["Adres"]);
                    }
                    Bestelling b = new Bestelling((int)reader["Id"], k, (DateTime)reader["datum"], (double)reader["prijs"],
                        (bool)reader["betaald"], (Dictionary<Trui, int>)reader["producten"]);
                    reader.Close();
                    return b;
                }
                catch (Exception ex) {
                    throw new KlantRepositoryADOException("BestellingRepository: GeefBestellingWeer(id) - gefaald", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }




        public void UpdateBestelling(Bestelling bestelling) {
            var producten = bestelling.GeefProducten();
            string sqlOne = "UPDATE [dbo].[Bestellingen] SET Verkoopprijs = @Verkoopprijs, Betaald = @Betaald, KlantID = @KlantID WHERE Id = @Id";
            string sqlTwo = "INSERT INTO [dbo].[BestellingTruitje] (BestellingID, TruitjeID, Aantal) VALUES (@BestellingID, @TruitjeID, @Aantal)";
            string sqlThree = "DELETE FROM [dbo].[BestellingTruitje] WHERE BestellingID = @BestellingID";
            SqlConnection connection = DbConnection.CreateConnection();
            SqlCommand command = new(sqlOne, connection);
            SqlCommand command3 = new(sqlThree, connection);
            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();
            command.Transaction = transaction;
            command3.Transaction = transaction;
            try {
                command.Parameters.AddWithValue("@Verkoopprijs", bestelling.Prijs);
                command.Parameters.AddWithValue("@Betaald", bestelling.Betaald);
                command.Parameters.AddWithValue("@KlantID", bestelling.Klant.KlantenNummer);
                command.Parameters.AddWithValue("@Id", bestelling.BestelNummer);
                command.ExecuteNonQuery();
                command3.Parameters.AddWithValue("@BestellingID", bestelling.BestelNummer);
                command3.ExecuteNonQuery();

                foreach (var voetbaltruitje in producten) {
                    SqlCommand command2 = new(sqlTwo, connection);
                    command2.Transaction = transaction;
                    command2.Parameters.AddWithValue("@BestellingID", bestelling.BestelNummer);
                    command2.Parameters.AddWithValue("@TruitjeID", voetbaltruitje.Key.Id);
                    command2.Parameters.AddWithValue("@Aantal", voetbaltruitje.Value);
                    command2.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch (Exception ex) {
                transaction.Rollback();
                throw new BestellingRepositoryADOException("BestellingUpdaten - error", ex);
            }
            finally {
                connection.Close();
            }


        }

        public void VerwijderBestelling(Bestelling bestelling) {
            string queryOne = "DELETE FROM Bestellingtruitje WHERE bestellingid = @bestellingid";
            string queryTwo = "DELETE FROM bestellingen WHERE id = @bestellingid";
            SqlConnection conn = DbConnection.CreateConnection();
            using SqlCommand cmdOne = new(queryOne, conn);
            using SqlCommand cmdTwo = new(queryTwo, conn);
            SqlTransaction sqltransaction = conn.BeginTransaction();
            try {
                conn.Open();

                cmdOne.Parameters.AddWithValue("@bestellingid", bestelling.BestelNummer);
                cmdOne.ExecuteNonQuery();

                cmdTwo.Parameters.AddWithValue("@bestellingid", bestelling.BestelNummer);
                cmdTwo.ExecuteNonQuery();
                sqltransaction.Commit();

            }catch(Exception ex) {
                sqltransaction.Rollback();
                throw new BestellingRepositoryADOException("BestellingRepository: VerwijderBestelling - gefaald", ex);
            }
            finally {
                conn.Close();
            }
        }

        public void VoegBestellingToe(Bestelling bestelling) {
            int bestelId;
            var producten = bestelling.GeefProducten();
            SqlConnection conn = DbConnection.CreateConnection();
            string sql = "INSERT INTO bestellingen (Datum, Verkoopprijs, Betaald, klantID) " +
            "VALUES (@Datum, @Verkoopprijs, @Betaald, @klantID) SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new(sql, conn);
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            try {
                cmd.Transaction = trans;
                cmd.Parameters.AddWithValue("@Datum", bestelling.OrderDatum);
                cmd.Parameters.AddWithValue("@Verkoopprijs", bestelling.Prijs);
                cmd.Parameters.AddWithValue("@Betaald", bestelling.Betaald);
                cmd.Parameters.AddWithValue("@klantID", bestelling.Klant.KlantenNummer);
                bestelId = Decimal.ToInt32((decimal)cmd.ExecuteScalar());

                foreach(var product in producten) {
                    string sqlTwo = "INSERT INTO Bestellingtruitje (BestellingID, TruitjeID, Aantal) VALUES (@BestellingID, @TruitjeID, @Aantal)";
                    SqlCommand cmdTwo = new(sqlTwo, conn);
                    cmdTwo.Transaction = trans;
                    cmdTwo.Parameters.AddWithValue("@BestellingID", bestelId);
                    cmdTwo.Parameters.AddWithValue("@TruitjeID", product.Key.Id);
                    cmdTwo.Parameters.AddWithValue("@Aantal", product.Value);
                    cmdTwo.ExecuteNonQuery();
                }
                trans.Commit();
            }
            catch (Exception ex) {
                trans.Rollback();
                throw new BestellingRepositoryADOException("BestellingRepository: VoegBestellingToe - gefaald!", ex);
            }
            finally {
                conn.Close();
            }
        }

        public IReadOnlyList<Bestelling> ZoekBestellingen(int? bestellingid, DateTime? startDatum, DateTime? einddatum, Klant k) {
            List<Bestelling> bestellingen = new List<Bestelling>();
            bool isWhere = true;
            bool isAnd = false;
            string sql = "SELECT b.*, k.id AS KlantID, k.naam, k.adres FROM bestellingen b INNER JOIN " +
                "klant k ON b.KlantID = k.id";

            if(bestellingid != 0) {
                if (isWhere) {
                    sql += " WHERE ";
                    isWhere = false;
                }
                if (isAnd) {
                    sql += " AND ";
                }
                else {
                    isAnd = true;
                }
                sql += "b.id = @id";
            }

            if(startDatum != null) {
                if (isWhere) {
                    sql += " WHERE ";
                    isWhere = false;
                }
                if (isAnd) {
                    sql += " AND ";
                }
                else {
                    isAnd = true;
                }
                sql += "b.datum >= @Start";
            }

            if(einddatum != null) {
                if (isWhere) {
                    sql += " WHERE ";
                    isWhere = false;
                }
                if (isAnd) {
                    sql += " AND ";
                }
                else {
                    isAnd = true;
                }
                sql += "b.datum <= @Einde";
            }

            if(k != null) {
                if (isWhere) {
                    sql += " WHERE ";
                    isWhere = false;
                }
                if (isAnd) {
                    sql += " AND ";
                }
                else {
                    isAnd = true;
                }
                sql += "b.klantid = @KlantID";
            }
            SqlConnection conn = DbConnection.CreateConnection();
            SqlCommand cmd = new(sql, conn);
            try {
                conn.Open();

                if(bestellingid != 0) {
                    cmd.Parameters.AddWithValue("@Id", bestellingid);
                }

                if(startDatum != null) {
                    cmd.Parameters.AddWithValue("@start", startDatum);
                }

                if(einddatum != null) {
                    cmd.Parameters.AddWithValue("@einde", einddatum);
                }

                if(k != null) {
                    cmd.Parameters.AddWithValue("@KlantID", k.KlantenNummer);
                }
                IDataReader data = cmd.ExecuteReader();
                while (data.Read()) {
                    Klant klant = new((int)data["KlantID"], (string)data["Naam"], (string)data["Adres"]);
                    int bestelId = (int)data["Id"];
                    Bestelling bestelling = new(bestelId, klant, (DateTime)data["Datum"], (double)data["Verkoopprijs"],
                        (bool)data["Betaald"], GetInhoudBestelling(bestelId));
                    bestelling.ZetBestellingId(bestelId);
                    bestellingen.Add(bestelling);
                }
                return bestellingen;

            }catch(Exception ex) {
                throw new BestellingRepositoryADOException("BestellingRepository: zoekBestellingen - gefaald", ex);
            }
            finally {
                conn.Close();
            }
        }

        public Dictionary<Trui, int> GetInhoudBestelling(int id) {
            Dictionary<Trui, int> producten = new();
            string sql = "SELECT bt.Id AS BTId, bt.BestellingID, bt.TruitjeID, " +
                "bt.Aantal, t.* FROM[dbo].[BestellingTruitje] bt " +
                "INNER JOIN [dbo].[truitje] t ON bt.TruitjeID = t.Id;";
            SqlConnection conn = DbConnection.CreateConnection();
            SqlCommand cmd = new(sql, conn);
            try {
                conn.Open();
                IDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    if (id == (int)reader["BestellingID"]) {
                        Club club = new Club((string)reader["competitie"], (string)reader["ploeg"]);
                        Clubset clubset = new Clubset((bool)reader["thuis"], (int)reader["versie"]);
                        Maat truiMaat = (Maat)Enum.Parse(typeof(Maat), (string)reader["maat"]);
                        Trui truitje = new((int)reader["id"], club, (string)reader["seizoen"], (double)reader["prijs"], truiMaat, clubset);
                        int aantal = (int)reader["aantal"];
                        producten.Add(truitje, aantal);
                    }
                }
                return producten;
            }catch(Exception ex) {
                throw new BestellingRepositoryADOException("BestellingRepository: GetInhoudBeselling - gefaald", ex);
            }
            finally {
                conn.Close();
            }
        }
    }
}
