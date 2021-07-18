using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManipulationsUsingLinq
{
    public static class ServiceOperations
    {
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
