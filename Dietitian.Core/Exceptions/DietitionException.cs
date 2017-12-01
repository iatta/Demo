using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietitian.Core.Exceptions
{
    public class DietitionException : Exception
    {
        public DietitionException(string message) : base(message)
        {

        }
    }
}
