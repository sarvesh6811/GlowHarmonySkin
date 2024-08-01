using System.Collections.Generic;
using GlowHarmonySkin.Models;

namespace GlowHarmonySkin
{
    public static class DatabaseSeeder
    {
        public static void Seed()
        {
            var products = GetSeededProducts();

            // Print or store the data as needed
            foreach (var product in products)
            {
                System.Console.WriteLine($"Product: {product.Name}, Description: {product.Description}, Price: {product.Price}");
            }
        }

        public static List<Product> GetSeededProducts()
        {
            return new List<Product>
            {
                new Product
                {
                    ProductId = "1",
                    Name = "Hydrating Facial Cleanser",
                    Description = "A gentle facial cleanser that removes dirt and oil without stripping the skin's natural moisture.",
                    Price = 14.99M,
                    Category = "Cleanser",
                    ImageUrl = "/images/hydrating_facial_cleanser.jpg",
                    Stock = 50
                },
                new Product
                {
                    ProductId = "2",
                    Name = "Vitamin C Serum",
                    Description = "A powerful serum with Vitamin C to brighten and even out skin tone.",
                    Price = 29.99M,
                    Category = "Serum",
                    ImageUrl = "/images/vitamin_c_serum.jpg",
                    Stock = 30
                },
                new Product
                {
                    ProductId = "3",
                    Name = "Retinol Night Cream",
                    Description = "A night cream that reduces the appearance of fine lines and wrinkles with retinol.",
                    Price = 39.99M,
                    Category = "Moisturizer",
                    ImageUrl = "/images/retinol_night_cream.jpg",
                    Stock = 20
                },
                new Product
                {
                    ProductId = "4",
                    Name = "Daily Moisturizer with SPF",
                    Description = "A lightweight daily moisturizer that provides hydration and sun protection.",
                    Price = 24.99M,
                    Category = "Moisturizer",
                    ImageUrl = "/images/daily_moisturizer_spf.jpg",
                    Stock = 40
                },
                new Product
                {
                    ProductId = "5",
                    Name = "Exfoliating Scrub",
                    Description = "An exfoliating scrub that helps to remove dead skin cells and unclog pores.",
                    Price = 19.99M,
                    Category = "Exfoliator",
                    ImageUrl = "/images/exfoliating_scrub.jpg",
                    Stock = 35
                },
                new Product
                {
                    ProductId = "6",
                    Name = "Night Serum",
                    Description = "A rejuvenating night serum that promotes cell renewal and hydrates the skin overnight.",
                    Price = 34.99M,
                    Category = "Serum",
                    ImageUrl = "/images/night_serum.jpg",
                    Stock = 25
                }
            };
        }
    }
}
