using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variables
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            int x;
            int y;

            x = 7;
            y = x + 3;

            Console.WriteLine(y);
            Console.ReadLine();
            */

            Console.WriteLine("What is your name?");

            Console.Write("Type your first name: ");
            //string myForeName;
            //myForeName = Console.ReadLine();
            string myForeName = Console.ReadLine();


            //string mySurname;
            //Console.Write("Type your last name: ");
            //mySurname = Console.ReadLine();
            Console.WriteLine("Type your last name: ");
            string mySurname = Console.ReadLine();


            Console.WriteLine("Hello " + myForeName + " " + mySurname );
            Console.ReadLine();
        }
    }
}
