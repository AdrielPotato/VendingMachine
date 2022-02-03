using System;
using System.Collections.Generic;

#nullable disable

namespace VendingMachine.Model.Models
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int QtyStock { get; set; }
        public int CategoryTypeId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual CategoryType CategoryType { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
