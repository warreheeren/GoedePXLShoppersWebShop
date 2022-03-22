using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PXLPro2022Shoppers07.Data;
using PXLPro2022Shoppers07.Models;
using PXLPro2022Shoppers07.Services;
using PXLPro2022Shoppers07.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PXLPro2022Shoppers07.Controllers
{
    public class ProductController : Controller
    {
        private readonly appDbContext _context;
        IProductRepository _productRepository;
        IShoppingCartRepository _shoppingCartRepository;
        ICategoryRepository _categoryRepository;
        private UserManager<UserDetails> _userManager;

        public ProductController(UserManager<UserDetails> userManager, appDbContext context, IProductRepository productRepository, IShoppingCartRepository shoppingCartRepository, ICategoryRepository categoryRepository)
        {
            _userManager = userManager;
            _context = context;
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

        public async Task<IActionResult> Product(int id)
        {
            var product = await _productRepository.GetProductById(id);
            var viewmodel = new ProductViewModel();
            viewmodel.product = product;
            if (product.Reviews.Count != 0)
            {
                var sum = product.Reviews.Average(x => x.Rating);
                viewmodel.AverageReviews = sum;
                return View(viewmodel);

            }

            return View(viewmodel);
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

        [HttpGet]
        public IActionResult Review()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Review(int id, Review review)
        {
            review = new Review()
            {
                ReviewDate = DateTime.Today,
                ReviewDescription = review.ReviewDescription,
                ReviewTitle = review.ReviewTitle,
                Rating = review.Rating,
                Name = review.Name,
            };
            var result = await _productRepository.AddReviewToProduct(review, id);

            if (result == false)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Product), new { id = id });
        }
    }
}
