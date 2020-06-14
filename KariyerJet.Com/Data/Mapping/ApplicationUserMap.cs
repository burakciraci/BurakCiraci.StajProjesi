using KariyerJet.Com.Models.Poco;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Data.Mapping
{
    public class ApplicationUserMap : IEntityTypeConfiguration<ApplicationUser>
    {
       
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(x => x.UserReference)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasOne(x => x.UserOccupation)
                .WithOne(x => x.User)
                .HasForeignKey<ApplicationUser>(x => x.UserOccupationId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasMany(x => x.UserExperiance)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            builder.HasMany(x => x.UserEducation)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(false);

            CreateData(builder);
        }
        private DataBuilder<ApplicationUser> CreateData(EntityTypeBuilder<ApplicationUser> b)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var user1 = new ApplicationUser
            {
                UserName = "Burak Çıracı",
                NormalizedUserName = "BURAK ÇIRACI",
                Email = "burakciraci02@gmail.com",
                NormalizedEmail = "burakciraci02@gmail.com",
                PhoneNumber = "05554443322",
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            }; 
            user1.PasswordHash = hasher.HashPassword(user1, "Burak_1996");
            return b.HasData(user1);
        }
    }
}
