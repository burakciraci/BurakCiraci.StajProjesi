using KariyerJet.Com.Models.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Models.Poco
{
    public class ApplicationUser : IdentityUser,IBaseModel
    {
        public string UserAbout { get; set; }
        public string UserContactId { get; set; }
        public string UserOccupationId { get; set; }
        public virtual ICollection<Education> UserEducation { get; set; }
        public virtual ICollection<Experiance> UserExperiance { get; set; }
        public virtual ICollection<Reference> UserReference { get; set; }
        public virtual Occupation UserOccupation { get; set; }
        public virtual Contact UserContact { get; set; }


    }
}
