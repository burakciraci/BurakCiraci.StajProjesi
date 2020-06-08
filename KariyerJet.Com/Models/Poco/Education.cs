using KariyerJet.Com.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Models.Poco
{
    public class Education : BaseModel
    {
        public string Degree { get; set; }
        public string School { get; set; }
        public string Branch { get; set; }
        public DateTime EndingDate { get; set; }
        public DateTime StartingDate { get; set; }
        public string InstractionLanguage { get; set; }
        public string EducationType { get; set; }
    }
}
