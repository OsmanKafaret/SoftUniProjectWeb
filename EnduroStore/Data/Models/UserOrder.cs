using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Data.Models
{
    public class UserOrder
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public decimal? TotalPrice { get; set; }
        public DateTime? OrderDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
