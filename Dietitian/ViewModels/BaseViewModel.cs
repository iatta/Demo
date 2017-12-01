using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dietitian.Web.ViewModels
{
    public class BaseViewModel
    {
        public int Id { get; set; }

        public DateTime CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}