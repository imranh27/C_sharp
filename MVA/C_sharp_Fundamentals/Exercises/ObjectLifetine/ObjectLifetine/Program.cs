using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLifetine
{
    class Program
    {
        static void Main(string[] args)
        {


            Car myCar = new Car();

            Car.MyMethod();

            Console.WriteLine("{0}, {1}, {2}, {3}", myCar.Make, myCar.Model, myCar.Year, myCar.Color);

            Car myThirdCar = new Car("Ford", "Fiesta", 2005, "white");
            Console.WriteLine("{0}, {1}, {2}, {3}", myThirdCar.Make, myThirdCar.Model, myThirdCar.Year, myThirdCar.Color);

            Console.ReadLine();
        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        //constructor
        public Car()
        {
            //initialises class, this can be data from a dtabase or config file. 
            Make = "Nissan";
        }

        //overloded constructor
        public Car(string make, string model, int year, string color)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
        }

        //utility methods, don't rely on state, apply to all instances of the class.
        public static void MyMethod()
        {
            Console.WriteLine("Calling the Static method");
        }
    }
}
