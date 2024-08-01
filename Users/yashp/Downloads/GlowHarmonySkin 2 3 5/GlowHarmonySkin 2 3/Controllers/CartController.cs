using Microsoft.AspNetCore.Mvc;
using GlowHarmonySkin.Models;
using GlowHarmonySkin.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace GlowHarmonySkin.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductService _productService;
        private static List<CartItem> _cart = new List<CartItem>();
        private readonly ILogger<CartController> _logger;

        public CartController(ILogger<CartController> logger)
        {
            _productService = new ProductService();
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Displaying cart items");
            var productIds = _cart.Select(c => c.ProductId).ToList();
            var products = _productService.GetProductsByIds(productIds);

            var cartViewModel = products.Select(product => new CartItemViewModel
            {
                Product = product,
                Quantity = _cart.First(c => c.ProductId == product.ProductId).Quantity
            }).ToList();

            return View(cartViewModel);
        }

        [HttpPost]
        public IActionResult AddToCart(string id)
        {
            _logger.LogInformation($"Adding product with ID {id} to cart");
            var cartItem = _cart.FirstOrDefault(c => c.ProductId == id);
            if (cartItem == null)
            {
                _cart.Add(new CartItem { ProductId = id, Quantity = 1 });
            }
            else
            {
                cartItem.Quantity++;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(string id)
        {
            _logger.LogInformation($"Removing product with ID {id} from cart");
            var cartItem = _cart.FirstOrDefault(c => c.ProductId == id);
            if (cartItem != null)
            {
                _cart.Remove(cartItem);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AdjustQuantity(string id, int quantity)
        {
            _logger.LogInformation($"Adjusting quantity for product with ID {id} to {quantity}");
            var cartItem = _cart.FirstOrDefault(c => c.ProductId == id);
            if (cartItem != null && quantity > 0)
            {
                cartItem.Quantity = quantity;
            }

            return RedirectToAction("Index");
        }
    }
}
