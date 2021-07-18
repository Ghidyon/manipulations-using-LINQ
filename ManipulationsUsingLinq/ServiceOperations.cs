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
        public static Regex NameRegex= new Regex(@"^[a-zA-z]+$");
        public static Regex TenDigitRegex = new Regex(@"^\d{10}$");
        public static Regex EmailRegex = new Regex(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$");

        public static BVNOperations MatchOption(string option)
        {
            switch (option)
            {
                case "1":
                    return BVNOperations.EnrollForBVN;
                case "2":
                    return BVNOperations.CheckBVN;
                case "3":
                    return BVNOperations.End;
                default:
                    return BVNOperations.ChooseOptions;
            }
        }
    }
}
