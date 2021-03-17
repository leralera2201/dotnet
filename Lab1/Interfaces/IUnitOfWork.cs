using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Interfaces
{
    public interface IUnitOfWork
    {
        DbContext _dbContext { get; }
        IStationRepository _stationRepository { get; }
        IUserRepository _userRepository { get; }
        IRouteRepository _routeRepository { get; }
        IStoppageRepository _stoppageRepository { get; }
        ITicketRepository _ticketRepository { get; }
        ITrainRepository _trainRepository { get; }

        void SaveChanges();
    }
}