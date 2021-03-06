﻿using KariyerJet.Com.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Data.Mapping
{
    public class ExperianceMap : IEntityTypeConfiguration<Experiance>
    {
        
        public void Configure(EntityTypeBuilder<Experiance> builder)
        {
            builder.HasData(new Experiance
            {
                
                ExpirationDate = DateTime.Now,
                StartingDate = DateTime.Now,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                Company = "Koton",
                Position = "Satış Danışmanı",
                MannerWork = "Tam Zamanlı",
                IsDeleted = false,
                IsActive = true,

            });
        }
    }
}
