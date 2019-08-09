using MyCodeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://msdn.microsoft.com";

            Scrape myScrape = new Scrape();
            string value = myScrape.ScrapeWebpage(url);
            Console.WriteLine(value);
            Console.ReadLine();
        }
    }
}
