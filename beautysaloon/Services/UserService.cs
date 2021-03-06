using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using beautysaloon.Models.RequestResponseModels;
using Microsoft.Data.SqlClient;

namespace beautysaloon.Services
{
    class UserService
    {
        public UserService() { }

        public List<User> GetAll()
        {
            string sqlExpression = "SELECT * FROM Users";

            var result = new List<User>();
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
                            string login = reader.GetString(2).Trim();
                            string hashPassword = reader.GetString(3).Trim();
                            int roleid = reader.GetInt32(4);

                            result.Add(new User { Id = id, Name = name, Login = login, HashPassword = hashPassword, RoleID = roleid });
                        }
                    }
                }
            }
            return result;
        }

        internal void Update(User user)
        {
            string sqlExpression = $"UPDATE [dbo].[Users] SET[Name] = {user.Name.WithPartipiants()},[RoleID] = {user.RoleID} WHERE ID = {user.Id}";
            using (SqlConnection connection = DbConnector.GetConnection)
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }
        }

        internal void Create(User user)
        {
            string sqlExpression = $"INSERT INTO [dbo].[Users] ([Name],[Login],[HashPass],[RoleId])" +
               $" Values ({ user.Name.WithPartipiants()},{user.Login.WithPartipiants()},{Credentalis.HashPassword("Test").WithPartipiants()},{user.RoleID})";
            using (SqlConnection connection = DbConnector.GetConnection)
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }
        }
    }
}