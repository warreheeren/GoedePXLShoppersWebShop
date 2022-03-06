using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PXLPro2022Shoppers07.Models;
using PXLPro2022Shoppers07.Services;

namespace PXLPro2022Shoppers07.Controllers
{
    public class FavoriteProductController : Controller
    {
        IFavoriteProductRepository _favoriteProductRepository;
        UserManager<UserDetails> _userManager;
        IProductRepository _productRepository;

        public FavoriteProductController(IFavoriteProductRepository favoriteProductRepository, UserManager<UserDetails> userManager, IProductRepository productRepository)
        {
            _favoriteProductRepository = favoriteProductRepository;
            _userManager = userManager;
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var userid = _userManager.GetUserId(User);
            var products = _favoriteProductRepository.GetFavoriteProducts(userid);
            return View(products);
        }

        public IActionResult FavoriteProduct(int id)
        {
            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(x => x.ProductId == id);
            var userid = _userManager.GetUserId(User);
            _favoriteProductRepository.CreateFavoriteProduct(selectedProduct, userid);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveProduct(int id)
        {
            var selectedProduct = _productRepository.AllProducts.FirstOrDefault(x => x.ProductId == id);
            var userid = _userManager.GetUserId(User);
            _favoriteProductRepository.RemoveProduct(selectedProduct,userid);
            return RedirectToAction("Index");
        }
    }
}
