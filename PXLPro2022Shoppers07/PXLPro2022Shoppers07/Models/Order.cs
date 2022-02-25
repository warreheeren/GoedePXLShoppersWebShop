<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
>>>>>>> Emre

namespace PXLPro2022Shoppers07.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
<<<<<<< HEAD
        public virtual UserDetails IdentityUser { get; set; }


=======
        public virtual IdentityUser IdentityUser { get; set; }

        
>>>>>>> Emre
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }
}
