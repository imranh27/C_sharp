using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Name Game");

            Console.Write("What's your first name? ");
            string firstName = Console.ReadLine();

            Console.Write("What's your last name? ");
            string lastName = Console.ReadLine();

            Console.Write("In what city were you born?");
            string city = Console.ReadLine();



            //char[] lastNameArray = lastName.ToCharArray();
            //Array.Reverse(lastNameArray);

            //char[] cityArray = city.ToCharArray();
            //Array.Reverse(cityArray);

            //string result = "";



            //result += " ";

            //foreach (char item in lastNameArray)
            //{
            //    result += item;
            //}

            //result += " ";

            //foreach (char item in cityArray)
            //{
            //    result += item;
            //}

            //Console.WriteLine("Results: " + result);

           
            //string reversedFirstName = StringReverse(firstName);
            //string reversedLastName = StringReverse(lastName);
            //string reversedCity = StringReverse(city);

            DisplayResult(StringReverse(firstName), StringReverse(lastName), StringReverse(city));

            Console.WriteLine();
            Console.WriteLine();

            DisplayResult(StringReverse(firstName) + " " + StringReverse(lastName) + " " + StringReverse(city));

            Console.ReadLine();
        }

        private static string StringReverse(string message)
        {
            //string message = "Hello World";
            char[] messageArray = message.ToCharArray();
            Array.Reverse(messageArray);
            return String.Concat(messageArray);
        }

        private static void DisplayResult(string first, string second, string third)
        {
            Console.Write("Results: ");
            Console.Write(String.Format("{0} {1} {2}",
                                       first, second, third)
                          );
        }

        private static void DisplayResult(string message)
        {
            Console.Write("Results: " + message);
        }


    }
}
