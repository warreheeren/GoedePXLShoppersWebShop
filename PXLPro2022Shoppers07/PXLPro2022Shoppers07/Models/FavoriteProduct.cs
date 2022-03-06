using System.Collections.Generic;

namespace PXLPro2022Shoppers07.Models
{
    public class FavoriteProduct
    {
        public int FavoriteProductId { get; set; }
        public string IdentityUserId { get; set; }
        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
