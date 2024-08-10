using Microsoft.AspNetCore.Mvc;
using GlowHarmonySkin.Models;
using GlowHarmonySkin.Services;

namespace GlowHarmonySkin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService _productService;

        public ProductsController()
        {
            _productService = new ProductService();
        }

        public IActionResult Index()
        {
            var products = _productService.GetProducts();
            return View(products);
        }

        public IActionResult Category(string categoryName)
        {
            var products = _productService.GetProductsByCategory(categoryName);
            ViewBag.CategoryName = categoryName;
            return View(products);
        }

        public IActionResult Details(string id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
