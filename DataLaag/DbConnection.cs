using Microsoft.Data.SqlClient;
using System;

namespace DataLaag
{
    public class DbConnection
    {
        private static SqlConnection _sqlConnection = null;

        public static SqlConnection Connection { get { if (_sqlConnection == null) { _sqlConnection = CreateConnection(); } return _sqlConnection; } }
        

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(@"Data Source=DESKTOP-3CJB43N\SQLEXPRESS;Initial Catalog=Football;Integrated Security=True");
        }
    }
}
