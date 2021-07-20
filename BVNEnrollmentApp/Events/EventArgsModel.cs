using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVNEnrollmentApp.Events
{
    public class EventArgsModel : EventArgs
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public char MiddleName { get; set; }
        public ulong AccountNumber { get; set; }
        public string Email { get; set; }
    }
}
