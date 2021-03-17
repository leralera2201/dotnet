using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;

namespace Lab1.Repositories.SQLRepositories
{
    public class RouteRepository : GenericRepository<Route, int>, IRouteRepository
    {
        public RouteRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }
    }
}