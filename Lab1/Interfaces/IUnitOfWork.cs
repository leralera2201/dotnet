using Lab1.Interfaces.SqlRepositories;

namespace Lab1.Interfaces
{
    public interface IUnitOfWork
    {
        IStationRepository _stationRepository { get; }
        IUserRepository _userRepository { get; }
    }
}