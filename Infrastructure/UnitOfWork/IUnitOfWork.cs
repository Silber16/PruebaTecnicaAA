using Domain.Entities;
using Infrastructure.Repositories;


namespace Infrastructure.UnitOfWork
{   public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepo { get; }
        IProductCategoryRepository ProductCategoryRepo { get; }
        Task<int> SaveChangesAsync();
    }
}


