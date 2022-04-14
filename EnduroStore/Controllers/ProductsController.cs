using EnduroStore.Data;
using EnduroStore.Data.Models;
using EnduroStore.InfraStructure;
using EnduroStore.Models.Products;
using EnduroStore.Models.ShoppingCart;
using EnduroStore.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Controllers
{

    using static WebConstants;
    public class ProductsController : Controller
    {
        private readonly IProductService products;
        private readonly EnduroStoreDbContext db;


        public ProductsController(EnduroStoreDbContext db, IProductService products)
        {
            this.db = db;
            this.products = products;
        }

        public IActionResult Helmets([FromQuery] AllProductsQueryModel query)
        {
            var queryResult = this.products.GetProducts(query.Brand, query.SearchTerm, query.Sorting, query.CurrentPage, AllProductsQueryModel.ProductsPerPage, "Helmets");

            var productBrands = this.products.AllBrands("Helmets");

            query.Brands = productBrands;
            query.Products = queryResult.Products;

            return View(query);
        }
        public IActionResult All([FromQuery] AllProductsQueryModel query)
        {
            var queryResult = this.products.GetProducts(query.Brand, query.SearchTerm, query.Sorting, query.CurrentPage, AllProductsQueryModel.ProductsPerPage);

            var productBrands = this.products.AllBrands();

            query.Brands = productBrands;
            query.Products = queryResult.Products;

            return View(query);
        }

        public IActionResult Boots([FromQuery] AllProductsQueryModel query)
        {
            var queryResult = this.products.GetProducts(query.Brand, query.SearchTerm, query.Sorting, query.CurrentPage, AllProductsQueryModel.ProductsPerPage, "Boots");

            var productBrands = this.products.AllBrands("Boots");

            query.Brands = productBrands;
            query.Products = queryResult.Products;

            this.db.SaveChanges();
            return View(query);
        }

        public IActionResult Glasses([FromQuery] AllProductsQueryModel query)
        {
            var queryResult = this.products.GetProducts(query.Brand, query.SearchTerm, query.Sorting, query.CurrentPage, AllProductsQueryModel.ProductsPerPage, "Glasses");

            var productBrands = this.products.AllBrands("Glasses");

            query.Brands = productBrands;
            query.Products = queryResult.Products;

            return View(query);
        }

        public IActionResult Details(int id)
        {
            var product = this.db.Products.Where(x => x.Id == id).Select(x => new DetailsViewModel
            {
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Brand = x.Brand,
                Model = x.Model,
                Price = x.Price,
                Description = x.Description,
                IsAvialable = x.IsAvialable == true ? "Yes" : "No",
                UnitsInStock = x.UnitsInStock,
                Size = x.Size
            }).FirstOrDefault();

            return View(product);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(DetailsViewModel model)
        {
            var product = this.db.Products.Where(x => x.Id == model.Id).FirstOrDefault();

            var user = this.db.Users.Where(x => x.Id == this.User.Id()).FirstOrDefault();

            product.Size = model.Size;
           

            var shoppingCart = new ShoppingCart
            {
                User = user,
                Product = product
            };

            product.UnitsInStock -= 1;


            this.db.ShoppingCarts.Add(shoppingCart);

            TempData[GlobalMessageKey] = $"Product {product.Brand} {product.Model} was added to your basket successfully!";

            this.db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}