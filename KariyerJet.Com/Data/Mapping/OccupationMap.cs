using KariyerJet.Com.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Data.Mapping
{
    public class OccupationMap : IEntityTypeConfiguration<Occupation>
    {
      
        public void Configure(EntityTypeBuilder<Occupation> builder)
        {
            builder.HasData(new Occupation
            {
                Description = "özyazı",
                Name = "Yazılım Uzmanı",
                IsDeleted=false,
                IsActive=true,
                Created=DateTime.Now,
                Updated=DateTime.Now
            });
        }
    }
}
