using KariyerJet.Com.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Components
{
    public class ProfileLeftComponent : ViewComponent
    {
        private readonly ApplicationDbContext ctx;

        public ProfileLeftComponent(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await ctx.ApplicationUsers.Where(x => x.Id == "0db1d9a7-8ce0-4823-9c8c-11837e7a6a8a").Include(x => x.UserContact).Include(x => x.UserReference).SingleOrDefaultAsync();
            return await Task.FromResult((IViewComponentResult)View("~/Views/Home/Partial/ProfileRight.cshtml", model: user));
        }
    }
}
