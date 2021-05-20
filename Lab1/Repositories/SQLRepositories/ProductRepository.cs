using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Lab1.Entities.Parameters;
using System;

namespace Lab1.Repositories.SQLRepositories
{
    public class ProductRepository : GenericRepository<Product, int>, IProductRepository
    {
        public ProductRepository(EfConfig.MyDbContext dbContext) : base(dbContext)
        {
        }

        public new async Task<IEnumerable<Product>> GetAll(ProductParameters parameters)
        {
            var listAsync = await _entities
                .Include(r => r.Category).Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            if (Convert.ToBoolean(parameters.MaxPrice) && parameters.MaxPrice > 0 && parameters.MinPrice >= 0)
                listAsync = listAsync.FindAll(product =>
                    product.Price < parameters.MaxPrice &&
                    product.Price > parameters.MinPrice);

            if (!String.IsNullOrEmpty(parameters.Name))
                listAsync = listAsync.FindAll(product =>
                    product.Name.IndexOf(parameters.Name) != -1);

            return listAsync;
        }

        public new async Task<Product> GetOneById(int id)
        {
            return await _entities
                .Include(r => r.Category)
                .FirstAsync((r => r.Id.Equals(id)));
        }
    }
}