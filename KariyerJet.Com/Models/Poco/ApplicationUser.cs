using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Models.Poco
{
    public class ApplicationUser : IdentityUser
    {
        public string UserAbout { get; set; }
        public int UserContactId { get; set; }
        public int UserOccupationId { get; set; }
        public ICollection<Education> UserEducation { get; set; }
        public ICollection<Experiance> UserExperiance { get; set; }
        public ICollection<Reference> UserReference { get; set; }
        public ICollection<UserRole> UserRole { get; set; }
        public Occupation UserOccupation { get; set; }
        public Contact UserContact { get; set; }
    }
}
