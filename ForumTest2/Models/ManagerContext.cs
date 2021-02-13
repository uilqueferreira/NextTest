using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ForumTest2.Models
{
    public class ManagerContext : System.Data.Entity.DbContext
    {
        public ManagerContext()
            : base("ManagerContext")
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder db)
        {
            db.Conventions.Remove<PluralizingTableNameConvention>();

            db.Entity<Topic>()
            .HasRequired(x => x.User);
        }

    }
}