using KariyerJet.Com.Data.Mapping;
using KariyerJet.Com.Models.Poco;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KariyerJet.Com.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,IdentityRole , string>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ApplicationUserMap());
            builder.ApplyConfiguration(new ContactMap());
            builder.ApplyConfiguration(new EducationMap());
            builder.ApplyConfiguration(new ExperianceMap());
            builder.ApplyConfiguration(new OccupationMap());
            builder.ApplyConfiguration(new ReferenceMap());
            base.OnModelCreating(builder);
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experiance> Experiances { get; set; }
        public DbSet<Reference> References { get; set; }
    }
}
