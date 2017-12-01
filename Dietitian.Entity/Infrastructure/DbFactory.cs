using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietitian.Entity.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        DietitianDbContext dbContext;

        public DietitianDbContext Init()
        {
            return dbContext ?? (dbContext = new DietitianDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
