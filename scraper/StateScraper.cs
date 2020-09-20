using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scraper
{
    public class StateScraper
    {
        public List<Location> California()
        {
            //Object that allows you to connect to a URL 
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();

            //Loads the page into an object
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://en.wikipedia.org/wiki/List_of_counties_in_California#List");


            //A list to get all of the <tr> elements from the table.  Gets the <tr> nodes that contain ;County
            List<HtmlAgilityPack.HtmlNode> nodes = doc.DocumentNode.SelectNodes("//tr").Where(n => n.InnerText.Contains(";County") || n.InnerText.Contains("city of San Francisco")).ToList();

            //A list to store each location each Location
            List<Location> locationList = new List<Location>();


            foreach (HtmlAgilityPack.HtmlNode item in nodes)
            {
                string name = item.ChildNodes[1].InnerText;
                //Gets the name of the County from a child node
                if (name.IndexOf("&") != -1)
                {
                   name = name.Substring(0, name.IndexOf("&"));
                }
                

                string populationString = item.ChildNodes[15].InnerText.Replace(",", string.Empty).Replace("\n", string.Empty);

                Location location = new Location()
                {
                    //Substring removes any characters I don't want in the County name
                    Name = name,


                    //InnerText returns a string, so I have to remove the , from the string and convert it to an int.
                    Population = Int32.Parse(populationString)
                };

                //Add the location to the list
                locationList.Add(location);

            }

            return locationList;
        }
        public List<Location> Kentucky()
        {
            //Object that allows you to connect to a URL 
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();

            //Loads the page into an object
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://en.wikipedia.org/wiki/List_of_counties_in_Kentucky#Alphabetical_list");


            //A list to get all of the <tr> elements from the table.  Gets the <tr> nodes that contain ;County
            List<HtmlAgilityPack.HtmlNode> nodes = doc.DocumentNode.SelectNodes("//tr").Where(n => n.InnerText.Contains(";County")).ToList();

            //A list to store each location each Location
            List<Location> locationList = new List<Location>();


            foreach (HtmlAgilityPack.HtmlNode item in nodes)
            {
                //Gets the name of the County from a child node
                string name = item.ChildNodes[1].InnerText;


                Location location = new Location()
                {
                    //Substring removes any characters I don't want in the County name
                    Name = name.Substring(0, name.IndexOf("&")),

                    //InnerText returns a string, so I have to remove the , from the string and convert it to an int.
                    Population = Int32.Parse(item.ChildNodes[13].InnerText.Replace(",", string.Empty))
                };

                //Add the location to the list
                locationList.Add(location);

            }

            

            return locationList;

        }
    }
}
