using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Models.ShoppingCart
{
    public class OrderHistoryListingModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? OrderDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
