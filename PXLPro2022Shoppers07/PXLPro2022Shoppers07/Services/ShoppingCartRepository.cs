using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PXLPro2022Shoppers07.Data;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.Services
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private appDbContext _context;
        public ShoppingCartRepository(appDbContext context)
        {
            _context = context;
        }

        public ShoppingCart GetShoppingCart(string IdentityUserId)
        {
            var cart = _context.ShoppingCarts.Include(x => x.ShoppingCartItems).ThenInclude(x => x.Product).ThenInclude(x => x.ProductImage).FirstOrDefault(x => x.IdentityUserId == IdentityUserId);
            if (cart == null)
            {
                var shoppingcart = new ShoppingCart();
                shoppingcart.IdentityUserId = IdentityUserId;
                _context.ShoppingCarts.Add(shoppingcart);
                _context.SaveChanges();
                return shoppingcart;
            }
            return cart;
        }

        public void RemoveProduct(Product product, string identityUserId)
        {
            var userShoppingCart = GetShoppingCart(identityUserId);

            var x = userShoppingCart.ShoppingCartItems.FirstOrDefault(x => x.Product.ProductId == product.ProductId);

            _context.ShoppingCartItems.Remove(x);
            _context.SaveChanges();
        }


        public void AddToCart(Product product, int amount, string IdentityUserId)
        {
            var userShoppingCart = GetShoppingCart(IdentityUserId);
            if (userShoppingCart == null)
            {
                var shoppingCartItem = new ShoppingCartItem
                {
                    Amount = amount,
                    Product = product,
                };

                var shoppingCart = new ShoppingCart
                {
                    IdentityUserId = IdentityUserId,
                    ShoppingCartItems = new List<ShoppingCartItem> {shoppingCartItem},
                };
                _context.ShoppingCarts.Add(shoppingCart);
            }
            else
            {
                var test = userShoppingCart.ShoppingCartItems.FirstOrDefault(x => x.Product.ProductId == product.ProductId);

                if (test != null)
                {
                    test.Amount += amount;
                }
                else
                {

                    var shoppingCartItem = new ShoppingCartItem
                    {
                        Amount = amount,
                        Product = product,
                    };
                    userShoppingCart.ShoppingCartItems.Add(shoppingCartItem);
                }

            }
            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal(string identityUserId)
        {
            return _context.ShoppingCarts.Include(x => x.ShoppingCartItems).ThenInclude(x => x.Product)
                .FirstOrDefault(x => x.IdentityUserId == identityUserId).ShoppingCartItems
                .Select(x => x.Product.Price * x.Amount).Sum();
        }

    }
}
