using EnduroStore.Data;
using EnduroStore.Data.Models;
using EnduroStore.Models.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EnduroStore.InfraStructure;

namespace EnduroStore.Areas.Admin.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly EnduroStoreDbContext db;
        private readonly RoleManager<IdentityRole> roleManager;

        public ShoppingCartController(SignInManager<User> signInManager, UserManager<User> userManager, EnduroStoreDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
        }
        public IActionResult MyBasket() 
        {
            var getProducts = this.db.ShoppingCarts.Where(x => x.UserId == this.User.Id()).ToList();

            var products = new List<ProductListingViewModel>();

            if(getProducts.Count != 0)
            {
                foreach (var item in getProducts)
                {
                    var product = this.db.Products.Where(x => x.Id == item.ProductId)
                        .Select(x => new ProductListingViewModel
                        {
                            ImageUrl = x.ImageUrl,
                            Brand = x.Brand,
                            Model = x.Model,
                            Price = x.Price,
                            Id = x.Id
                        }).FirstOrDefault();

                    products.Add(product);
                }
            }



            return View(products);
          
        }

        public IActionResult AddToBasket(int id)
        {

            var userId = this.User.Id();

            var cart = new ShoppingCart
            {
                ProductId = id,
                UserId = userId
            };

            this.db.ShoppingCarts.Add(cart);
          

            this.db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            var shopItem = this.db.ShoppingCarts.Where(x => x.ProductId == id).FirstOrDefault();

            this.db.ShoppingCarts.Remove(shopItem);

            this.db.SaveChanges();

            return RedirectToAction("AddToBasket", "ShoppingCart");

        }

     
    }
}
