using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ManipulationsUsingLinq
{
    public static class ServiceOperations
    {
        public static readonly Regex NameRegex = new(@"^[a-zA-z]+$");
        public static readonly Regex TenDigitRegex = new(@"^\d{10}$");
        public static readonly Regex EmailRegex = new(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        //public static readonly Regex EmailRegex = new(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$");

        public static BVNOperations MatchOption(string option)
        {
            return option switch
            {
                "1" => BVNOperations.EnrollForBVN,
                "2" => BVNOperations.CheckBVN,
                "3" => BVNOperations.End,
                _ => BVNOperations.ChooseOptions
            };
        }

        public static Gender GenderSelection(string gender)
        {
            return gender switch
            {
                "1" => Gender.Male,
                "2" => Gender.Female,
                _ => Gender.SelectGender
            };
        }
    }
}
