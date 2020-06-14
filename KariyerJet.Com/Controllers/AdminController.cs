using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KariyerJet.Com.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KariyerJet.Com.Controllers
{
    [Route("admin")]
    [Authorize("RegisteredUsersOnly")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext ctx;
        public AdminController(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }
        public IActionResult Index()
        {
            var user = ctx.ApplicationUsers.Include(x => x.UserContact).Include(x => x.UserEducation).Include(x => x.UserExperiance).Include(x => x.UserOccupation).Include(x => x.UserReference).SingleOrDefault();
            return View(model:user);
        }
    }
}
