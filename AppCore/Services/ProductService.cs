using AppCore.Interfaces;
using Domain.Entities;
using Infrastructure.UnitOfWork;
using AutoMapper;
using AppCore.DTOs;

namespace AppCore.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddProductAsync(CreateProductDTO prod)
        {
            if (prod == null) throw new ArgumentNullException("prod cannot be null");

            var mappedProd = _mapper.Map<Product>(prod); // convierte 'prod' en tipo Product para poder utilizarlo en el metodo CreateAsync().

            await _unitOfWork.ProductRepo.CreateAsync(mappedProd);

            await _unitOfWork.SaveChangesAsync();
       
        }

        public async Task EditProductAsync(CreateProductDTO prod)
        {
            if (prod == null) throw new ArgumentNullException("prod cannot be null");

            var mappedProd = _mapper.Map<Product>(prod); // convierte 'prod' en tipo Product para poder utilizarlo en el metodo Update().

            _unitOfWork.ProductRepo.Update(mappedProd);

            await _unitOfWork.SaveChangesAsync();
           
        }

        public async Task<IEnumerable<ProductDTO>> ListProductsAsync()
        {
            var prods = await _unitOfWork.ProductRepo.GetProductsAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(prods);
        }

        public async Task<ProductDTO> GetProductByIdAsync(string id)
        {
            if (id == null) throw new ArgumentNullException("id cannot be null");

            var prod = await _unitOfWork.ProductRepo.GetByStringId(id);

            return _mapper.Map<ProductDTO>(prod);

        }
        public async Task RemoveProductAsync(string id)
         {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id), "Product ID cannot be null");

            var prod = await _unitOfWork.ProductRepo.GetByStringId(id);
            if (prod == null) throw new KeyNotFoundException($"Product with id: {id} not found.");

            _unitOfWork.ProductRepo.Delete(prod);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
