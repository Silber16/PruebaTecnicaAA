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
    internal class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Product> _prodDbSet;
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _prodDbSet = dbContext.Set<Product>();
        }
        public async Task<Product> GetByStringId(string id)
        {
            return await _prodDbSet.FirstAsync(prod => prod.ProductId == id);
        }
    }
}
