using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Data.Models
{
    public class Category
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; init; } = new List<Product>();
    }
}
