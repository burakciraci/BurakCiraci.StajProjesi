﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Models.Poco
{
    public class ApplicationRole : IdentityRole
    { 
        public ICollection<UserRole> UserRole { get; set; }
    }
}
