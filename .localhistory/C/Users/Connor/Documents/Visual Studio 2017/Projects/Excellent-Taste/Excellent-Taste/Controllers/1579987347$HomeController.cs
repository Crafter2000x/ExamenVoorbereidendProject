﻿using System;
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
            return View();
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
            if (Checklogin.LoginAllowed(loginViewModel))
                {
                return RedirectToAction("Index", "Home");
            }
            
            return RedirectToAction("Login", "Home");

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
