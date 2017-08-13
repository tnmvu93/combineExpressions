using System;
using System.Collections.Generic;

namespace LinqSearchTest.Models
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        public decimal TotalAmount { get; set; }

        public virtual IList<OrderItem> OrderItems { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
