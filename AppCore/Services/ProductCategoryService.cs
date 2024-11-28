using AppCore.DTOs;
using AppCore.Interfaces;
using AutoMapper;
using Infrastructure.UnitOfWork;

namespace AppCore.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductCategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ProductCategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _unitOfWork.ProductCategoryRepo.GetAsync();
            return _mapper.Map<IEnumerable<ProductCategoryDTO>>(categories);
        }
    }
}
