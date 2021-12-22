using BusinessLogic.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using BusinessLogic.Exceptions;

namespace DataLaag.Repos {
    public class ClubRepository : IClubRepository {

        //Klopt!
        public bool bestaatCompetitie(string competitie) {
            SqlConnection conn = DbConnection.CreateConnection();
            string query = "SELECT COUNT(1) FROM [Football].[dbo].[club] WHERE competitie = @competitie";
            using (SqlCommand cmd = conn.CreateCommand()) {
                conn.Open();
                try {
                    bool result = false;
                    cmd.CommandText = query;
                    cmd.Parameters.Add(new SqlParameter("@competitie", System.Data.SqlDbType.NVarChar));
                    cmd.Parameters["@competitie"].Value = competitie;

                    Console.WriteLine();
                    result = (int)cmd.ExecuteScalar() == 1 ? true : false;
                    return result;
                }
                catch (Exception ex) {
                    throw new ClubRepositoryADOEXCEPTION("ClubRepository: bestaatCompetie - gefaald!", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        //Klopt!
        public IReadOnlyList<string> geefClub(string competitie) {
            SqlConnection conn = DbConnection.CreateConnection();
            string query = "SELECT * FROM dbo.club WHERE competitie = @competitie;";
            IList<string> lg = new List<string>();
            using (SqlCommand cmd = conn.CreateCommand()) {
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@competitie", competitie);
                conn.Open();
                try {
                    SqlDataReader sqlr = cmd.ExecuteReader();
                    while (sqlr.Read()) {
                        lg.Add((sqlr["ploeg"].ToString()));
                    }
                    return (IReadOnlyList<string>)lg;

                }
                catch(Exception ex) {
                    throw new ClubRepositoryADOEXCEPTION("Clubrepository: geefClub - failed!", ex);
                }
                finally {
                    conn.Close();
                }
            }
        }

        //Klopt!
        public IReadOnlyList<string> geefCompetities() {
            SqlConnection conn = DbConnection.CreateConnection();
            IList<string> lg = new List<string>();
            string query = "SELECT * FROM dbo.club";
            using(SqlCommand cmd = conn.CreateCommand()) {
                cmd.CommandText = query;
                conn.Open();
                try {
                    SqlDataReader rd = cmd.ExecuteReader();
                    while (rd.Read()) {
                        lg.Add(Convert.ToString(rd["competitie"]));
                    }
                    return (IReadOnlyList<string>)lg;
                }
                catch(Exception ex) {
                    throw new ClubRepositoryADOEXCEPTION("ClubRepository: geefCompetities - gefaald!", ex);

                }
                finally {
                    conn.Close();
                }
            }
        }
    }
}
