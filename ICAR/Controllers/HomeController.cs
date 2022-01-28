using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ICAR.Models;
using Microsoft.AspNetCore.Authorization;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Hosting;

namespace ICAR.Controllers
{
    [Authorize]
    [BreadCrumb(Title = "Home", UseDefaultRouteUrl = true, Order = 0, IgnoreAjaxRequests = true)]
    public class HomeController : Controller
    {
        private IHostingEnvironment hostingEnv;
        private readonly ICARContext _context;

        public HomeController(ICARContext context, IHostingEnvironment env)
        {
            _context = context;
            this.hostingEnv = env;
        }

        [BreadCrumb(Title = "Index", Order = 1, IgnoreAjaxRequests = true)]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
