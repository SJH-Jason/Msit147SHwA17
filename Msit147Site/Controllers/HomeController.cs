﻿using Microsoft.AspNetCore.Mvc;
using Msit147Site.Models;
using System.Diagnostics;

namespace Msit147Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DemoContext _context;

        public HomeController(ILogger<HomeController> logger,DemoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {  //作業一
            return View();
        }

        public IActionResult Fetch()
        {
            return View();
        }

        public IActionResult Register()
        {  //作業五
            return View();
        }

        public IActionResult AjaxEvent()
        {
            return View();
        }

        public IActionResult First()
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

        public IActionResult jQuery()
        {  
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult ShipperCors()
        {
            return View();
        }

        public IActionResult ShipperCorsEmpty()
        {
            return View();
        }

    }
}