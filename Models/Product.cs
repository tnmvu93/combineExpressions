using System.Collections.Generic;

namespace LinqSearchTest.Models
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public int SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual IList<OrderItem> OrderItems { get; set; }
    }
}
