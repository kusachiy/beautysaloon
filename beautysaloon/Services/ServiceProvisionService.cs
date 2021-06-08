using beautysaloon.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace beautysaloon.Services
{
    class ServiceProvisionService
    {

        public ServiceProvisionService()
        {

        }
        public List<ServiceProvision> GetAll()
        {
            string sqlExpression = "SELECT * FROM [ServiceProvisions]";

            var result = new List<ServiceProvision>();
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
                            int clientId = reader.GetInt32(1);
                            int masterId = reader.GetInt32(2);
                            int serviceID = reader.GetInt32(3);
                            DateTime dt = reader.GetDateTime(4);
                            int? sale = reader.GetValue(5) as int?;

                            result.Add(new ServiceProvision { Id = id, ServiceId = serviceID, ClientId = clientId, MasterId = masterId, Dt = dt, Sale = sale });
                        }
                    }
                }
            }
            return result;
        }

        internal void Update(ServiceProvision serviceProvision)
        {

        }

        internal void Create(ServiceProvision serviceProvision)
        {
            string sqlExpression = $"INSERT INTO [ServiceProvisions]([ClientId],[MasterId],[ServiceId],[DT],[Sale])" +
               $" Values ({ serviceProvision.ClientId},{serviceProvision.MasterId},{serviceProvision.ServiceId},'{serviceProvision.Dt.ToString("yyyy-MM-dd HH:mm:ss")}',{serviceProvision.Sale})";
            using (SqlConnection connection = DbConnector.GetConnection)
            {
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
            }
        }
    }
}
