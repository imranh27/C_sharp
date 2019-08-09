using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            //to catch run time errors.
            try
            {
                string content = File.ReadAllText(@"C:\Users\imran.hashmi.LANGLEYS\source\repos\Learn\C_sharp\MVA\C_sharp_Fundamentals\Exercises\HandlingExceptions\HandlingExceptions\Exampe.txt");

                Console.WriteLine(content);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Can't find the file");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Can't find the directory");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                //Code to finalise
                //eg close db connections
            }

            Console.ReadLine();
        }
    }
}
