using AppCore.DTOs;

namespace AppCore.Interfaces
{
    public interface IProductCategoryService
    {
        Task<IEnumerable<ProductCategoryDTO>> GetCategoriesAsync();
    }
}
