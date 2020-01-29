using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Excellent_Taste.Models;
using Excellent_Taste.Classes;
using Microsoft.AspNetCore.Http;

namespace Excellent_Taste.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("UserId") != null)
            {
                return View();
            }

            return RedirectToAction("Login", "Home");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult CheckLogin(LoginViewModel loginViewModel)
        {
            Queries Checklogin = new Queries();
            Checklogin.LoginAllowed(loginViewModel);

            int CompareID = Checklogin.LoginAllowed(loginViewModel);
            if ( CompareID != -1)
                {
                 HttpContext.Session.SetString("UserId", CompareID.ToString());
                    return RedirectToAction("Index", "Home");
                }   

                return RedirectToAction("Login", "Home");
        }

        public IActionResult Contact()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                ViewData["Message"] = "Your contact page.";
                return View();
            }

            return RedirectToAction("Login", "Home");
          
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
