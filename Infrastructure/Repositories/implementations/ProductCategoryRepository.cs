using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.implementations
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<ProductCategory> _prodCategoryDbSet;
        public ProductCategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _prodCategoryDbSet = dbContext.Set<ProductCategory>();
        }
        public async Task<IEnumerable<ProductCategory>> GetAsync()
        {
            return await _prodCategoryDbSet.Where(ctg => ctg.IsActive == true).ToListAsync();
        }

    }
}
