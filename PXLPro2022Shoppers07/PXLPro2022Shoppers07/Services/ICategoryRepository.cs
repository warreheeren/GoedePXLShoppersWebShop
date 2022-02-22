using System.Collections.Generic;
using PXLPro2022Shoppers07.Models;

namespace PXLPro2022Shoppers07.Services
{
    public interface ICategoryRepository
    {
        IEnumerable<Product> FilterCategory(string category);
    }
}
