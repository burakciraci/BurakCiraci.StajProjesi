using KariyerJet.Com.Models.Poco;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Data.Mapping
{
    public class EducationMap : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasData( new Education
                {
                    Branch = "Bilgisayar Programcılığı",
                    Degree = "Önlisans",
                    EducationType = "Uzaktan Eğitim",
                    EndingDate = DateTime.Now,
                    StartingDate = DateTime.Now,
                    School = "Ankara Üniversitesi",
                    IsDeleted = false,
                    Created = DateTime.Now,
                    IsActive = true,
                    Updated=DateTime.Now,
                    InstractionLanguage="Türkçe",
            });
        }
    }
}
