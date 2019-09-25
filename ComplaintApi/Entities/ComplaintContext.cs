using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplaintApi.Entities
{
    public class ComplaintContext : DbContext
    {
        public ComplaintContext(DbContextOptions<ComplaintContext> options) : base(options)
        {

        }

        public DbSet<CompanyMaster> CompanyMaster { get; set; }

        public DbSet<ComplainsHistory> ComplainsHistory { get; set; }

        public DbSet<ComplainsMaster> ComplainsMaster { get; set; }

        public DbSet<ModuleMaster> ModuleMaster { get; set; }

        public DbSet<PriorityMaster> PriorityMaster { get; set; }

        public DbSet<UserCompany> UserCompany { get; set; }

        public DbSet<UserMaster> UserMaster { get; set; }

        public DbSet<UserModule> UserModule { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ComplainsHistory>()
                .HasKey(o => new { o.HistoryID, o.ComplainID });

            modelBuilder.Entity<UserCompany>()
                .HasKey(o => new { o.EmpID, o.CompanyID });

            modelBuilder.Entity<UserModule>()
                .HasKey(o => new { o.EmpID, o.ModuleID });
        }
    }
}
