using Microsoft.AspNetCore.Identity;
using System;

namespace PXLPro2022Shoppers07.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewDescription { get; set; }
        public string ReviewTitle { get; set; }
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int UserId { get; set; }
        public UserDetails UserDetails { get; set; }
    }
}
