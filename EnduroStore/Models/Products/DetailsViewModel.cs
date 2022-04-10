using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Models.Products
{
    public class DetailsViewModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public string Description { get; set; }
        public string IsAvialable { get; set; }
        public int UnitsInStock { get; set; }
    }
}
