using AppCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var projects = await _productService.ListProductsAsync();

            return View(projects);
        }
    }
}
