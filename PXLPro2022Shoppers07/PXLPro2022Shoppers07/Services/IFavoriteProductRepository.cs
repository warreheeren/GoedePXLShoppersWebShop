using System.Collections.Generic;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.Services
{
    public interface IFavoriteProductRepository
    {
        void CreateFavoriteProduct(Product product, string IdentityUserId);
        FavoriteProduct GetFavoriteProducts(string IdentityUserId);
        void RemoveProduct(Product product, string identityUserId);
    }
}
