using Microsoft.AspNetCore.Mvc;
using PXLPro2022Shoppers07.Data;
using PXLPro2022Shoppers07.Services;

namespace PXLPro2022Shoppers07.Controllers
{
    public class TestController : Controller
    {
        appDbContext _context;
        IProductRepository _productRepository;
        public TestController(appDbContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var product = _productRepository.AllProducts;


            return View(product);
        }
    }
}
