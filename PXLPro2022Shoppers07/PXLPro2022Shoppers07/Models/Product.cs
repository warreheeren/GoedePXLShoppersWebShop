using System.Collections.Generic;


using Microsoft.AspNetCore.Identity;


namespace PXLPro2022Shoppers07.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public virtual List<ProductImage> ProductImage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public virtual List<Review> Review { get; set; }

    }
}
