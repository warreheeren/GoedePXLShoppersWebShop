using Microsoft.AspNetCore.Mvc;

namespace PXLPro2022Shoppers07.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
