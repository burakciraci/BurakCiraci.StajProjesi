using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Requirements
{
    public class UserRequirement : IAuthorizationRequirement
    {
        public List<string> AllowedRoles { get; set; }
        public UserRequirement(params string[] roles)
        {
            AllowedRoles = new List<string>();
            foreach (var item in roles)
            {
                AllowedRoles.Add(item);
            }
        }
    }

    public class UserRoleHandler : AuthorizationHandler<UserRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, UserRequirement requirement)
        {
            if (!context.User.HasClaim(x=>x.Type=="role"))
            {
                return Task.CompletedTask;
            }

            var roles = context.User.Claims.Where(x => x.Type == "role");

            foreach (var userRole in roles)
            {
                foreach (var allowedRole in requirement.AllowedRoles)
                {
                    if (allowedRole==userRole.Value)
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
