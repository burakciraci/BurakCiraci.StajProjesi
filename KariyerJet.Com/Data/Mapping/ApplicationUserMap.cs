using KariyerJet.Com.Models.Poco;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Data.Mapping
{
    public class ApplicationUserMap:IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(x => x.UserReference)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.UserOccupation)
                .WithOne(x => x.User)
                .HasForeignKey<ApplicationUser>(x => x.UserOccupationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.UserExperiance)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.UserEducation)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.UserRole)
                .WithOne(x => x.ApplicationUser)
                .HasForeignKey(x => x.ApplicationUserId)
                .OnDelete(DeleteBehavior.NoAction);
                
        }
    }
}
