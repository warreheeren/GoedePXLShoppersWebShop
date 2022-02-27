
﻿using System;
 using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;


namespace PXLPro2022Shoppers07.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderDate { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public virtual UserDetails IdentityUser { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
