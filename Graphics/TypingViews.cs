using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Statistics.Models.Fields.Features;
using BrainStorm.CortexAccess;
using BrainStorm.EEG;
using BrainStorm.nlp;

namespace BrainStorm.Graphics
{
    class TypingViews
    {   
        public static List<Shape> LastShapes { get; set; }
        public static string LastOutput { get; set; }
        public static void CreateSuggestionGrid(googleComplete autoComplete)
        {
            var suggestedWordsPhrase = "";
            var suggestedLettersPhrase = "";
            var generalLettersPhrase = "";


            List<string> suggestedWordsList = new List<string>();
            List<string> suggestedLettersList = new List<string>();
            List<string> generalLettersList = new List<string>();

            BrainStorm0.MainGrid.ClearShapes();
            // create 3 by 1 space that will contain likely letters, likely words, and general letters bin
            BrainStorm0.MainGrid.Cols = 7;
            BrainStorm0.MainGrid.Rows = 3;
            BrainStorm0.MainGrid.DrawLines();

            foreach (var likelyWord in autoComplete.LikelyWords)
            {
                suggestedWordsPhrase += $"{likelyWord.Key}\n";
                suggestedWordsList.Add(likelyWord.Key);
            }
            foreach (var likelyLetter in autoComplete.LikelyLetters)
            {
                suggestedLettersPhrase += $"{likelyLetter.Key}\n";
                suggestedLettersList.Add(likelyLetter.Key);
            }
            var isNewLine = false;
            foreach (var genLetter in autoComplete.GenLetters)
            {
                generalLettersList.Add(genLetter.ToString());
                if (isNewLine)
                {
                    generalLettersPhrase += $"{genLetter}\n";
                }
                else
                {
                    generalLettersPhrase += $"{genLetter}\t";
                }
                isNewLine = !isNewLine;

            }
            // likley letters on left, likely phrases in middle, general letters on right
            var suggestedWordsShape = new Shape(1, 3, Color.WhiteSmoke, BrainStorm0.MainGrid, Predictor.FrequencyClasses[0], suggestedWordsPhrase);
            suggestedWordsShape.Language = suggestedWordsList;
            var suggestedLettersShape = new Shape(1, 0, Color.WhiteSmoke, BrainStorm0.MainGrid, Predictor.FrequencyClasses[1], suggestedLettersPhrase);
            suggestedLettersShape.Language = suggestedLettersList;
            var generalLettersShape = new Shape(1, 6, Color.WhiteSmoke, BrainStorm0.MainGrid, Predictor.FrequencyClasses[2], generalLettersPhrase);
            generalLettersShape.Language = generalLettersList;
            suggestedWordsShape.DrawBox();
            suggestedLettersShape.DrawBox();
            generalLettersShape.DrawBox();
        }
        public static void CreateInitialGrid()
        {
            var suggestedWordsPhrase = "Hello\nThe\nCan\nYou\nWhen";
            var suggestedLettersPhrase = "A\nE\nI\nH\nO\nR\nW";
            var generalLettersPhrase = "BC\nFG\nJK\nLM\nNP\nQS\nTU\nVX\nYZ\n";

            List<string> suggestedWordsList = new List<string>(){ "Hello", "The", "Can", "You", "When"};
            List<string> suggestedLettersList = new List<string>() { "A", "E", "I", "O", "R", "W" };
            List<string> generalLettersList = new List<string>(){ "B", "C", "F", "G", "J", "K", "L", "M",
                "N", "P", "Q", "S", "T", "U", "V", "X", "Y", "Z" };

            BrainStorm0.MainGrid.ClearShapes();
            // create 3 by 1 space that will contain likely letters, likely words, and general letters bin
            BrainStorm0.MainGrid.Cols = 7;
            BrainStorm0.MainGrid.Rows = 3;
            BrainStorm0.MainGrid.DrawLines();
            // likley letters on left, likely phrases in middle, general letters on right
            var suggestedWordsShape = new Shape(1, 3, Color.WhiteSmoke, BrainStorm0.MainGrid, Predictor.FrequencyClasses[0], suggestedWordsPhrase);
            suggestedWordsShape.Language = suggestedWordsList;
            var suggestedLettersShape = new Shape(1, 0, Color.WhiteSmoke, BrainStorm0.MainGrid, Predictor.FrequencyClasses[1], suggestedLettersPhrase);
            suggestedLettersShape.Language = suggestedLettersList;
            var generalLettersShape = new Shape(1, 6, Color.WhiteSmoke, BrainStorm0.MainGrid, Predictor.FrequencyClasses[2], generalLettersPhrase);
            generalLettersShape.Language = generalLettersList;
            suggestedWordsShape.DrawBox();
            suggestedLettersShape.DrawBox();
            generalLettersShape.DrawBox();
        }

        public static async void UpdateOutputView()
        {   
            // update output text box
            BrainStorm0.MainForm.OutputText = BrainStorm0.MainForm.OutputText + Predictor.PredictedLanguage[0];
            // run new autocomplete
            var autoComplete = new googleComplete();
            try
            {
                await autoComplete.GetSearchSuggestions(BrainStorm0.MainForm.OutputText);
            }
            catch
            {
                Utils.UserMessage("Please Connect to the internet before using AUtocomplete.", messageType: Globals.MessageTypes.Error);
            }
            //return if no autocomplete suggestions are returned
            if (autoComplete.AutoCompleteSuggestions.Count == 0)
            {
                return;
            }
            // create new suggestion grid w/ autocomplete results
            CreateSuggestionGrid(autoComplete);
        }


        
        // currently assumes use of 3 classes... can easily be updated to handle more
        public static void FilterView()
        {   
            // top suggestion 
            var suggestedLanguage = $"{Predictor.PredictedLanguage[0]}";
            var languageOptionsAString = "";
            var languageOptionsBString = "";

            Predictor.PredictedLanguage.RemoveAt(0);

            

            var languageOptionsAArray =
                Predictor.PredictedLanguage.Take(Predictor.PredictedLanguage.Count / 2).ToList();

            var languageOptionsBArray =
                Predictor.PredictedLanguage.Skip(Predictor.PredictedLanguage.Count / 2).ToList();

            // add dummy language to language list if empty
            if (languageOptionsBArray.Count == 0)
            {
                languageOptionsBArray.Add(" ");
            }

            if (languageOptionsAArray.Count == 0)
            {
                languageOptionsAArray.Add(" ");
            }

            List<string> suggestedLanguageList = new List<string>();
            suggestedLanguageList.Add(suggestedLanguage);


            foreach (var langPiece in languageOptionsAArray)
            {
                languageOptionsAString += $"{langPiece}\n";
            }

            foreach (var langPiece in languageOptionsBArray)
            {
                languageOptionsBString += $"{langPiece}\n";
            }




            BrainStorm0.MainGrid.ClearShapes();
            // create 3 by 1 space that will contain likely letters, likely words, and general letters bin
            BrainStorm0.MainGrid.Cols = 7;
            BrainStorm0.MainGrid.Rows = 3;
            BrainStorm0.MainGrid.DrawLines();
            // likley letters on left, likely phrases in middle, general letters on right
            var suggestedLanguageShape = new Shape(1, 3, Color.WhiteSmoke, BrainStorm0.MainGrid, Predictor.FrequencyClasses[0], suggestedLanguage);
            suggestedLanguageShape.Language = suggestedLanguageList;

            var optionsAShape= new Shape(1, 0, Color.WhiteSmoke, BrainStorm0.MainGrid, Predictor.FrequencyClasses[1], languageOptionsAString);
            optionsAShape.Language = languageOptionsAArray;

            var optionsBShape = new Shape(1, 6, Color.WhiteSmoke, BrainStorm0.MainGrid, Predictor.FrequencyClasses[2], languageOptionsBString);
            optionsBShape.Language = languageOptionsBArray;

            suggestedLanguageShape.DrawBox();
            optionsAShape.DrawBox();
            optionsBShape.DrawBox();

        }

        public static void SendView()
        {
            try
            {
                Utils.SendEmail("Sent With Brainstorm", BrainStorm0.MainForm.OutputText);
                Utils.UserMessage("Email sent. Brainstorm will now stop typing phase.", Globals.MessageTypes.Status);
            }
            catch
            {
                Utils.UserMessage("Issue sending email. Check error logs.", Globals.MessageTypes.Error);
            }
            
        }

        // go back to last typing state
        public static void CtrlZView()
        {
            if (LastOutput == null || LastShapes == null) return;
            BrainStorm0.MainGrid.ClearShapes();
            // create 3 by 1 space that will contain likely letters, likely words, and general letters bin
            BrainStorm0.MainGrid.Cols = 7;
            BrainStorm0.MainGrid.Rows = 3;
            BrainStorm0.MainGrid.DrawLines();
            foreach (var shape in LastShapes)
            {
                shape.DrawBox();
            }
        }


    }
}
