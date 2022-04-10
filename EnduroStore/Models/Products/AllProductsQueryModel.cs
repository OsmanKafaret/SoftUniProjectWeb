using EnduroStore.Services.Products.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Models.Products
{
    public class AllProductsQueryModel
    {
        public const int ProductsPerPage = 8;

        public string Brand { get; set; }
        public IEnumerable<string> Brands { get; set; }
        [Display(Name = "Search by text")]
        public string SearchTerm { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalProducts { get; set; }
        public ProductSorting Sorting { get; set; }
        public IEnumerable<ProductServiceModel> Products { get; set; }
    }
}
