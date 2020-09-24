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


            //Object that allows you to connect to a URL 
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();

            //Loads the page into an object
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.sec.gov/Archives/edgar/data/1315765/000091957420005196/xslForm13F_X01/infotable.xml");

            //Burry starts at node 11
            //Check InnerStartIndex (6130)
            ///html[1]/body[1]/table[2]/tbody[1]/tr[4]
            //A list to get all of the <tr> elements from the table.  Gets the <tr> nodes that contain ;County
            List<HtmlAgilityPack.HtmlNode> nodes = doc.DocumentNode.SelectNodes("//tr").Where(n => n.InnerText.Contains("")).ToList();
            //.Where(n => n.InnerText.Contains(";County"))


            //A list to store each location each Location
            List<Location> locationList = new List<Location>();


            //foreach (HtmlAgilityPack.HtmlNode item in nodes)
            //{
            //    //Gets the name of the County from a child node
            //    string name = item.ChildNodes[1].InnerText;

                
            //    Location location = new Location()
            //    {
            //        //Substring removes any characters I don't want in the County name
            //        Name = name.Substring(0, name.IndexOf("&")),

            //        //InnerText returns a string, so I have to remove the , from the string and convert it to an int.
            //    Population = Int32.Parse(item.ChildNodes[13].InnerText.Replace("," , string.Empty))
            //    };

            //    //Add the location to the list
            //    locationList.Add(location);

            //}

            ////Print the locations
            //foreach (Location location in locationList)
            //{
            //    Console.WriteLine($"{location.Name} has a population of {location.Population}");
            //}


         
      

        }
    }
}
