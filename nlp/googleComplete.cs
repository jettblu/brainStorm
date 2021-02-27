using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BrainStorm.nlp
{
    class googleComplete
    {
        private const string searchUrl = "http://www.google.com/complete/search?output=toolbar&q={0}&hl=en";

        public List<GoogleSuggestion> AutoCompleteSuggestions { get; set; }
       
        public async Task<List<GoogleSuggestion>> GetSearchSuggestions(string query="mo")
        {
            if (String.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Argument cannot be null or empty!", "query");
            }

            string result = String.Empty;

            using (HttpClient client = new HttpClient())
            {
                result = await client.GetStringAsync(String.Format(searchUrl, query));
            }

            XDocument doc = XDocument.Parse(result);

            var suggestions = from suggestion in doc.Descendants("CompleteSuggestion")
                select new GoogleSuggestion
                {
                    Phrase = suggestion.Element("suggestion").Attribute("data").Value
                };

            AutoCompleteSuggestions = suggestions.ToList();
            return AutoCompleteSuggestions;
        }
    }


    public class GoogleSuggestion
    {

        public string Phrase { get; set; }

        public override string ToString()
        {
            return this.Phrase;
        }
    }

}

