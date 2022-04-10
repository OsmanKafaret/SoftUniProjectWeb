using EnduroStore.Models.Products;
using EnduroStore.Services.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Services.Products
{
    public interface IProductService
    {
        ProductQueryServiceModel GetProducts(
          string brand = null,
          string searchTerm = null,
          ProductSorting sorting = ProductSorting.PriceASC,
          int currentPage = 1,
          int productsPerPage = int.MaxValue,
          string category = null, bool isFinished = false);

        IEnumerable<string> AllBrands(string category = null);
    }
}
