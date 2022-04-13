using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Models.ShoppingCart
{
    public class MyBasketListingModel
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public int Id { get; set; }
    }
}
