using Lab1.Entities;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.Extensions.Configuration;

namespace Lab1.Repositories.SQLRepositories
{
    public class StationRepository : GenericRepository<StationEntity, int>, IStationRepository
    {
        private static readonly string _tableName = "station";
        private static readonly bool _isSoftDelete = true;
        public StationRepository(IConnectionFactory connectionFactory, IConfiguration config) : base(connectionFactory, _tableName, _isSoftDelete)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            connectionFactory.SetConnection(connectionString);
        }
    }
}