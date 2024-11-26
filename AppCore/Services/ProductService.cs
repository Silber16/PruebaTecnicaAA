using AppCore.Interfaces;
using Domain.Entities;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    internal class ProductService : IProductService
    {
        private readonly UnitOfWork _unitOfWork;
        public ProductService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> AddProductAsync(Product prod)
        {
            if (prod == null) throw new ArgumentNullException("prod cannot be null");

            await _unitOfWork.ProductRepo.CreateAsync(prod);
            await _unitOfWork.SaveChangesAsync();

            return prod;
        }

        public async Task EditProductAsync(string id)
        {
            if (id == null) throw new ArgumentNullException("id cannot be null");

            var prod = await GetProductByIdAsync(id);

            if (prod == null) throw new KeyNotFoundException($"Product with id: {id} not found.");

            _unitOfWork.ProductRepo.Update(prod);
            await _unitOfWork.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<Product>> ListProductsAsync()
        {
            return await _unitOfWork.ProductRepo.GetAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            if (id == null) throw new ArgumentNullException("id cannot be null");

            return await _unitOfWork.ProductRepo.GetByStringId(id);

        }
        public async Task RemoveProductAsync(string id)
        {
            if (id == null) throw new ArgumentNullException("id cannot be null");

            var prod = await GetProductByIdAsync(id);

            if (prod == null) throw new KeyNotFoundException($"Product with id: {id} not found.");

            _unitOfWork.ProductRepo.Delete(prod);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
