using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;

namespace Lab1.Repositories.SQLRepositories
{
    public class StationRepository : GenericRepository<Station, int>, IStationRepository
    {
        public StationRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}