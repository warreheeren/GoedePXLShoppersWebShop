using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PXLPro2022Shoppers07.Models;
using PXLPro2022Shoppers07.Services;
using PXLPro2022Shoppers07.ViewModels;

namespace PXLPro2022Shoppers07.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        IPaymentRepository _paymentRepository;
        IShoppingCartRepository _shoppingCartRepository;
        IOrderRepository _orderRepository;
        UserManager<UserDetails> _userManager;
        public PaymentController(IPaymentRepository paymentRepository, IShoppingCartRepository shoppingCartRepository, UserManager<UserDetails> userManager, IOrderRepository orderRepository)
        {
            _paymentRepository = paymentRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _userManager = userManager;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Pay()
        {
            var userid = _userManager.GetUserId(User);
            var total =  _shoppingCartRepository.GetShoppingCartTotal(userid);
            var tax = ((total * 21) / 100);
            var viewmodel = new PayViewModel
            {
                SubTotal = total,
                Tax = tax,
                TotalPrice = total + tax,
            };
            return View(viewmodel);
        }


        [HttpPost]
        public async Task<IActionResult> Pay(PayViewModel payViewModel)
        {
            if (ModelState.IsValid)
            {
                var userid = _userManager.GetUserId(User);
                var user = await _userManager.FindByIdAsync(userid);
                var total = _shoppingCartRepository.GetShoppingCartTotal(userid);
                var tax = ((total * 21) / 100);
                payViewModel.pay.Amount = (long)Math.Round(total + tax);
                var result = await _paymentRepository.Pay(payViewModel.pay);

                if (result)
                {
                    var cart = _shoppingCartRepository.GetShoppingCart(userid);
                    _orderRepository.Purchase(cart,user);
                    return RedirectToAction("Orders","Account");
                }
                else
                {
                    ModelState.AddModelError("Card","There is something wrong with the card");
                }
            }

            return View();
        }


    }
}
