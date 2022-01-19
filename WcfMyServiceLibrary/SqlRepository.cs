using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WcfMyServiceLibrary.Models;

namespace WcfMyServiceLibrary
{
    public class SqlRepository:BaseRepository
    {
        private const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=CompanyDb;User ID=CompanyUser;Password=123456User;Integrated Security=False;";
        private const string ProviderInvariantName = "System.Data.SqlClient";
        private const string GetAllCustomersQuery = "Select * From [dbo].[Users]";
        private const string GetOrdersByUserIdQuery = "Select * From [dbo].[Orders] Where [User] = @userId";
        protected override T GetConnection<T>(Func<IDbConnection, T> getData, string providerInvariantName = default, string connectionString = default)
        {

            providerInvariantName = ProviderInvariantName;
            connectionString = ConnectionString;
            return base.GetConnection(getData, providerInvariantName, connectionString);
        }

        private static void CreateSqlParameter(SqlCommand command, string parameterName, SqlDbType sqlDbType = default,
            int size = -1, ParameterDirection direction = default, object value = null)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.SqlDbType = sqlDbType;
            parameter.Direction = direction;
            parameter.Value = value;

            if (size > 0)
            {
                parameter.Size = size;
            }

            command.Parameters.Add(parameter);
        }

        public List<Customer> GetAllCustomers()
        {
            return GetConnection(connection =>
            {
                var result = new List<Customer>();
                using (var command = CreateCommand<SqlCommand>(connection, GetAllCustomersQuery))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!(reader[0] is int id))
                            {
                                continue;
                            }
                            result.Add(new Customer()
                            {
                                Id = id,
                                FirstName = reader[1].ToString(),
                                LastName = reader[2].ToString(),
                                Phone = reader[3].ToString()
                            });
                        }
                        reader.Close();
                    }
                }
                return result;
            });
        }
        
        public List<Order> GetOrdersByUserId(int userId)
        {
            return GetConnection(connection =>
            {
                var result = new List<Order>();
                using (var command = CreateCommand<SqlCommand>(connection, GetOrdersByUserIdQuery))
                {
                    CreateSqlParameter(command, "@userId", SqlDbType.Int, direction: ParameterDirection.Input, value: userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!(reader[0] is int id) || !(reader[2] is int uId) || !(reader[3] is decimal price) || !(reader[4] is decimal qty) || !(reader[5] is byte[] orderTime))
                            {
                                continue;
                            }
                            result.Add(new Order()
                            {
                                Id = id,
                                Product = reader[1].ToString(),
                                UserId = uId,
                                Price = price,
                                Qty = qty,
                                OrderTime = orderTime
                            });
                        }
                        reader.Close();
                    }
                }
                return result;
            });
        }
    }
}
