using System;
using System.ComponentModel.DataAnnotations;

namespace PXLPro2022Shoppers07.ViewModels
{
    public class RegisterViewModel
    {
        public int id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "paswoord moet overeenkomen!")]
        public string ConfirmPassword { get; set; }
        public string RoleId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public int HouseNumber { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
