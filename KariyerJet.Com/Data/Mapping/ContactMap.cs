using KariyerJet.Com.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Data.Mapping
{
    public class ContactMap : IEntityTypeConfiguration<Contact>
    { 
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasOne(x => x.User)
                 .WithOne(x => x.UserContact)
                 .HasForeignKey<Contact>(x => x.UserId)
                 .HasForeignKey<ApplicationUser>(x=>x.UserContact)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
