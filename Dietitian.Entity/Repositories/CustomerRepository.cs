using Dietitian.Core.Entities;
using Dietitian.Entity.Infrastructure;
using Dietitian.Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietitian.Entity.Repositories
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
    }

    public interface ICustomerRepository : IRepository<Customer>
    {

    }
}
