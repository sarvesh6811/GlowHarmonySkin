using Microsoft.AspNetCore.Mvc;
using GlowHarmonySkin.Models;
using GlowHarmonySkin.Services;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace GlowHarmonySkin.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<CartController> _logger;

        public CartController(ProductService productService, ILogger<CartController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Displaying cart items");
            var cart = GetCart();
            var productIds = cart.Select(c => c.ProductId).ToList();
            var products = _productService.GetProductsByIds(productIds);

            var cartViewModel = products.Select(product => new CartItemViewModel
            {
                Product = product,
                Quantity = cart.First(c => c.ProductId == product.ProductId).Quantity
            }).ToList();

            return View(cartViewModel);
        }

        [HttpPost]
        public IActionResult AddToCart(string id)
        {
            _logger.LogInformation($"Adding product with ID {id} to cart");
            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(c => c.ProductId == id);
            if (cartItem == null)
            {
                cart.Add(new CartItem { ProductId = id, Quantity = 1 });
            }
            else
            {
                cartItem.Quantity++;
            }
            SaveCart(cart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveFromCart(string id)
        {
            _logger.LogInformation($"Removing product with ID {id} from cart");
            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(c => c.ProductId == id);
            if (cartItem != null)
            {
                cart.Remove(cartItem);
            }
            SaveCart(cart);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AdjustQuantity(string id, int quantity)
        {
            _logger.LogInformation($"Adjusting quantity for product with ID {id} to {quantity}");
            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(c => c.ProductId == id);
            if (cartItem != null && quantity > 0)
            {
                cartItem.Quantity = quantity;
            }
            SaveCart(cart);

            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(UserInformation userInfo)
        {
            var cart = GetCart();
            if (!cart.Any())
            {
                return RedirectToAction("Index");
            }
            HttpContext.Session.SetObjectAsJson("UserInfo", userInfo);
            return RedirectToAction("OrderSummary");
        }

        public IActionResult OrderSummary()
        {
            var cart = GetCart();
            var userInfo = HttpContext.Session.GetObjectFromJson<UserInformation>("UserInfo");
            if (cart == null || userInfo == null)
            {
                return RedirectToAction("Index");
            }

            var productIds = cart.Select(c => c.ProductId).ToList();
            var products = _productService.GetProductsByIds(productIds);

            var orderSummaryViewModel = new OrderSummaryViewModel
            {
                UserInformation = userInfo,
                CartItems = products.Select(product => new CartItemViewModel
                {
                    Product = product,
                    Quantity = cart.First(c => c.ProductId == product.ProductId).Quantity
                }).ToList()
            };

            return View(orderSummaryViewModel);
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            // Clear the cart
            HttpContext.Session.Remove("Cart");

            // Redirect to the thank you page
            return RedirectToAction("ThankYou");
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        private List<CartItem> GetCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            return cart;
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }
    }
}
