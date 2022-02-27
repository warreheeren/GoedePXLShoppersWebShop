using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;
using PXLPro2022Shoppers07.Models;
using PXLPro2022Shoppers07.Services;
using PXLPro2022Shoppers07.Shared;
using PXLPro2022Shoppers07.ViewModels;
using RestSharp;

namespace PXLPro2022Shoppers07.Controllers
{
    public class ShoppingCartController : Controller
    {
        IProductRepository _productRepository;
        IShoppingCartRepository _shoppingCartRepository;
        IOrderRepository _orderRepository;
        UserManager<UserDetails> _userManager;
      
        public ShoppingCartController(IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository, IOrderRepository orderRepository, UserManager<UserDetails> userManager)
        {
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _orderRepository = orderRepository;
            _userManager = userManager;
        }


        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public async Task<IActionResult> Index()
        {
            var userid = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userid);

            var cart = _shoppingCartRepository.GetShoppingCart(userid);
            if (cart != null)
            {
                var shoppincartviewmodel = new ShoppingCartViewModel
                {
                    ShoppingCart = cart,
                    ShoppingCartTotal = _shoppingCartRepository.GetShoppingCartTotal(userid),
                };
                return View(shoppincartviewmodel);

            }

            return View();
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var client = new RestClient($"https://localhost:5001/api/stock/{id}");
            var request = new RestRequest(Method.GET);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(x => x.ProductId == id);
            var response = client.Execute(request);

            var data = JsonConvert.DeserializeObject<ProductStock>(response.Content);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                if (data.InStock)
                {
                    var userid = _userManager.GetUserId(User);
                    var user = await _userManager.FindByIdAsync(userid);
                    _shoppingCartRepository.AddToCart(selectedProduct, 1, userid);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("Product", "Product Not in Stock");

            }
            else
            {
                ModelState.AddModelError("Blabla", "Bla bla");
            }

            return RedirectToAction("Index", "Test");
        }

        public async Task<IActionResult> RemoveProduct(int id)
        {
            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(x => x.ProductId == id);

            var userid = _userManager.GetUserId(User);

            _shoppingCartRepository.RemoveProduct(selectedProduct, userid);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Purchase()
        {
            var userid = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userid);

            var cart = _shoppingCartRepository.GetShoppingCart(userid);
            _orderRepository.Purchase(cart, user);
            return RedirectToAction("Index");
        }



    }
}
