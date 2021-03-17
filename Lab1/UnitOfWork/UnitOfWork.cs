using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;

namespace Lab1.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext _dbContext { get; }
        public IStationRepository _stationRepository { get; }
        public IUserRepository _userRepository { get; }
        public IRouteRepository _routeRepository { get; }
        public IStoppageRepository _stoppageRepository { get; }
        public ITicketRepository _ticketRepository { get; }
        public ITrainRepository _trainRepository { get; }

        public UnitOfWork(EfConfig.MyDbContext dbContext, IStationRepository stationRepository,
            IUserRepository userRepository, IRouteRepository routeRepository, IStoppageRepository stoppageRepository,
            ITicketRepository ticketRepository, ITrainRepository trainRepository)
        {
            _dbContext = dbContext;
            _stationRepository = stationRepository;
            _userRepository = userRepository;
            _routeRepository = routeRepository;
            _stoppageRepository = stoppageRepository;
            _ticketRepository = ticketRepository;
            _trainRepository = trainRepository;
        }
        
        public async void SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}