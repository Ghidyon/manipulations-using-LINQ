using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulationsUsingLinq
{
    public class User
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public Gender Sex { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ulong AccountNumber { get; set; }
        public long BVN { get; set; }
    }
}
