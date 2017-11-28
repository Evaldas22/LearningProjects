using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScraper.Data
{
    class ScrapeCriteria
    {
        public ScrapeCriteria()
        {
            Parts = new List<ScrapeCriteriaPart>();
        }

        public string Data { get; set; } // what we want to scrape 
        public string Regex{ get; set; } // how we want to scrape
        public RegexOptions RegexOption{ get; set; } // how regex need to behave
        public List<ScrapeCriteriaPart> Parts { get; set; } // how deep to go in HTML elements
    }
}
