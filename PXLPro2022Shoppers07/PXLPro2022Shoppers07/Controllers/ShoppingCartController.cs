using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PXLPro2022Shoppers07.Models;
using PXLPro2022Shoppers07.Services;
using PXLPro2022Shoppers07.ViewModels;

namespace PXLPro2022Shoppers07.Controllers
{
    public class ShoppingCartController : Controller
    {
        IProductRepository _productRepository;
        IShoppingCartRepository _shoppingCartRepository;
        UserManager<UserDetails> _userManager;
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public ShoppingCartController(IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository, UserManager<UserDetails> userManager)
        {
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //var claimsPrincipal = ViewContext.HttpContext.User;
            //var identityUser = await _userManager.GetUserAsync(claimsPrincipal);
            var cart = _shoppingCartRepository.GetShoppingCart("755afb1a-49f7-4d32-955c-6ec25443d3b0");
            var shoppincartviewmodel = new ShoppingCartViewModel
            {
                ShoppingCart = cart,
                ShoppingCartTotal = _shoppingCartRepository.GetShoppingCartTotal("755afb1a-49f7-4d32-955c-6ec25443d3b0"),
            };

            return View(shoppincartviewmodel);
        }

        
        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            //var claimsPrincipal = ViewContext.HttpContext.User;
            //var identityUser = await _userManager.GetUserAsync(claimsPrincipal);

            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(x => x.ProductId == id);
            _shoppingCartRepository.AddToCart(selectedProduct, 1, "755afb1a-49f7-4d32-955c-6ec25443d3b0");
            return RedirectToAction("Index");
        }


        
    }
}
