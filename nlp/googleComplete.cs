using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace BrainStorm.nlp
{
    class googleComplete
    {
        private const string searchUrl = "http://www.google.com/complete/search?output=toolbar&q={0}&hl=en";
        static string Alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private string InputPhrase { get; set; }
        public Dictionary<string, int> LikelyLetters = new Dictionary<string, int>();
        public Dictionary<string, int> LikelyWords = new Dictionary<string, int>();
        public char[] GenLetters { get; set; }
        public List<GoogleSuggestion> AutoCompleteSuggestions { get; set; }
       
        public async Task<List<GoogleSuggestion>> GetSearchSuggestions(string query="How")
        {
            if (String.IsNullOrWhiteSpace(query))
            {
                throw new ArgumentException("Argument cannot be null or empty!", "query");
            }
            InputPhrase = query;
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
            LikelyFragments();
            GeneralLetters();
            return AutoCompleteSuggestions;
        }
        private void LikelyFragments()
        {   
            
            foreach (var suggestion in  AutoCompleteSuggestions)
            {
                var nextWord = "";
                // find end of phrase
                var phraseEnd = InputPhrase.Length + suggestion.Phrase.IndexOf(InputPhrase);
                // retrieve rest of autocomplete suggestion
                var autoPhrase = suggestion.Phrase.Substring(phraseEnd);
                try
                {
                    nextWord = autoPhrase.Split(' ')[0];
                    if (nextWord == "")
                    {
                        nextWord = autoPhrase.Split(' ')[1];
                    }
                }
                //case where phrase lies within single word suggestion
                catch (Exception IndexError)
                {
                    try
                    {
                        nextWord = autoPhrase.Substring(phraseEnd);
                    }
                    // case where autocomplete suggestion is input phrase itself
                    catch(Exception IndexOutOfRangeException)
                    {
                        continue;
                    }
                    
                }
                // count occurance of each suggested next word/ letter
                int letterCount;
                int wordCount;
                var nextLetter = nextWord.Substring(0, 1).ToUpper();
                if (LikelyLetters.TryGetValue(nextLetter, out letterCount))
                {
                    LikelyLetters[nextLetter] = letterCount + 1;
                }
                else
                {
                    LikelyLetters[nextLetter] = 1;
                }
                if (LikelyWords.TryGetValue(nextWord, out wordCount))
                {
                    LikelyWords[nextWord] = wordCount + 1;
                }
                else
                {
                    LikelyWords[nextWord] = 1;
                }
                // end of dic. assignment
            }
            //order likely fragment dicts from most likely to least likely
            LikelyLetters = LikelyLetters.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            LikelyWords = LikelyWords.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        private void GeneralLetters()
        {   
            //remove likely letters from general letters
            foreach (var likelyLetter in LikelyLetters)
            {
                Alpha = Alpha.Replace(likelyLetter.Key, "");
            }
            GenLetters = Alpha.ToCharArray();
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

