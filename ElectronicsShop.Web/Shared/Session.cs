using ElectronicsShop.Web.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;

namespace ElectronicsShop.Web.Shared
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Session(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public User LoggedInUser { 
            get {
                string userString = _httpContextAccessor.HttpContext.Session.GetString("LoggedInUser");
                if(String.IsNullOrEmpty(userString)) return null;
                return JsonConvert.DeserializeObject<User>(userString);
            } 
            set {
                if(value == null)
                {
                    _httpContextAccessor.HttpContext.Session.Remove("LoggedInUser");
                } else
                {
                    var userString = JsonConvert.SerializeObject(value);
                    _httpContextAccessor.HttpContext.Session.SetString("LoggedInUser", userString);
                }
            }
        }
    }
}
