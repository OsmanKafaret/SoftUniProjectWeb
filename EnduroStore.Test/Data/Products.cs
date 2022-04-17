using EnduroStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnduroStore.Test.Data
{
    public static class Products
    {
        public static IEnumerable<Product> TenUnfinishedProducts
           => Enumerable.Range(0, 10).Select(i => new Product
           {
               UnitsInStock = 5
           });

        public static IEnumerable<Product> TenfinishedProducts
          => Enumerable.Range(0, 10).Select(i => new Product
          {
              UnitsInStock = 0
          });
    }
}
