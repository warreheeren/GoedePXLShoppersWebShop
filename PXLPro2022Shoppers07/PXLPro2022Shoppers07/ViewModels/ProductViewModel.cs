using System.Collections.Generic;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int ProductImageId { get; set; }
        public List<ProductImage> ProductImage { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
