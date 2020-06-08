using KariyerJet.Com.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Models.Poco
{
    public class References : BaseModel
    {
        public string FullName { get; set; }
        public string Job { get; set; }
        public string Telephone { get; set; }
    }
}
