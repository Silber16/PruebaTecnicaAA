using Domain.Entities;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWork
{   public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepo { get; }
        IGenericRepository<ProductCategory> ProductCategoryRepo { get; }
        Task<int> SaveChangesAsync();
    }
}


