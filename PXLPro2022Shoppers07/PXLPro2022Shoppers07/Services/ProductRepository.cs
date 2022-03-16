using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PXLPro2022Shoppers07.Data;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.Services
{
    public class ProductRepository : IProductRepository
    {
        appDbContext _context;
        public ProductRepository(appDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetOnlyProduct => _context.Products.Include(x => x.ProductImage);


        public IEnumerable<Product> AllProducts => _context.Products.Include(x => x.Category).Include(x => x.ProductImage).Include(x => x.Specifications).Include(x => x.Reviews);

        public async Task<Product> GetProductById(int ProductId) => await _context.Products.Include(x => x.Category).Include(x => x.ProductImage).Include(x => x.Specifications).Include(x => x.Reviews).FirstOrDefaultAsync(x => x.ProductId == ProductId);

        public IEnumerable<Product> GetProductByName(string productName) => _context.Products.Where(x => x.ProductName.Contains(productName)).Include(x => x.ProductImage).Include(x => x.Reviews);
        //public IEnumerable<Review> GetReviews(int reviewId) => _context.Reviews.Where(x => x.ReviewId == reviewId);

        public async Task<bool> AddReviewToProduct(Review review, int productId)
        {
            var product = await _context.Products.Include(p => p.Reviews).FirstOrDefaultAsync(p => p.ProductId == productId);

            if (product == null)
            {
                return false;
            }

            product.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
