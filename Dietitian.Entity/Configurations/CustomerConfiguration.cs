using Dietitian.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietitian.Entity.Configurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            ToTable("Customers");
            Property(c => c.FirstName).IsRequired().HasMaxLength(50);
            Property(c => c.MiddleName).IsRequired().HasMaxLength(50);
            Property(c => c.LastName).IsRequired();
        }
    }
}
