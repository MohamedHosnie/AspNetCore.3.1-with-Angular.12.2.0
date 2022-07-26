using ElectronicsShop.Web.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;

namespace ElectronicsShop.Web.Filters
{
    public class GlobalActionFilter : IActionFilter
    {
        public readonly IConfiguration _configuration;
        public readonly ISession _session;
        public GlobalActionFilter(IConfiguration configuration, ISession session)
        {
            _configuration = configuration;
            _session = session;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            (context.Controller as Controller).ViewBag.ApiBaseUrl = _configuration.GetSection("AppSettings:ApiBaseUrl").Value;

            var user = _session.LoggedInUser;
            if(user != null)
            {
                (context.Controller as Controller).ViewBag._LoggedIn = true;
                (context.Controller as Controller).ViewBag._Id = user.Id;
                (context.Controller as Controller).ViewBag._Username = user.Username;
                (context.Controller as Controller).ViewBag._FullName = user.FullName;
                (context.Controller as Controller).ViewBag._Role = user.Role;
            }
        }
    }
}
