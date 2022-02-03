using System;
using System.Collections.Generic;

#nullable disable

namespace VendingMachine.Model.Models
{
    public partial class CategoryType
    {
        public CategoryType()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? SortValue { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
