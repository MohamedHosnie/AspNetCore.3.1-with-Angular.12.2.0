using Microsoft.AspNetCore.Mvc;

namespace ElectronicsShop.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
