using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Models.Products
{
    public class ProductListingViewModel
    {
        public string ImageUrl { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
        public string IsAvialable { get; set; }
        public int Id { get; set; }

    }
}
