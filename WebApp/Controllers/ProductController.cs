using AppCore.DTOs;
using AppCore.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            _productService = productService;
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.ListProductsAsync();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var categories = await _productCategoryService.GetCategoriesAsync();
            ViewData["Categories"] = new SelectList(categories, "CategoryProductId", "CategoryDescription"); 

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO prod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("prod model is invalid");
            }

            await _productService.AddProductAsync(prod);

            return RedirectToAction("Index");


        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var categories = await _productCategoryService.GetCategoriesAsync();
            ViewData["Categories"] = new SelectList(categories, "CategoryProductId", "CategoryDescription");

            var prod = await _productService.GetProductByIdAsync(id);
           
            var createProductDTO = new CreateProductDTO
            {
                ProductId = prod.ProductId,
                ProductDescription = prod.ProductDescription,
                CategoryProductId = prod.CategoryProductId,
                Stock = prod.Stock,
                Price = prod.Price,
                HaveECDiscount = prod.HaveECDiscount,
                IsActive = prod.IsActive
            };

            return View(createProductDTO);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(CreateProductDTO prod)
        {
            await _productService.EditProductAsync(prod);

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> RemoveProduct([FromRoute]string id)
        {
            await _productService.RemoveProductAsync(id);

            return RedirectToAction("Index");
     
        }
    }
}
