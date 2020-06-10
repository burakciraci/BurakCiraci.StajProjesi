using KariyerJet.Com.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Models.Poco
{
    public class Contact : BaseModel
    {
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string LinkedIn { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string WebSite { get; set; }
        public string GitHub { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
