using AppCore.DTOs;


namespace AppCore.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> ListProductsAsync();
        Task<ProductDTO> GetProductByIdAsync(string id);
        Task AddProductAsync(CreateProductDTO prod);
        Task EditProductAsync(CreateProductDTO prod);
        Task RemoveProductAsync(string id);

    }
}
