using KariyerJet.Com.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Models.Poco
{
    public class Experiance : BaseModel<string>
    {
        public string UserId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime ExpirationDate  { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string MannerWork { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
