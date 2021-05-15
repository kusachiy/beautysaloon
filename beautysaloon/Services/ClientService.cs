using beautysaloon.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon.Services
{
    class ClientService
    {
        public List<Client> GetAll()
        {
            string sqlExpression = "SELECT * FROM dbo.Clients";

            var result = new List<Client>();
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
                            string fio = reader.GetString(1).Trim();
                            int age = reader.GetInt32(2);
                            string phone = reader.GetString(3).Trim();
                            string sex = reader.GetString(4).Trim();

                            result.Add(new Client { Id = id, Fio = fio, Age = age, Phone = phone, Sex = sex });
                        }
                    }
                }
            }
            return result;
        }

        internal void Update(Client client)
        {
            string sqlExpression = $"UPDATE [dbo].[Clients] SET[fio] = {client.Fio.WithPartipiants()},[Age] = {client.Age},"
                + $"[Phone] = {client.Phone.WithPartipiants()},[Sex] ={client.Sex.WithPartipiants()} WHERE ID = {client.Id}";
            using (SqlConnection connection = DbConnector.GetConnection)
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }
        }

        internal void Create(Client client)
        {
            string sqlExpression = $"INSERT INTO [dbo].[Clients] ([fio],[Age],[Phone],[Sex])" +
                $" Values ({ client.Fio.WithPartipiants()},{client.Age},{client.Phone.WithPartipiants()},{client.Sex.WithPartipiants()})";
            using (SqlConnection connection = DbConnector.GetConnection)
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }
        }
    }
}
