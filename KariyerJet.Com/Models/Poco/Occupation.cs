using KariyerJet.Com.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Models.Poco
{
    public class Occupation : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ApplicationUser User { get; set; }
    }
}
