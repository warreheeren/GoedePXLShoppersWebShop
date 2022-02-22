using Microsoft.AspNetCore.Mvc;

namespace Shopper07WebAPI.Controllers
{
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
