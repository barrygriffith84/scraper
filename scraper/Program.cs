using System;
using System.Collections.Generic;
using System.Linq;

namespace scraper
{
    class Program
    {
        static void Main(string[] args)
        {
            // !!!!! You need to install HTMLAgilityPack in Nuget Package Manager !!!!!

            var Scrape = new StateScraper();
           
            //Print the locations
            foreach (Location location in Scrape.California())
            {
                Console.WriteLine($"{location.Name} has a population of {location.Population}");
            }


         
      

        }
    }
}
