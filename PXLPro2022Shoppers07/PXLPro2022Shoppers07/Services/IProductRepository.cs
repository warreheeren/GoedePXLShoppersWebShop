using System.Collections.Generic;
using System.Threading.Tasks;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.Services
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        IEnumerable<Product> GetOnlyProduct { get; }
        Task<Product> GetProductById(int productId);
        IEnumerable<Product> GetProductByName(string productName);
        //IEnumerable<Review> GetReviews(int reviewId);

        Task<bool> AddReviewToProduct(Review review, int productId);
    }
}
