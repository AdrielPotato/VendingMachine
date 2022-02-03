using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachine.Services.DTO
{
    public class UpdateProductDto
    {
        public string ProductCode { get; set; }
        [Required]
        public int QtyStock { get; set; }
    }
}
