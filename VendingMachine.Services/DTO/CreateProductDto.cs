using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachine.Services.DTO
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Product name is required")]
        [MinLength(2, ErrorMessage = "Product Name can not be less than two characters")]
        [MaxLength(240, ErrorMessage = "Product Name to long")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product code is required")]
        public string ProductCode { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "CategoryId is required")]
        public int CategoryTypeId { get; set; }
    }
}
