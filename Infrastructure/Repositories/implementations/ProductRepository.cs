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
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly DbSet<Product> _prodDbSet;
        public ProductRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _prodDbSet = dbContext.Set<Product>();
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _prodDbSet.Where(prod => prod.IsActive == true).Include(prod => prod.CategoryProduct).ToListAsync();
        }
        public async Task<Product> GetByStringId(string id)
        {
            return await _prodDbSet.FirstAsync(prod => prod.ProductId == id);
        }

        public async Task CreateAsync(Product entity)
        {
            await _prodDbSet.AddAsync(entity);
        }

        public void Delete(Product entity)
        {
            _prodDbSet.Remove(entity);
        }

        public void Update(Product entity)
        {
            _prodDbSet.Update(entity);
        }
    }
}
