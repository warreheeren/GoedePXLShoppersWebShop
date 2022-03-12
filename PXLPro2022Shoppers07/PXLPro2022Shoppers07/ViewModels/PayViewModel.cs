using System.ComponentModel.DataAnnotations;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.ViewModels
{
    public class PayViewModel
    {
        [Required]
        public Pay pay { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; set; }

    }
}
