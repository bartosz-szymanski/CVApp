using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;

namespace CVApp.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Log> Logs { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
    }
}