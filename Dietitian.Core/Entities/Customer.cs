using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietitian.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CivilId { get; set; }
        public int MobileNumber { get; set; }
        public int TelephoneNumber { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Snapchat { get; set; }
        public string Twitter { get; set; }
        public string Address { get; set; }
        public string Nationality { get; set; }
        public string Attachment { get; set; }
        public string PreferredContactMethod { get; set; }
        public string Gender { get; set; }
    }
}
