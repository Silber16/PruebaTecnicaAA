
using Infrastructure.Data;
using Infrastructure.Repositories.implementations;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(
            AppDbContext dbContext,
            IProductRepository productRepository,
            IProductCategoryRepository productCategoryRepository)
        {
            _dbContext = dbContext;
            ProductRepo = productRepository;
            ProductCategoryRepo = productCategoryRepository;
        }

        public IProductRepository ProductRepo { get; private set; }
        public IProductCategoryRepository ProductCategoryRepo { get; private set; }

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
