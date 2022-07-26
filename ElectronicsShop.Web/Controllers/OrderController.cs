using Microsoft.AspNetCore.Mvc;

namespace ElectronicsShop.Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
