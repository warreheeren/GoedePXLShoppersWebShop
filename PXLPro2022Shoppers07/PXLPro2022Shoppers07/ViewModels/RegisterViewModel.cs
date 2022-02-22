using System.ComponentModel.DataAnnotations;

namespace PXLPro2022Shoppers07.ViewModels
{
    public class RegisterViewModel
    {
        public int id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "paswoord moet overeenkomen!")]
        public string ConfirmPassword { get; set; }
        public string RoleId { get; set; }
    }
}
