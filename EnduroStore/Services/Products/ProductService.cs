using EnduroStore.Data;
using EnduroStore.Data.Models;
using EnduroStore.Models.Products;
using EnduroStore.Services.Products.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Services.Products
{
    public class ProductService : IProductService
    {

        private readonly EnduroStoreDbContext data;
       
        public ProductService(EnduroStoreDbContext data)
        {
            this.data = data;
       
        }
        public ProductQueryServiceModel GetProducts(string brand = null, string searchTerm = null, ProductSorting sorting = ProductSorting.PriceASC, int currentPage = 1, int productsPerPage = int.MaxValue, string category = null, bool isFinished = false)
        {
            var productsQuery = this.data.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                productsQuery = productsQuery.Where(x => x.Category.Name == category);
            }
               
            if(isFinished == true)
            {
                productsQuery = productsQuery.Where(x => x.UnitsInStock == 0 || x.IsAvialable == false);
            }

            if (!string.IsNullOrWhiteSpace(brand))
            {
                productsQuery = productsQuery.Where(c => c.Brand == brand);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                productsQuery = productsQuery.Where(c =>
                    (c.Brand + " " + c.Model).ToLower().Contains(searchTerm.ToLower()) ||
                    c.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            productsQuery = sorting switch
            {
                ProductSorting.PriceASC => productsQuery.OrderBy(x => x.Price),
                ProductSorting.PriceDESC => productsQuery.OrderByDescending(x => x.Price),
                _ => productsQuery.OrderByDescending(x => x.Id)
            };

          

            var products = GetProducts(productsQuery
                .Skip((currentPage - 1) * productsPerPage)
                .Take(productsPerPage));

           

            return new ProductQueryServiceModel
            {
                CurrentPage = currentPage,
                CarsPerPage = productsPerPage,
                Products = products
            };
        }

        public IEnumerable<string> AllBrands(string category)
        {
            var query = this.data.Products.Select(x => x.Brand).Distinct().OrderBy(x => x).ToList();

            if(category != null)
            {
                query = this.data.Products.Where(x => x.Category.Name == category).Select(x => x.Brand).Distinct().OrderBy(x => x).ToList();
            }

            return query;
        }

        public DetailsViewModel Details(int id)
        =>
            this.data.Products.Where(x => x.Id == id)
                .Select(x => new DetailsViewModel
                {
                    Id = x.Id,
                    ImageUrl = x.ImageUrl,
                    Price = x.Price,
                    Brand = x.Brand,
                    Model = x.Model,
                    Size = x.Size,
                    Description = x.Description,
                    IsAvialable = x.IsAvialable == true ? "Yes" : "No",
                    UnitsInStock = x.UnitsInStock
                }).FirstOrDefault();


        
        

        private IEnumerable<ProductServiceModel> GetProducts(IQueryable<Product> productQuery)
        => productQuery
            .Select(x => new ProductServiceModel
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                ImageUrl = x.ImageUrl,
                CategoryName = x.Category.Name,
                IsAvialable = x.IsAvialable == true ? "Yes" : "No",
                Price = x.Price,
                UnitsInStock = x.UnitsInStock
            })
            .ToList();

        public int Create(string brand, string model, string imageUrl, decimal price, string description, bool isAvialable, int unitsInStock, int categoryId)
        {
            var product = new Product
            {
                Brand = brand,
                Model = model,
                Description = description,
                ImageUrl = imageUrl,
                CategoryId = categoryId,
                Price = price,
                IsAvialable = isAvialable,
                UnitsInStock = unitsInStock
            };

            this.data.Products.Add(product);
            this.data.SaveChanges();

            return product.Id;
        }
    }
}
