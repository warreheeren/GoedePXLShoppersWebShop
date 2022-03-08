using System;
using System.Collections.Generic;


using Microsoft.AspNetCore.Identity;


namespace PXLPro2022Shoppers07.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        public decimal NewPrice { get; set; }
        public string ProductDescription { get; set; }
        public TypeProduct ProductType { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<ProductImage> ProductImage { get; set; }
        public virtual List<ProductSpecifications> Specifications { get; set; }
    }
}
