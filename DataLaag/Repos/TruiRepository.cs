using BusinessLogic;
using BusinessLogic.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Model;
using BusinessLogic.Exceptions;

namespace DataLaag.Repos {
    public class TruiRepository : IVoetbalTruiRepository {
        //Klopt!
        public bool BestaatTruitje(int id) {
            SqlConnection conn = DbConnection.CreateConnection();
            string query = "SELECT COUNT(1) FROM [Football].[dbo].[truitje] WHERE Id = @id";
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
                    throw new TruiRepositoryADOException("TruiRepository: BestaatTruitje - gefaald!", ex);
                } finally {
                    conn.Close();
                }
            }
        }

        //Klopt!
        public bool BestaatTruitje(Trui truitje) {
            SqlConnection conn = DbConnection.CreateConnection();
            string query = "SELECT COUNT(1) FROM [Football].[dbo].[truitje] WHERE Id = @id";
            using (SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    bool result = false;
                    cmd.CommandText = query;
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int));
                    cmd.Parameters["@id"].Value = truitje.Id;

                    Console.WriteLine();
                    result = (int)cmd.ExecuteScalar() == 1 ? true : false;
                    return result;
                }
                catch (Exception ex) {
                    throw new TruiRepositoryADOException("TruiRepository: BestaatTrutitje - gefaald!", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        //Klopt
        public Trui GeefVoetbalTruitje(int id) {
            SqlConnection connection = DbConnection.CreateConnection();
            string query = "SELECT * FROM truitje WHERE id=@id";

            using (SqlCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                try {
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    Trui truitje = new Trui(new Club((string)reader["competitie"], (string)reader["ploeg"]),
                           (string)reader["seizoen"], (double)reader["prijs"],
                           (Maat)Enum.Parse(typeof(Maat), (string)reader["kledingmaat"]), new Clubset((bool)reader["thuis"], (int)reader["versie"]));
                    return truitje;
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return null;
                }
                finally { connection.Close(); }
            }
        }


        public IReadOnlyList<Trui> GeefVoetbalTruitjesViaCompetitie(string competitie) {
            SqlConnection conn = DbConnection.CreateConnection();
            string query = "SELECT * FROM dbo.truitje WHERE competitie = @competitie;";
            IList<Trui> lg = new List<Trui>();
            using (SqlCommand cmd = conn.CreateCommand()) {
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@competitie", competitie);
                conn.Open();
                try {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()) {
                        lg.Add(new Trui(new Club((string)reader["competitie"], (string)reader["ploeg"]),
                            (string)reader["seizoen"], (double)reader["prijs"],
                            (Maat)Enum.Parse(typeof(Enum), (string)reader["kledingmaat"]), new Clubset((bool)reader["thuis"], (int)reader["versie"])));
                    }
                    return (IReadOnlyList<Trui>)lg;
                } catch (Exception ex) {
                    throw new TruiRepositoryADOException("TruiRepository: GeefVoetbalTruitjesViaCompetitie - gefaald!", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        //Klopt!
        public void UpdateTruitje(Trui truitje) {
            SqlConnection conn = DbConnection.CreateConnection();
            Trui huidigTruitje = this.GeefVoetbalTruitje(truitje.Id);
            if (truitje.Equals(huidigTruitje)) throw new TruiRepositoryADOException("TruiRepository: UpdateTtuitje - er is geen verschil!");
            string sql = "UPDATE [dbo].[Truitje] SET Maat = @Maat, Seizoen = @Seizoen, " +
                "Prijs = @Prijs, Versie = @Versie, Thuis = @Thuis, " +
                "Competitie = @Competitie, " +
                "Ploeg = @Ploeg WHERE Id = @Id";
            using SqlCommand command = new(sql, conn);
            try {
                conn.Open();
                command.Parameters.AddWithValue("@Id", truitje.Id);
                command.Parameters.AddWithValue("@Maat", truitje.Kledingmaat.ToString());
                command.Parameters.AddWithValue("@Seizoen", truitje.Seizoen);
                command.Parameters.AddWithValue("@Prijs", truitje.Prijs);
                command.Parameters.AddWithValue("@Versie", truitje.ClubSet.Versie);
                command.Parameters.AddWithValue("@Thuis", truitje.ClubSet.Thuis);
                command.Parameters.AddWithValue("@Competitie", truitje.Club.Competitie);
                command.Parameters.AddWithValue("@Ploeg", truitje.Club.PloegNaam);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                throw new TruiRepositoryADOException("UpdateVoetbalTruitje - error", ex);
            }
            finally {
                conn.Close();
            }
        }

        //Klopt!
        public void VerwijderTruitje(Trui id) {
            if (!BestaatTruitje(id)) throw new TruiRepositoryADOException("TruiTRepository: VerwijderTritje - Truitje bestaat niet!");
            string sql = "DELETE FROM [dbo].[truitje] WHERE Id = @Id";
            SqlConnection connection = DbConnection.CreateConnection();
            using SqlCommand command = new(sql, connection);
            try {
                connection.Open();
                command.Parameters.AddWithValue("@Id", id.Id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                throw new TruiRepositoryADOException("VoetbaltruitjeVerwijderen - error", ex);
            }
            finally {
                connection.Close();
            }
        }

        //Klopt!
        public Trui VoegTruitjeToe(Trui truitje) {
            SqlConnection conn = DbConnection.CreateConnection();
            string query = "INSERT INTO dbo.truitje(maat, seizoen, prijs, versie, thuis, competitie, ploeg) OUTPUT INSERTED.id VALUES(@maat, @seizoen, " +
                "@prijs, @versie, @thuis, @competitie," +
                "@ploeg)";
            using (SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    cmd.Parameters.Add(new SqlParameter("@maat", System.Data.SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@seizoen", System.Data.SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@prijs", System.Data.SqlDbType.Float));
                    cmd.Parameters.Add(new SqlParameter("@versie", System.Data.SqlDbType.Bit));
                    cmd.Parameters.Add(new SqlParameter("@thuis", System.Data.SqlDbType.Bit));
                    cmd.Parameters.Add(new SqlParameter("@competitie", System.Data.SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@ploeg", System.Data.SqlDbType.NVarChar));
                    cmd.CommandText = query;
                    cmd.Parameters["@maat"].Value = truitje.Kledingmaat;
                    cmd.Parameters["@seizoen"].Value = truitje.Seizoen;
                    cmd.Parameters["@prijs"].Value = truitje.Prijs;
                    cmd.Parameters["@versie"].Value = truitje.ClubSet.Versie;
                    cmd.Parameters["@thuis"].Value = truitje.ClubSet.Thuis;
                    cmd.Parameters["@competitie"].Value = truitje.Club.Competitie;
                    cmd.Parameters["@ploeg"].Value = truitje.Club.PloegNaam;
                    int id = (int)cmd.ExecuteScalar();
                    return truitje;
                }
                catch (Exception ex) {
                    throw new TruiRepositoryADOException("TruiRepository: VoegTruitjeToe - gefaald!", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        public IReadOnlyList<Trui> GeefVoetbaltruitjesWeer(int id, string competitie, string club, string seizoen, double? prijs, bool? thuis, 
            int versie, string maat) {
            List<Trui> voetbalTruitjes = new List<Trui>();
            bool isWhere = true;
            bool isAnd = false;

            string query = "SELECT * FROM truitje";

            if(id != 0) {
                if (isWhere) {
                    query += " WHERE ";
                    isWhere = false;
                }
                if (isAnd) {
                    query += " AND ";
                }
                else {
                    isAnd = true;
                }
                query += "id = @id";
            }
            if (!string.IsNullOrWhiteSpace(competitie)) {
                if (isWhere) {
                    query += " WHERE ";
                    isWhere = false;
                }
                if (isAnd) {
                    query += " AND ";
                }
                else {
                    isAnd = true;
                }
                query += "competitie = @competitie";
            }
            if (!string.IsNullOrWhiteSpace(club)) {
                if (isWhere) {
                    query += " WHERE ";
                    isWhere = false;
                }
                if (isAnd) {
                    query += " AND ";
                }
                else {
                    isAnd = true;
                }
                query += "club = @ploeg";
            }
            if (!string.IsNullOrWhiteSpace(seizoen)) {
                if (isWhere) {
                    query += " WHERE ";
                    isWhere = false;
                }
                if (isAnd) {
                    query += " AND ";
                }
                else {
                    isAnd = true;
                }
                query += "seizoen = @seizoen";
            }
            if(prijs != null) {
                if (isWhere) {
                    query += " WHERE ";
                    isWhere = false;
                }
                if (isAnd) {
                    query += " AND ";
                }
                else {
                    isAnd = true;
                }
                query += "prijs = @prijs";
            }
            if(thuis != null) {
                if (isWhere) {
                    query += " WHERE ";
                    isWhere = false;
                }
                if (isAnd) {
                    query += " AND ";
                }
                else {
                    isAnd = true;
                }
                query += "thuis = @thuis";
            }
            if(versie != 0) {
                if (isWhere) {
                    query += " WHERE ";
                    isWhere = false;
                }
                if (isAnd) {
                    query += " AND ";
                }
                else {
                    isAnd = true;
                }
                query += "versie = @versie";
            }
            if (!string.IsNullOrWhiteSpace(maat)) {
                if (isWhere) {
                    query += " WHERE ";
                    isWhere = false;
                }
                if (isAnd) {
                    query += " AND ";
                }
                else {
                    isAnd = true;
                }
                query += "maat = @maat";
            }
            SqlConnection conn = DbConnection.CreateConnection();
            using SqlCommand cmd = new(query, conn);
            try {
                conn.Open();
                if(id != 0) {
                    cmd.Parameters.AddWithValue("@id", id);
                }
                if (!string.IsNullOrWhiteSpace(competitie)) {
                    cmd.Parameters.AddWithValue("@competitie", competitie);
                }
                if (!string.IsNullOrWhiteSpace(club)) {
                    cmd.Parameters.AddWithValue("@ploeg", club);
                }
                if (!string.IsNullOrWhiteSpace(seizoen)) {
                    cmd.Parameters.AddWithValue("@seizoen", seizoen);
                }
                if(prijs != null) {
                    cmd.Parameters.AddWithValue("@prijs", prijs);
                }
                if(thuis != null) {
                    cmd.Parameters.AddWithValue("@thuis", thuis);
                }
                if(versie != 0) {
                    cmd.Parameters.AddWithValue("@versie", versie);
                }
                if (!string.IsNullOrWhiteSpace(maat)) {
                    cmd.Parameters.AddWithValue("@maat", maat);
                }
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Club clubje = new((string)(reader)["competitie"], (string)reader["ploeg"]);
                    Clubset clubsetje = new((bool)reader["thuis"], (int)reader["versie"]);
                    Maat maatje = (Maat)Enum.Parse(typeof(Maat), (string)reader["maat"]);
                    Trui voetbaltruitje = new((int)reader["id"], clubje, (string)reader["seizoen"], (double)reader["prijs"], maatje, clubsetje);
                    voetbalTruitjes.Add(voetbaltruitje);
                }
                reader.Close();
                return voetbalTruitjes;
            }catch(Exception ex) {
                throw new TruiRepositoryADOException("TruiRepository: GeefVoetbalTruitjesWeer - gefaald", ex);
            }
            finally {
                conn.Close();
            }
        }

        public IReadOnlyList<Trui> ZoekVoetbaltruitjes(int id, string competitie, string ploeg, string seizoen, double? prijs, bool? thuis, int versie, string maat) {
            List<Trui> voetbaltruitjes = new();
            bool isWhere = true;
            bool isAnd = false;
            string sql = "SELECT * FROM [dbo].[Truitje]";
            if (id != 0) {
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
                sql += "Id = @Id";
            }
            if (!string.IsNullOrWhiteSpace(competitie)) {
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
                sql += "Competitie = @Competitie";
            }
            if (!string.IsNullOrWhiteSpace(ploeg)) {
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
                sql += "Ploeg = @Ploeg";
            }
            if (!string.IsNullOrWhiteSpace(seizoen)) {
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
                sql += "Seizoen = @Seizoen";
            }
            if (prijs != null) {
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
                sql += "Prijs = @Prijs";
            }
            if (thuis != null) {
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
                sql += "Thuis = @Thuis";
            }
            if (versie != 0) {
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
                sql += "Versie = @Versie";
            }
            if (!string.IsNullOrWhiteSpace(maat)) {
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
                sql += "Maat = @Maat";
            }
            SqlConnection connection = DbConnection.CreateConnection();
            using SqlCommand command = new(sql, connection);
            try {
                connection.Open();
                if (id != 0) {
                    command.Parameters.AddWithValue("@Id", id);
                }
                if (!string.IsNullOrWhiteSpace(competitie)) {
                    command.Parameters.AddWithValue("@Competitie", competitie);
                }
                if (!string.IsNullOrWhiteSpace(ploeg)) {
                    command.Parameters.AddWithValue("@Ploeg", ploeg);
                }
                if (!string.IsNullOrWhiteSpace(seizoen)) {
                    command.Parameters.AddWithValue("@Seizoen", seizoen);
                }
                if (prijs != null) {
                    command.Parameters.AddWithValue("@Prijs", prijs);
                }
                if (thuis != null) {
                    command.Parameters.AddWithValue("@Thuis", thuis);
                }
                if (versie != 0) {
                    command.Parameters.AddWithValue("@Versie", versie);
                }
                if (!string.IsNullOrWhiteSpace(maat)) {
                    command.Parameters.AddWithValue("@Maat", maat);
                }
                IDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    Club club = new((string)reader["Competitie"], (string)reader["Ploeg"]);
                    Clubset clubSet = new((bool)reader["Thuis"], (int)reader["Versie"]);
                    Maat kledingmaat = (Maat)Enum.Parse(typeof(Maat), (string)reader["Maat"]);
                    Trui voetbaltruitje = new((int)reader["Id"], club, (string)reader["Seizoen"], (double)reader["Prijs"], kledingmaat, clubSet);
                    voetbaltruitjes.Add(voetbaltruitje);
                }
                reader.Close();
                return voetbaltruitjes;
            }
            catch (Exception ex) {
                throw new TruiRepositoryADOException("VoetbaltruitjeWeergeven - error", ex);
            }
            finally {
                connection.Close();
            }
        }
    }
}