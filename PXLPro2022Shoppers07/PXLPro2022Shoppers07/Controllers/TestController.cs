using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PXLPro2022Shoppers07.Models;
using PXLPro2022Shoppers07.Services;

namespace PXLPro2022Shoppers07.Controllers
{
    public class TestController : Controller
    {
        IProductRepository _productRepository;
        IShoppingCartRepository _shoppingCartRepository;

        UserManager<UserDetails> _userManager;

        public TestController( IProductRepository productRepository,IShoppingCartRepository shoppingCartRepository,UserManager<UserDetails> userManager)
        {
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var product = _productRepository.AllProducts;
            return View(product);
        }

        public IActionResult Details(int id)
        {
            var product = _productRepository.GetProductById(id);


            return View(product);
        }

      
    }
}
