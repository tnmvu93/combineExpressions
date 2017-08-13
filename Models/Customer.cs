using System.Collections.Generic;

namespace LinqSearchTest.Models
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        public virtual IList<Order> Orders { get; set; }
    }
}
