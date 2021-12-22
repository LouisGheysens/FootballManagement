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
    public class KlantRepository : IKlantRepository {

        //Bestaat Klant
        //Klopt!
        public bool bestaatKlant(Klant klant) {
            SqlConnection conn = DbConnection.CreateConnection();
            string query = "SELECT COUNT(1) FROM [Football].[dbo].[Klant] WHERE id = @id";
            using (SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    bool result = false;
                    cmd.CommandText = query;
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int));
                    cmd.Parameters["@id"].Value = klant.KlantenNummer;

                    Console.WriteLine();
                    result = (int)cmd.ExecuteScalar() == 1 ? true : false;
                    Console.WriteLine("Klant bestaat!");
                    return result;
                }
                catch (Exception ex) {
                    throw new KlantRepositoryADOException("KlantRepository: bestaatKlant- Gefaald!", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }
        //Bestaat Klant
        //klopt!
        public bool bestaatKlant(int id) {
            SqlConnection conn = DbConnection.CreateConnection();
            string query = "SELECT COUNT(1) FROM [Football].[dbo].[klant] WHERE id = @id";
            using (SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    bool result = false;
                    cmd.CommandText = query;
                    cmd.Parameters.Add(new SqlParameter("@id", System.Data.SqlDbType.Int));
                    cmd.Parameters["@id"].Value = id;

                    Console.WriteLine();
                    result = (int)cmd.ExecuteScalar() == 1 ? true : false;
                    Console.WriteLine("Klant bestaat!");
                    return result;
                }
                catch (Exception ex) {
                    throw new KlantRepositoryADOException("KlantRepository: bestaatKlant(id) - Gefaald!", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        //Klant updaten
        //Klopt!
        public void updateKlant(Klant klant) {
            string sql = "UPDATE [dbo].[Klant] SET Naam = @Naam, Adres = @Adres WHERE Id = @Id";
            SqlConnection connection = DbConnection.CreateConnection();
            using SqlCommand command = new(sql, connection);
            try {
                connection.Open();
                command.Parameters.AddWithValue("@Id", klant.KlantenNummer);
                command.Parameters.AddWithValue("@Naam", klant.Naam);
                command.Parameters.AddWithValue("@Adres", klant.Adres);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                throw new KlantRepositoryADOException("KlantUpdaten - error", ex);
            }
            finally {
                connection.Close();
            }


        }

        //Klopt!
        public void verwijderKlant(Klant klant) {
            if (!bestaatKlant(klant.KlantenNummer)) throw new KlantRepositoryADOException("KlantRepository: verwijderKlant - Klant bestaat niet!");
            SqlConnection conn = DbConnection.CreateConnection();
            string query = "DELETE FROM KLANT WHERE Id=@id";
            using (SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@id", klant.KlantenNummer);
                    cmd.ExecuteNonQuery();
                }catch(Exception ex) {
                    throw new KlantRepositoryADOException("KlantRepository: verwijderKlant - gefaald", ex);
                }
            }
        }

        //Klant toevoegen
        //Klopt!
        public Klant voegKlantToe(Klant klant) {
            SqlConnection conn = DbConnection.CreateConnection();
            string query = "INSERT INTO klant (Naam, Adres) OUTPUT INSERTED.id VALUES(@naam,@adres)";
            using(SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    cmd.Parameters.Add(new SqlParameter("@naam", System.Data.SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("@adres", System.Data.SqlDbType.NVarChar));
                    cmd.CommandText = query;
                    cmd.Parameters["@naam"].Value = klant.Naam;
                    cmd.Parameters["@adres"].Value = klant.Adres;
                    int id = (int)cmd.ExecuteScalar();
                    klant.ZetKlantId(id);
                    return klant;
                }catch(Exception ex) {
                    throw new KlantRepositoryADOException("KlantRepository: voegKlantToe - Klant werd niet toegevoegd!", ex);
                }
                finally { conn.Close(); }
            }
        }

        public List<Klant> KlantWeergeven(int id, string naam, string adres) {
            List<Klant> klanten = new();
            bool isWhere = true;
            bool isAnd = false;

            string sql = "SELECT * FROM klant";

            if(id != 0) {
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
                sql += "id = @id";
            }
            if (!string.IsNullOrWhiteSpace(naam)) {
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
                sql += "naam = @naam";
            }
            if (!string.IsNullOrWhiteSpace(adres)) {
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
                sql += "adres = @adres";
            }
            SqlConnection conn = DbConnection.CreateConnection();
            using SqlCommand command = new(sql, conn);
            try {
                conn.Open();
                if(id != 0) {
                    command.Parameters.AddWithValue("@id", id);
                }
                if (!string.IsNullOrWhiteSpace(naam)) {
                    command.Parameters.AddWithValue("@naam", naam);
                }
                if (!string.IsNullOrWhiteSpace(adres)) {
                    command.Parameters.AddWithValue("@adres", adres);
                }
                IDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    klanten.Add(new Klant((int)reader["id"], (string)reader["naam"], (string)reader["adres"]));
                }
                reader.Close();
                return klanten;
            }catch(Exception ex) {
                throw new KlantRepositoryADOException("KlantRepository: KlantWeergeven - gefaald", ex);
            }
            finally {
                conn.Close();
            }
        }
    }
}
