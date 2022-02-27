using Microsoft.AspNetCore.Mvc;
using PXLPro2022Shoppers07.Services;

namespace PXLPro2022Shoppers07.Controllers
{
    public class ProductController : Controller
    {

        IProductRepository _productRepository;
        IShoppingCartRepository _shoppingCartRepository;

        public ProductController(IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository)
        {
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public IActionResult Products()
        {
            var product = _productRepository.AllProducts;
            return View(product);
        }


        public IActionResult Product(int id)
        {
            var product = _productRepository.GetProductById(id);
            return View(product);
        }
    }
}
