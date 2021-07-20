using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVNEnrollmentApp.Events
{
    public static class EventHandler
    {
        public static void DetailsOfSentEmail(object sender, EventArgs model)
        {
            Console.WriteLine("Event run");
        }
    }
}
