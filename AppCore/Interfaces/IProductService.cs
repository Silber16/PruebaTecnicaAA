using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Interfaces
{
    internal interface IProductService
    {
        Task<IEnumerable<Product>> ListProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task<Product> AddProductAsync(Product prod);
        Task EditProductAsync(string id);
        Task RemoveProductAsync(string id);

    }
}
