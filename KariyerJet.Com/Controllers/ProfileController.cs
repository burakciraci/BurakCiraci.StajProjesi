using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KariyerJet.Com.Controllers
{
    [Authorize(Policy = "YolunYarisi")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View(); 
        }
    }
}
