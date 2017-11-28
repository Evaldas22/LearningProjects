using SimpleWebScraper.Builders;
using SimpleWebScraper.Data;
using SimpleWebScraper.Workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace SimpleWebScraper
{
    class Program
    {
        private const string Method = "search";

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter which city you would like to scrape information from:");
                string craigsListsCity = Console.ReadLine() ?? string.Empty;

                Console.WriteLine("Please enter the CraigsList category from availables:");
                string craigsListsCategory = Console.ReadLine() ?? string.Empty;

                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString($"http://{craigsListsCity.Replace(" ", string.Empty)}." +
                        $"craigslist.org/{Method}/{craigsListsCategory}");

                    ScrapeCriteria scrapeCriteria = new ScrapeCriteriaBuilder().
                        WithData(content).
                        WithRegex("<a href=\"(.*?)\" data-id=\"(.*?)\" class=\"result-title hdrlnk\">(.*?)</a>").
                        WithRegexOption(RegexOptions.ExplicitCapture).
                        WithPart(new ScrapeCriteriaPartBuilder(). // this part will get the description
                            WithRegex(">(.*?)</a>").
                            WithRegexOption(RegexOptions.Singleline).
                            Build()).
                        WithPart(new ScrapeCriteriaPartBuilder(). // this part will get the link 
                            WithRegex("href=\"(.*?)\"").
                            WithRegexOption(RegexOptions.Singleline).
                            Build()).
                        Build(); // @ is used to escape any characters I guess

                    Scraper scraper = new Scraper();
                    var scrapedElements = scraper.Scrape(scrapeCriteria);

                    if (scrapedElements.Any())
                    {
                        foreach (var scrapedElement in scrapedElements)
                        {
                            Console.WriteLine(scrapedElement);
                        }
                    }
                    else
                    {
                        Console.WriteLine("There were no matches for the specified scrape criteria");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
