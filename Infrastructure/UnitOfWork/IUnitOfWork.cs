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
        IGenericRepository<Product> ProductRepo { get; }
        IGenericRepository<ProductCategory> ProductCategoryRepo { get; }
        Task<int> SaveChangesAsync();
    }
}

}
