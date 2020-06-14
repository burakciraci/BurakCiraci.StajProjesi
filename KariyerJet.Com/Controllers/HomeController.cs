using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KariyerJet.Com.Models;
using KariyerJet.Com.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace KariyerJet.Com.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext ctx;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            ctx = context;
            _logger = logger;
        }

        public IActionResult Index()
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
        public PartialViewResult ProfileLeft()
        {
            var user = ctx.ApplicationUsers.Include(x => x.UserContact).Include(x => x.UserReference).SingleOrDefault();
            return PartialView("~/Views/Home/Partial/ProfileLeft.cshtml", model: user);
        }
        public PartialViewResult ProfileRight()
        {
            var user = ctx.ApplicationUsers.Include(x => x.UserEducation).Include(x => x.UserExperiance).Include(x => x.UserOccupation).SingleOrDefault();
            return PartialView("~/Views/Home/Partial/ProfileRight.cshtml", model: user);
        }
    }
}
