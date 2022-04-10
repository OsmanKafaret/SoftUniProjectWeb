using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Services.Products.Models
{
    public class ProductServiceModel
    {
        public int Id { get; init; }

        public string Brand { get; init; }

        public string Model { get; init; }

        public string ImageUrl { get; init; }

      //  public int Year { get; init; }

        public string CategoryName { get; init; }
        public decimal Price  { get; set; }

          public string IsAvialable { get; init; }
        public int UnitsInStock { get; set; }
    }
}
