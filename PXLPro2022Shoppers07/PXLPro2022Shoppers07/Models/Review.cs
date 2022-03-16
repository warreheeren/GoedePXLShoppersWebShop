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
        public string Name { get; set; }
        public virtual Product Product { get; set; }
    }
}
