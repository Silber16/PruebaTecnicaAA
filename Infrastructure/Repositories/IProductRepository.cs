using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IProductRepository
    {

        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetByStringId(string id);
        Task CreateAsync(Product entity);
        void Update(Product entity);
        void Delete(Product entity);
    }
}
