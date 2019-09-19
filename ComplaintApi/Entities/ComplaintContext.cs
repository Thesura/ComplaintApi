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

        public DbSet<CompanyMaster> CompanyMasters { get; set; }

        public DbSet<ComplainsHistory> ComplainsHistories { get; set; }

        public DbSet<ComplainsMaster> ComplainsMasters { get; set; }

        public DbSet<ModuleMaster> ModuleMasters { get; set; }

        public DbSet<PriorityMaster> PriorityMasters { get; set; }

        public DbSet<UserCompany> UserCompanies { get; set; }

        public DbSet<UserMaster> UserMasters { get; set; }

        public DbSet<UserModule> UserModules { get; set; }
    }
}
