using System.Collections.Generic;
using System.Linq;
using GlowHarmonySkin.Models;

namespace GlowHarmonySkin.Services
{
    public class ProductService
    {
        private List<Product> _products;

        public ProductService()
        {
            // Initialize the products list by seeding the database
            _products = DatabaseSeeder.GetSeededProducts();
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Product GetProductById(string id)
        {
            return _products.FirstOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetProductsByIds(IEnumerable<string> ids)
        {
            return _products.Where(p => ids.Contains(p.ProductId)).ToList();
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return _products.Where(p => p.Category == category).ToList();
        }
    }
}
