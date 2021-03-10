using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface IUserService : IGenericCrudService<UserEntity, int>
    {
        
    }
}