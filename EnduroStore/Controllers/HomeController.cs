using EnduroStore.Data;
using EnduroStore.Data.Models;
using EnduroStore.Models;
using EnduroStore.Models.Products;
using EnduroStore.Services.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService products;

        public HomeController(IProductService products)
        {

            this.products = products;
        }



        public IActionResult Index([FromQuery] AllProductsQueryModel query)
        {
            var queryResult = this.products.GetProducts(query.Brand, query.SearchTerm, query.Sorting, query.CurrentPage, AllProductsQueryModel.ProductsPerPage);

            var productBrands = this.products.AllBrands();

            query.Brands = productBrands;
            query.Products = queryResult.Products;

            return View(query);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();
       
    }
}
