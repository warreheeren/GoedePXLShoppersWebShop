<<<<<<< HEAD
﻿namespace PXLPro2022Shoppers07.Models
=======
﻿using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace PXLPro2022Shoppers07.Models
>>>>>>> Emre
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; }
<<<<<<< HEAD
        public virtual Product Product { get; set; }
=======
        public Product Product { get; set; }
>>>>>>> Emre
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
