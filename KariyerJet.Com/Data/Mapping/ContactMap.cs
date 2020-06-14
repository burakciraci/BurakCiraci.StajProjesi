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
                 .HasForeignKey<ApplicationUser>(x => x.UserContactId)
                 .OnDelete(DeleteBehavior.NoAction)
                 .IsRequired(false);
            builder.HasData(new Contact
            {
                IsDeleted = false,
                IsActive=true,
                Twitter="https://twitter.com",
                Facebook="Https://facebook.com",
                GitHub="https://github.com",
                LinkedIn="https://linkedin.com",
                WebSite="Https://burakciraci.com",
                Telephone="05546454545",
                Address="İskenderun/HATAY",
                Created=DateTime.Now,
                Updated=DateTime.Now,
            }) ;
        }
    }
}
