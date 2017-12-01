using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dietitian.Web.Helpers
{
    public class AjaxResponse
    {
        public bool Success { get; set; }
        public dynamic Result { get; set; }
    }
}