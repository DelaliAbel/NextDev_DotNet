using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NextDev_DotNet.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace NextDev_DotNet.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult LogOut()
        {
            // Déconnexion de l'utilisateur
            HttpContext.SignOutAsync(IdentityConstants.ApplicationScheme).Wait();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
