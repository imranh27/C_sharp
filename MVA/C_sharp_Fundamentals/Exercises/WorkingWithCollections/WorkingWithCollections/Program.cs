using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Car car1 = new Car();
            car1.Make = "Oldsmobile";
            car1.Model = "Cutlass Supreme";
            car1.VIN = "A1";

            Car car2 = new Car();
            car2.Make = "Geo";
            car2.Model = "Prism";
            car2.VIN = "A2";

            Book b1 = new Book();
            b1.Author = "Robert Tabor";
            b1.Title = "Microsoft .NET XML Web Services";
            b1.ISBN = "0-000-00000-0";
            */

            /*
            //Array List - Dynamically sized
            //supports sorting, remove items.
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(car1);
            myArrayList.Add(car2);
            myArrayList.Add(b1);  //can add the wrong type...

            foreach (Car car in myArrayList)
            {
                Console.WriteLine(car.Make);
            }

           
            */

            //List<T>  -- Generic List = List of T

            /*
            List<Car> myList = new List<Car>();
            myList.Add(car1);
            myList.Add(car2);
            // myList.Add(b1);  Can't add a book to the list as it is expecting a car
            foreach (Car car in myList)
            {
                Console.WriteLine(car.Model);
            }
            */

            //Dictionary<Tkey, TValue>  Key, Value 
            /*
            Dictionary<string, Car> myDictionary = new Dictionary<string, Car>();

            myDictionary.Add(car1.VIN, car1);
            myDictionary.Add(car2.VIN, car2);

            Console.WriteLine(myDictionary["A2"].Make);
            */

            //Object Initialiser syntax
            //No Constructor needed
            Car car1 = new Car() { Make = "BMW", Model = "750", VIN = "C3" };
            Car car2 = new Car() { Make = "Toyota", Model = "Forerunner", VIN = "D4" };

            //Collection Initialiser
            //List of class Car
            //Just hard coded data
            List<Car> myList = new List<Car>()
            {
                new Car { Make = "Oldsmobile", Model = "Cutlas", VIN = "E5"  },
                new Car { Make = "Nissan", Model = "Altima", VIN = "E6"  }
            };


            //Generic Collections are specific to a type
                       



            Console.ReadLine();
        }
    }

    class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }

}
