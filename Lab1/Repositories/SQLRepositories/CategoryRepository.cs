using System.Collections.Generic;
using System.Threading.Tasks;
using Lab1.Entities;
using Lab1.Interfaces.SqlRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Lab1.Entities.Parameters;
using System;
using Lab1.Interfaces;

namespace Lab1.Repositories.SQLRepositories
{
    public class CategoryRepository : GenericRepository<Category, int>, ICategoryRepository
    {
        private ISortUtils<Category> _sortUtils;
        public CategoryRepository(EfConfig.MyDbContext dbContext, ISortUtils<Category> sortUtils) : base(dbContext)
        {
            _sortUtils = sortUtils;
        }
        public new async Task<IEnumerable<Category>> GetAll(CategoryParameters parameters)
        {
            var list = await _entities
                .Include(r => r.Products)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();

            if (!String.IsNullOrEmpty(parameters.CategoryName))
            {
                list = list.FindAll(station => station.Name.Contains(parameters.CategoryName));
            }

            return _sortUtils.ApplySort(list.AsQueryable<Category>(), parameters.OrderBy);
        }

        public new async Task<Category> GetOneById(int id)
        {
            return await _entities
                .Include(r => r.Products)
                .FirstAsync((r => r.Id.Equals(id)));
        }
    }
}