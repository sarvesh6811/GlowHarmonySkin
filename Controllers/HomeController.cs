using Microsoft.AspNetCore.Mvc;
using GlowHarmonySkin.Models;
using System.Collections.Generic;

namespace GlowHarmonySkin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var categories = new List<Category>
            {
                new Category { Name = "Cleanser" },
                new Category { Name = "Serum" },
                new Category { Name = "Moisturizer" },
                new Category { Name = "Exfoliator" }
            };

            return View(categories);
        }
    }
}
