using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietitian.Entity.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        DietitianDbContext Init();
    }
}
