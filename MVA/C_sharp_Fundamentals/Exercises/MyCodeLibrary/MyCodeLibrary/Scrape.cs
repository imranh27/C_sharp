using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeLibrary
{
    public class Scrape
    {
        public string ScrapeWebpage(string url)
        {
            return GetWebPage(url);
            //WebClient client = new WebClient();
            //string reply = client.DownloadString(url);
            //return client.DownloadString(url);

            //Console.WriteLine(reply);
            //File.WriteAllText(@"C:\Lesson17\WriteText.txt", reply);

        }

        public string ScrapeWebpage(string url, string filepath)
        {
            //WebClient client = new WebClient();
            //string reply = client.DownloadString(url);
            string reply = GetWebPage(url);
            File.WriteAllText(filepath, reply);
            return reply;           

        }

        private string GetWebPage(string url)
        {
            WebClient client = new WebClient();
            return client.DownloadString(url);
        }

    }
}
