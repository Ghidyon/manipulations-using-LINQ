using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVNEnrollmentApp.Events
{
    public static class EventHandler
    {
        public static void DetailsOfSentEmail(object sender, EventArgsModel model)
        {
            Console.WriteLine("\nMalicious Login Attempt!");
            Console.WriteLine("========================");
            Console.WriteLine($"A banned user with details below, tried logging in.\nPlease take necessary action.\nName: {model.LastName} {model.FirstName} {model.MiddleName}\nA/C Number: {model.AccountNumber}\nEmail: {model.Email}");
        }
    }
}
