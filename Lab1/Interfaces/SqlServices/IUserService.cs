using Lab1.Entities;

namespace Lab1.Interfaces.SqlServices
{
    public interface IUserService : IGenericCrudService<User, int>
    {
        
    }
}