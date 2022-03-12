using System.Collections.Generic;
using System.Linq;
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


        public IEnumerable<Product> AllProducts => _context.Products.Include(x => x.Category).Include(x => x.ProductImage).Include(x => x.Specifications);

        public Product GetProductById(int ProductId) => _context.Products.Include(x => x.Category).Include(x => x.ProductImage).Include(x => x.Specifications).FirstOrDefault(x => x.ProductId == ProductId);

        public IEnumerable<Product> GetProductByName(string productName) => _context.Products.Where(x => x.ProductName.Contains(productName)).Include(x => x.ProductImage);
    }
}
