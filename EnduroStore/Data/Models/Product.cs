using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(40)]
        public string Model { get; set; }
        public string ImageUrl { get; set; }
        [Range(1.00, 10000)]
        public decimal Price { get; set; }
        [Required]
        [MaxLength(15000)]
        public string Description { get; set; }
        public bool IsAvialable { get; set; }
        public string Size { get; set; }
        public int UnitsInStock { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
