using System.Configuration;
using System.Data.SqlClient;
using System;

namespace BusApp
{
    class Connection
    {
        public static SqlConnection GetDBConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCon"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            Console.WriteLine("Connection Established");
            return sqlConnection;
        }
    }
}
