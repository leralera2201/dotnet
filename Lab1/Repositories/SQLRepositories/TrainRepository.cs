using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;

namespace Lab1.Repositories.SQLRepositories
{
    public class TrainRepository : GenericRepository<Train, int>, ITrainRepository
    {
        public TrainRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}