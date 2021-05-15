using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon
{
    public static class DbConnector
    {
        private const string CONNECTION_STRING = "workstation id=beautysaloon.mssql.somee.com;packet size=4096;user id=kusachiy_SQLLogin_1;pwd=2uot7zvgsa;data source=beautysaloon.mssql.somee.com;persist security info=False;initial catalog=beautysaloon";
        //private static SqlConnection _connection;

        private static SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(CONNECTION_STRING);
            try
            {
                connection.Open();               
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return connection;
        }

        public static SqlConnection GetConnection
        {
            get
            {
                return CreateConnection();
            }
        }
    }
}
