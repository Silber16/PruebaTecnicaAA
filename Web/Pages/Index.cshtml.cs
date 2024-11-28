using AppCore.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppCore.DTOs;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }


        public async Task OnGetAsync()
        {
            Products = _productService.ListProductsAsync();
        }
    }
}
