using System.Threading.Tasks;
using Lab1.Interfaces;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;

namespace Lab1.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public DbContext _dbContext { get; }
        public IUserRepository _userRepository { get; }

        public ICategoryRepository _categoryRepository { get; }

        public ITagRepository _tagRepository { get; }

        public IProductRepository _productRepository { get; }

        public IClientRepository _clientRepository { get; }

        public IOrderRepository _orderRepository { get; }

        public UnitOfWork(EfConfig.MyDbContext dbContext, 
            IUserRepository userRepository, ICategoryRepository categoryRepository,
            ITagRepository tagRepository, IProductRepository productRepository, 
            IClientRepository clientRepository, IOrderRepository orderRepository)
        {
            _dbContext = dbContext;
            _userRepository = userRepository;
            _tagRepository = tagRepository;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _clientRepository = clientRepository;
            _orderRepository = orderRepository;
        }
        
        public async Task<int> SaveChanges()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}