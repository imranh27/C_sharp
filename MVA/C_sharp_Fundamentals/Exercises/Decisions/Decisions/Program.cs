using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decisions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bobs Big Giveaway");
            Console.Write("Choose a door: 1, 2 or 3:");
            string userValue = Console.ReadLine();
            //string message = "";

            //if (userValue == "1")
            //    message = "You won a new car!";
            //else if (userValue == "2")
            //    message = "You won a new boat!";
            //else if (userValue == "3")
            //    message = "you won a new cat!";
            //else
            //{
            //    message = "sorry we didn't understand";
            //    //message = message + "you lost";
            //    message += "you lost";
            //}

            //Console.WriteLine(message);
            //Console.ReadLine();

            string message = (userValue == "1") ? "boat" : "strand of lint";

            Console.WriteLine("You entered: {0}, therefore you won a {1}.", userValue, message);
            //Console.Write("You won a ");
            //Console.Write(message);
            //Console.Write(".");
            Console.ReadLine();
        }
    }
}
