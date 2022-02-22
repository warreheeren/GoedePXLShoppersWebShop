using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PXLPro2022Shoppers07.Data;
using PXLPro2022Shoppers07.Models;
using PXLPro2022Shoppers07.Services;

namespace PXLPro2022Shoppers07.Controllers
{
    public class TestController : Controller
    {
        IProductRepository _productRepository;
        IShoppingCartRepository _shoppingCartRepository;
        UserManager<IdentityUser> _userManager;

        public TestController( IProductRepository productRepository,IShoppingCartRepository shoppingCartRepository,UserManager<IdentityUser> userManager)
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
