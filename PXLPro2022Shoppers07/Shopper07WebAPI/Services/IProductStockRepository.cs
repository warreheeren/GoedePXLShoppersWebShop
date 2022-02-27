using System.Collections.Generic;
using PXLPro2022Shoppers07.Shared;

namespace Shopper07WebAPI.Services
{
    public interface IProductStockRepository
    {
        ProductStock CheckProductStock(int ProductStockId);
        bool IsProductInStock(int ProductStockId);
        ProductStock ChangeProductStock(ProductStock productStock, int amount);
        IEnumerable<ProductStock> GetProductStocks();

        bool Save();
    }
}
