using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace BooklyBookStoreApp.Ui.Controllers
{
    public class UserController : Controller
    {
        public IActionResult RegisterPage()
        {
            return View();
        }
        public IActionResult LoginPage()
        {
            return View();
        }
     


    }
}
