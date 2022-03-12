using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using PXLPro2022Shoppers07.Data;
using PXLPro2022Shoppers07.Models;
using System.Linq;

namespace PXLPro2022Shoppers07.Services
{
    public class FavoriteProductRepository : IFavoriteProductRepository
    {
        private appDbContext _context;
        public FavoriteProductRepository(appDbContext context)
        {
            _context = context;
        }

        public void CreateFavoriteProduct(Product product, string IdentityUserId)
        {
            var favoriteproduct = _context.Favorites.Include(x => x.Products).ThenInclude(x => x.ProductImage)
                .FirstOrDefault(x => x.IdentityUserId == IdentityUserId);

            if (favoriteproduct == null)
            {
                var newFavoriteProduct = new FavoriteProduct
                {
                    IdentityUserId = IdentityUserId,
                    Products = new List<Product> {product},
                };
                _context.Favorites.Add(newFavoriteProduct);
            }
            else
            {
                favoriteproduct.Products.Add(product);
                _context.Favorites.Update(favoriteproduct);
            }

            _context.SaveChanges();
        }



        public void RemoveProduct(Product product, string identityUserId)
        {
            var x = _context.Favorites.FirstOrDefault(x => x.IdentityUserId == identityUserId);
            x.Products.Remove(product);
            _context.Favorites.Update(x);
            _context.SaveChanges();
        }

        public FavoriteProduct GetFavoriteProducts(string IdentityUserid)
        {
            var favoriteProducts = _context.Favorites.Include(x => x.Products).ThenInclude(x => x.ProductImage)
                .FirstOrDefault(x => x.IdentityUserId == IdentityUserid);
            if (favoriteProducts == null)
            {
                var newFavoriteProduct = new FavoriteProduct
                {
                    IdentityUserId = IdentityUserid,
                    Products = new List<Product>(),
                };
                return newFavoriteProduct;
            }
            return favoriteProducts;
        }
    }
}
