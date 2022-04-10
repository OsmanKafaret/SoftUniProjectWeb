using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnduroStore.Models.Products
{
    public class AddProductFormModel
    {

      

        public string Brand { get; set; }
      
        public string Model { get; set; }
        [Display(Name = "Image URL")]
        [Url]
        public string ImageUrl { get; set; }
        [Range(0.05, 9999)]
        public decimal Price { get; set; }
       [Required]
        public string Description { get; set; }
      
        public string IsAvialable { get; set; }
      //  public string Size { get; set; }
        public int UnitsInStock { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<ProductCategoriesViewModel> Categories { get; set; } = new List<ProductCategoriesViewModel>();
    }
}
