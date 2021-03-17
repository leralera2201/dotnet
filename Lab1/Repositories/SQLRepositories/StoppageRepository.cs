using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;

namespace Lab1.Repositories.SQLRepositories
{
    public class StoppageRepository : GenericRepository<Stoppage, int>, IStoppageRepository
    {
        public StoppageRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}