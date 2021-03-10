using MySql.Data.MySqlClient;

namespace Lab1.Interfaces
{
    public interface IConnectionFactory
    {
        MySqlConnection GetSqlConnection { get; }
        void SetConnection(string connectionString);
    }
}