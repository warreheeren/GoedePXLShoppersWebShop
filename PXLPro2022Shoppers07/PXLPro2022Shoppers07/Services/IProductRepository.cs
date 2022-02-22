using System.Collections.Generic;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.Services
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        void GetProductById(int productId);
    }
}
