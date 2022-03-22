using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.ViewModels
{
    public class ProductViewModel
    {
        public Product product { get; set; }
        public double AverageReviews { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
