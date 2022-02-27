using System.Collections.Generic;
using System.Linq;
using PXLPro2022Shoppers07.Shared;
using Shopper07WebAPI.Data;

namespace Shopper07WebAPI.Services
{
    public class ProductStockRepository : IProductStockRepository
    {
        appDbContext _context;
        public ProductStockRepository(appDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductStock> GetProductStocks()
        {
            return _context.ProductStocks;
        }

        public bool IsProductInStock(int ProductStockId)
        {
            var products = _context.ProductStocks.FirstOrDefault(x => x.ProductStockId == ProductStockId);
            return products.InStock;
        }

        public ProductStock CheckProductStock(int ProductStockId)
        {
      
                var product = _context.ProductStocks.FirstOrDefault(x => x.ProductStockId == ProductStockId);
                return product;
          
        }


        public ProductStock ChangeProductStock(ProductStock productStock, int amount)
        {
            if (IsProductInStock(productStock.ProductStockId))
            {
                var product = _context.ProductStocks.FirstOrDefault(x => x.ProductStockId == productStock.ProductStockId);
                if (product.Amount >= amount)
                {
                    product.Amount -= amount;
                    _context.ProductStocks.Update(product);
                    _context.SaveChanges();
                    return product;
                }
                else
                {
                    return product;
                }

            }
            return null;
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

    }
}
