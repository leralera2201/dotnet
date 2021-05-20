using System.Threading.Tasks;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Interfaces
{
    public interface IUnitOfWork
    {
        DbContext _dbContext { get; }
        IUserRepository _userRepository { get; }
        ICategoryRepository _categoryRepository { get; }
        ITagRepository _tagRepository { get; }
        IProductRepository _productRepository { get; }
        IClientRepository _clientRepository { get; }
        IOrderRepository _orderRepository { get; }

        Task<int> SaveChanges();
    }
}