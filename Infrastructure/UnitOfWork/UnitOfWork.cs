using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.implementations;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            ProductRepo = new ProductRepository(_dbContext);
            ProductCategoryRepo = new GenericRepository<ProductCategory>(_dbContext);
        }

        public IProductRepository ProductRepo { get; private set; }
        public IGenericRepository<ProductCategory> ProductCategoryRepo { get; private set; }

        public async Task<int> SaveChangesAsync()
            {
                return await _dbContext.SaveChangesAsync();
            }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
