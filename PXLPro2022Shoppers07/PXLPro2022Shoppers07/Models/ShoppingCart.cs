using System.Collections.Generic;

namespace PXLPro2022Shoppers07.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public string IdentityUserId { get; set; }
        public virtual List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();
    }
}
