using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Services.Products.Models
{
    public class ProductQueryServiceModel
    {
        public int CurrentPage { get; init; }

        public int CarsPerPage { get; init; }

        public IEnumerable<ProductServiceModel> Products { get; set; }
    }
}
