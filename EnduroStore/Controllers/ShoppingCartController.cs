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
using Microsoft.AspNetCore.Authorization;
using EnduroStore.Models.ShoppingCart;

namespace EnduroStore.Areas.Admin.Controllers
{
    using static WebConstants;
    public class ShoppingCartController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly EnduroStoreDbContext db;
        private readonly RoleManager<IdentityRole> roleManager;


        public int GlobalMessageKey { get; private set; }

        public ShoppingCartController(SignInManager<User> signInManager, UserManager<User> userManager, EnduroStoreDbContext db)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.db = db;
        }
        [Authorize]
        public IActionResult MyBasket() 
        {
            var getProducts = this.db.ShoppingCarts.Where(x => x.UserId == this.User.Id()).ToList();

            var products = new List<ProductListingViewModel>();

           
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
                return View(products);
           
          
        }
        [Authorize]
        public IActionResult AddToBasket(int id)
        {

            var user = this.db.Users.Where(x => x.Id == this.User.Id()).FirstOrDefault();

            var product = this.db.Products.Where(x => x.Id == id).FirstOrDefault();

            var shoppingCart = new ShoppingCart
            {
                User = user,
                Product = product
            };

            product.UnitsInStock -= 1;


            this.db.ShoppingCarts.Add(shoppingCart);
          

            this.db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public IActionResult Checkout()
        {
      

            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Checkout(CheckoutFormModel x)
        {

            var totalSum = 0m;

            var userProducs = this.db.ShoppingCarts.Where(x => x.UserId == this.User.Id()).ToList();

            foreach (var item in userProducs)
            {
                var product = this.db.Products.Where(x => x.Id == item.ProductId).FirstOrDefault();

                totalSum += product.Price;
            }

            var user = this.db.Users.Where(x => x.Id == this.User.Id()).FirstOrDefault();

         //  var userOrder = new UserOrder
         //  {
         //      Name = x.Name,
         //      SurName = x.Surname,
         //      TotalPrice = totalSum,
         //      PhoneNumber = x.PhoneNumber,
         //      Address = x.Address,
         //      OrderDate = DateTime.UtcNow,
         //      User = user
         //  };
         //
         //  this.db.UserOrders.Add(userOrder);

            this.db.ShoppingCarts.RemoveRange(userProducs);

            this.db.SaveChanges();

            // TempData[GlobalMessageKey] = "asasa";
            // TempData[GlobalMessageKey] = "asasa";
            // TempData[GlobalMessageKey] = "asasa";
            // TempData[GlobalMessageKey] = "asasa";
            // TempData[GlobalMessageKey] = "asasa";

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {


            var shopItem = this.db.ShoppingCarts.Where(x => x.ProductId == id && x.UserId == this.User.Id()).Select(x => x.Id).FirstOrDefault();

            var deleted = this.db.ShoppingCarts.Where(x => x.Id == shopItem).FirstOrDefault();

            var product = this.db.Products.Where(x => x.Id == id).FirstOrDefault();

            product.UnitsInStock += 1;

           this.db.ShoppingCarts.Remove(deleted);
          

            this.db.SaveChanges();

            return RedirectToAction("MyBasket", "ShoppingCart");

        }

       // [Authorize]
       public IActionResult UserOrderHistory()
       {
           var userOrderHistory = this.db.UserOrders.Where(x => x.UserId == this.User.Id()).Select(x => new OrderHistoryListingModel
           {
               Name = x.Name,
               SurName = x.SurName,
               TotalPrice = x.TotalPrice,
               OrderDate = x.OrderDate,
               PhoneNumber = x.PhoneNumber,
               Address = x.Address
           }).ToList();
     
           return View(userOrderHistory);
       }

     
    }
}
