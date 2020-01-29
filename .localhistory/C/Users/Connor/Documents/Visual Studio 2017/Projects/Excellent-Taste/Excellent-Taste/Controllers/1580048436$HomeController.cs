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
        bool LoginFailed;

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

            if (HttpContext.Session.GetString("UserId") != null)
            {
                ViewData["Message"] = "Your application description page.";
                return View();
            }

            return RedirectToAction("Login", "Home"); 
        }

        public IActionResult CheckLogin(LoginViewModel LoginViewModel)
        {
            Queries Checklogin = new Queries();
            Checklogin.LoginAllowed(LoginViewModel);

            int CompareID = Checklogin.LoginAllowed(LoginViewModel);
            if ( CompareID != -1)
            {
                LoginFailed = false;
                HttpContext.Session.SetString("UserId", CompareID.ToString());
                return RedirectToAction("Index", "Home");
            }

            LoginFailed = true;
            return RedirectToAction("Login", "Home");
        }

        public IActionResult CreateUser(CreateUserViewModel CreateUserViewModel)
        {
            Queries CreateUser = new Queries();
            CreateUser.UserCreation(CreateUserViewModel);




            return RedirectToAction("UserControl", "Home");
        }

        public IActionResult UserControl()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                return View();
            }

            return RedirectToAction("Login", "Home");
          
        }

        public IActionResult Login()
        {
            HttpContext.Session.Remove("UserId");

            if (LoginFailed == true)
            {
                ViewData["Message"] = "Login Failed";
                return View();
            }
            return View();
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Session.GetString("UserId") != null)
            {
                ViewData["Message"] = "Your contact page.";
                return View();
            }

            return RedirectToAction("Login", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
