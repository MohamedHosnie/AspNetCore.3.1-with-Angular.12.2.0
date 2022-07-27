using ElectronicsShop.Shared.Enums;
using ElectronicsShop.Web.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsShop.Web.Controllers
{
    public class OrderController : BaseController
    {
        public ISession _session;
        public OrderController(ISession session)
        {
            _session = session;
        }

        public IActionResult Index()
        {
            if(_session.LoggedInUser == null) return NotFound();
            if (RoleName.GetEnum(_session.LoggedInUser.Role) != Role.Admin) return NotFound();
            ViewData["Title"] = "Manage Orders";

            return View();
        }

        public IActionResult Create()
        {
            if (_session.LoggedInUser == null) return NotFound();
            ViewData["Title"] = "Add Order";

            return View();
        }
    }
}
