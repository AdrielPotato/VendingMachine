using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachine.Services.DTO
{
    public class ProductDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductCode { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9._@+-]{2,240}",
              ErrorMessage = "The {0} must be 1 to 240 valid characters which are any digit, any letter and -._@+.")]
        [StringLength(150, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [Display(Name = "ProductName")]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int QtyStock { get; set; }
        public int CategoryTypeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
