using beautysaloon.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon.Services
{
    class RoleService
    {
        public RoleService() { }

        public List<Role> GetAll()
        {
            string sqlExpression = "SELECT * FROM Roles";

            var result = new List<Role>();
            using (SqlConnection connection = DbConnector.GetConnection)
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // если есть данные
                    {
                        while (reader.Read()) // построчно считываем данные
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1).Trim();
                            int level = reader.GetInt32(2); 

                            result.Add(new Role { Id = id, Name = name, Level =level});
                        }
                    }
                }
            }
            return result;
        }
    }
}
