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
        public List<ulong> AccountNumber { get; set; }
        public ulong BVN { get; set; }

        //Regex regex = new Regex(@"^\d{10}$"); for 10 digit a/c No;
    }
}
