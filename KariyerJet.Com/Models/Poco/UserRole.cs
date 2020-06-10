using KariyerJet.Com.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Models.Poco
{
    public class UserRole : BaseModel
    {
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int ApplicationRoleId { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
    }
}
