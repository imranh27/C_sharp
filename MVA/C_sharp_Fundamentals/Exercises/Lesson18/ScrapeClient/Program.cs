using ScrapeLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScrapeClient
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
