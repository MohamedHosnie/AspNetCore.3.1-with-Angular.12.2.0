using ElectronicsShop.Mvc.Models;
using ElectronicsShop.Mvc.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ElectronicsShop.Mvc.Controllers
{
    public class AccountController : BaseController
    {
        private readonly ISession _session;
        public AccountController(ISession session)
        {
            _session = session;
        }

        public ActionResult Login()
        {
            ViewBag.Anonymous = true;
            ViewData["Title"] = "Login";

            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            _session.LoggedInUser = user;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            ViewBag.Anonymous = true;
            ViewData["Title"] = "Register";

            return View();
        }

        public ActionResult Logout()
        {
            _session.LoggedInUser = null;
            return RedirectToAction("Index", "Home");
        }
    }
}
