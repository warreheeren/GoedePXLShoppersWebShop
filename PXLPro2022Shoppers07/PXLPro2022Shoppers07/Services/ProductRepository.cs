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


        public IEnumerable<Product> AllProducts => _context.Products.Include(x => x.Category).Include(x => x.ProductImage);

        public void GetProductById(int ProductId) => _context.Products.FirstOrDefault(x => x.ProductId == ProductId);
    }
}
