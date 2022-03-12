using System.ComponentModel.DataAnnotations;

namespace PXLPro2022Shoppers07.Models
{
    public class Pay
    {
        [Required]
        public string CustomerName { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string CardNumder { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string CVC { get; set; }

        public long Amount { get; set; }
    }
}
