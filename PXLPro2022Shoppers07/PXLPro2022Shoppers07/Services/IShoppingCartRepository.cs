using System.Collections.Generic;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.Services
{
    public interface IShoppingCartRepository
    { 
        void AddToCart(Product product, int amount, string IdentityUserId);
        ShoppingCart GetShoppingCart(string IdentityUserId);
        decimal GetShoppingCartTotal(string IdentityUserId);
        void RemoveProduct(Product product, string IdentityUserId);
    }
}
