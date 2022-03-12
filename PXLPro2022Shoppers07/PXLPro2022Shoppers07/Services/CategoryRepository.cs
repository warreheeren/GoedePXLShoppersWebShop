using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PXLPro2022Shoppers07.Data;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private appDbContext _context;

        public CategoryRepository(appDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> FilterCategory(string category)
        {
            return _context.Products.Include(x => x.Category).Where(x => x.Category.CategoryName == category).Include(x => x.ProductImage).Include(x => x.Specifications);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.Include(x => x.Products).ThenInclude(x => x.ProductImage);
        }
    }
}
