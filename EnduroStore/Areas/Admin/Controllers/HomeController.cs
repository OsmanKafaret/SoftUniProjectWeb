using EnduroStore.Data;
using EnduroStore.Data.Models;
using EnduroStore.Models;
using EnduroStore.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly EnduroStoreDbContext db;

        public HomeController(EnduroStoreDbContext db)
        {
            this.db = db;
        }



        public IActionResult Index()
        {
            var product = this.db.Products
                .Where(x => x.Category.Name == "Boots")
                .OrderByDescending(x => x.Id)
                .Select(x => new ProductListingViewModel
                {
                    ImageUrl = x.ImageUrl,
                    Brand = x.Brand,
                    Model = x.Model,
                    Price = x.Price,
                    UnitsInStock = x.UnitsInStock,
                    IsAvialable = x.IsAvialable == true ? "Yes" : "No",
                    Id = x.Id
                })
                .Take(6)
                .ToList();
            return View(product);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]  
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
