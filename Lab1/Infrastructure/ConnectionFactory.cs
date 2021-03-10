using Lab1.Interfaces;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Lab1.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        private static string _connectionString;

        public ConnectionFactory(IConfiguration config)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            _configuration = config;
        }
        public void SetConnection(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public MySqlConnection GetSqlConnection
        {
            get
            {
                MySqlConnection connection;
                if (!string.IsNullOrEmpty(_connectionString))
                    connection = new MySqlConnection(_connectionString);
                else
                    connection = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection"));

                connection.Open();

                return connection;
            }
        }
    }
}