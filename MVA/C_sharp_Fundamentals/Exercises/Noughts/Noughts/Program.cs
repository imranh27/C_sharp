using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noughts
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] game = new string[] {"X", "", "", "X", "", "", "X", "", "" };
            string[] row1 = new string[] { "X", "_", "0" };
            string[] row2 = new string[] { "_", "X", "0" };
            string[] row3 = new string[] { "0", "_", "X" };

            int xcount = 0;
           
            foreach (var x in game)
            {
                if (x == "X")
                {
                    xcount = xcount + 1;
                }
            }

            int ocount = 0;

            foreach (var x in game)
            {
                if (x == "O")
                {
                    ocount = ocount + 1;
                }
            }

            if ((xcount - ocount) > 1) 
            {
                Console.WriteLine("nooooo");
            }
            else if ((ocount - xcount) > 1)
            {
                Console.WriteLine("hmmmmmm");
            }

            Console.WriteLine(xcount);
            Console.WriteLine(ocount);

            Console.WriteLine(TestHorizontal("X", row1));

            

            Console.ReadLine();
        }

        private static Boolean TestHorizontal(string charIn, string[] listIn)
        {
            int count = 0;

            foreach (var x in listIn)
            {
                if (x == charIn)
                {
                    count = count + 1;
                }
            }

            if (count == 3)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
