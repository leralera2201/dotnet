using Lab1.Entities;

namespace Lab1.Interfaces.SqlRepositories
{
    public interface IUserRepository : IGenericRepository<UserEntity, int>
    {
        
    }
}