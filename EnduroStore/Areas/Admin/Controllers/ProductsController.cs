﻿using EnduroStore.Data;
using EnduroStore.Data.Models;
using EnduroStore.Models.Products;
using EnduroStore.Services.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Areas.Admin.Controllers
{

    using static WebConstants;
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class ProductsController : Controller
    {
        private readonly IProductService products;
        private readonly EnduroStoreDbContext db;


        public ProductsController(EnduroStoreDbContext db, IProductService products)
        {
            this.db = db;
            this.products = products;
        }

       public IActionResult FinishedProducts(AllProductsQueryModel query)
       {
            var queryResult = this.products.GetProducts(query.Brand, query.SearchTerm, query.Sorting, query.CurrentPage, AllProductsQueryModel.ProductsPerPage, null, true);

            var productBrands = this.products.AllBrands();

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

        [Authorize(Roles = "Administrator")]
        public IActionResult AddProduct()
        {
            return View(new AddProductFormModel
            {
                Categories = this.GetProductCategories()
            });
        }

        public IActionResult Details(int id)
        {
            var product = this.products.Details(id);

            return View(product);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int id)
        {
            var product = this.db.Products.Find(id);

            this.db.Products.Remove(product);
            this.db.SaveChanges();

            TempData[GlobalMessageKey] = $"Product {product.Brand} {product.Model} is deleted successfully!";
            var something = "asasasa";

            return RedirectToAction($"All", "Products");
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult AddProduct(AddProductFormModel item)
        {
            if (!this.db.Categories.Any(s => s.Id == item.CategoryId))
            {
                this.ModelState.AddModelError(nameof(item.CategoryId), "Category does not exists");
            }

            bool isAvialable = item.IsAvialable == "Yes" ? true : false;

            if (!ModelState.IsValid)
            {
                item.Categories = this.GetProductCategories();
                return View(item);
            }

            var product = this.products.Create(item.Brand, item.Model, item.ImageUrl, item.Price,
                 item.Description, isAvialable, item.UnitsInStock, item.CategoryId);

            TempData[GlobalMessageKey] = $"Product {item.Brand} {item.Model} was added successfully!";

            return RedirectToAction($"All", "Products");
        }
        [Authorize(Roles = "Administrator")]

        public IActionResult Edit(int id)
        {
            var product = this.db.Products.Where(x => x.Id == id).FirstOrDefault();

            return View(new AddProductFormModel
            {
                Brand = product.Brand,
                Model = product.Model,
                Description = product.Description,
                UnitsInStock = product.UnitsInStock,
                IsAvialable = product.IsAvialable == true ? "Yes" : "No",
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Categories = this.GetProductCategories()
            });
        }
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        public IActionResult Edit(int id, AddProductFormModel product)
        {
            if (!ModelState.IsValid)
            {
                product.Categories = this.GetProductCategories();
                return View(product);
            }

            var redirectedAction = this.db.Products.Where(x => x.Id == id).FirstOrDefault().UnitsInStock == 0 ? "FinishedProducts" : "All";

            var editedProduct = this.db.Products.Find(id);

            editedProduct.Brand = product.Brand;
            editedProduct.CategoryId = product.CategoryId;
            editedProduct.Description = product.Description;
            editedProduct.Price = product.Price;
            editedProduct.ImageUrl = product.ImageUrl;
            editedProduct.UnitsInStock = product.UnitsInStock;
            editedProduct.IsAvialable = product.IsAvialable == "Yes" ? true : false;
            editedProduct.Model = product.Model;

            this.db.Products.Update(editedProduct);
            this.db.SaveChanges();

            TempData[GlobalMessageKey] = $"You editet the product successfully!";

           

            return RedirectToAction(redirectedAction, "Products");
        }

        private IEnumerable<ProductCategoriesViewModel> GetProductCategories()
      => this.db.Categories.Select(x => new ProductCategoriesViewModel
      {
          Id = x.Id,
          Name = x.Name
      }).ToList();
    }
}
