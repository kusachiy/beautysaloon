using beautysaloon.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon.Services
{
    class ServiceService
    {
        public ServiceService()
        {

        }
        public List<Service> GetAll()
        {
            string sqlExpression = "SELECT * FROM Services";

            var result = new List<Service>();
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
                            string desc = reader.GetString(2).Trim();
                            int duration = reader.GetInt32(3);
                            int price = reader.GetInt32(4);

                            result.Add(new Service { Id = id, Name = name, Description = desc, Duration = duration, Price = price });
                        }
                    }
                }
            }
            return result;
        }

        internal void Update(Service service)
        {
            string sqlExpression = $"UPDATE [dbo].[Services] SET[Name] = {service.Name.WithPartipiants()},[Description] = {service.Description.WithPartipiants()},"
                +$"[Duration] = {service.Duration},[Price] ={service.Price} WHERE ID = {service.Id}";
            using (SqlConnection connection = DbConnector.GetConnection)
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);             
                int number = command.ExecuteNonQuery();               
            }
        }

        internal void Create(Service service)
        {
            string sqlExpression = $"INSERT INTO [dbo].[Services] ([Name],[Description],[Duration],[Price])" +
                $" Values ({ service.Name.WithPartipiants()},{service.Description.WithPartipiants()},{service.Duration},{service.Price})";
            using (SqlConnection connection = DbConnector.GetConnection)
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }
        }
    }
}
