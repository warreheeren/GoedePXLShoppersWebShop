using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace PXLPro2022Shoppers07.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
        public virtual UserDetails IdentityUser { get; set; }


        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
