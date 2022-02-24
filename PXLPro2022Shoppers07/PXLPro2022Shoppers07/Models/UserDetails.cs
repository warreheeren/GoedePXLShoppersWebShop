using Microsoft.AspNetCore.Identity;
using System;

namespace PXLPro2022Shoppers07.Models
{
    public class UserDetails : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
