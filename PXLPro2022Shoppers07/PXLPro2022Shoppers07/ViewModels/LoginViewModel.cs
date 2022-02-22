using System.ComponentModel.DataAnnotations;

namespace PXLPro2022Shoppers07.ViewModels
{
    public class LoginViewModel
    {
        public int id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
