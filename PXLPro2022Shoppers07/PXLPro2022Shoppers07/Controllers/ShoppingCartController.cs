using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
using Stripe;
using Stripe.Checkout;
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
        public async Task<IActionResult> Index()
        {
            var userid = _userManager.GetUserId(User);
            var cart = _shoppingCartRepository.GetShoppingCart(userid);
            var shoppincartviewmodel = new ShoppingCartViewModel
            {
                ShoppingCart = cart,
                ShoppingCartTotal = _shoppingCartRepository.GetShoppingCartTotal(userid),
            };
            return View(shoppincartviewmodel);
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
                    _shoppingCartRepository.AddToCart(selectedProduct, 1, userid);
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("Product", "Product Not in Stock");

            }
            else
            {
                ModelState.AddModelError("Blabla", "Bla bla");
            }

            return RedirectToAction("Products", "Product");
        }

        public async Task<IActionResult> RemoveProduct(int id)
        {
            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(x => x.ProductId == id);

            var userid = _userManager.GetUserId(User);

            _shoppingCartRepository.RemoveProduct(selectedProduct, userid);
            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Purchase() => RedirectToAction("pay","Payment");
        
    }
}
