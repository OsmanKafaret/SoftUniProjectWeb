using EnduroStore.Data;
using EnduroStore.Data.Models;
using EnduroStore.InfraStructure;
using EnduroStore.Models.Products;
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
        public IActionResult All([FromQuery]AllProductsQueryModel query)
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

        public IActionResult Glasses([FromQuery]AllProductsQueryModel query)
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

        private IEnumerable<ProductCategoriesViewModel> GetProductCategories()
        => this.db.Categories.Select(x => new ProductCategoriesViewModel
        {
            Id = x.Id,
            Name = x.Name
        }).ToList();


    }
}
