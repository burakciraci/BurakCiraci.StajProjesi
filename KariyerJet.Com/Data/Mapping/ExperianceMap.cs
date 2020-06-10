using KariyerJet.Com.Models.Poco;
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
        }
    }
}
