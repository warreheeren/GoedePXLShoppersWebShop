using Microsoft.AspNetCore.Mvc;
using PXLPro2022Shoppers07.Services;

namespace PXLPro2022Shoppers07.Controllers
{
    public class ProductController : Controller
    {

        IProductRepository _productRepository;
        IShoppingCartRepository _shoppingCartRepository;
        ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Products(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                var product = _productRepository.AllProducts;
                return View(product);
            }

            ViewBag.SelectedCategory = category;
            var products = _categoryRepository.FilterCategory(category);
            return View(products);
        }


        public IActionResult Product(int id)
        {
            var product = _productRepository.GetProductById(id);
            return View(product);
        }

        public IActionResult Search(string search)
        {
            var products = _productRepository.GetProductByName(search);
            return Json(products);
        }

        public JsonResult result()
        {
            var products = _productRepository.GetProductByName("Ultra");
            return Json(products);
        }
    }
}
