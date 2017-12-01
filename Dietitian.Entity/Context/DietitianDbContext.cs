using Dietitian.Core.Entities;
using Dietitian.Entity.Configurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietitian.Entity
{
    public class DietitianDbContext : DbContext
    {
        public DietitianDbContext() : base("DietitianDbConnection")
        {

        }
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerConfiguration());
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
