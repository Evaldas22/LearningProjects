using System;
using System.Collections.Generic;
using System.IO;
using WordUnscrambler.Workers;
using WordUnscrambler.Data;
using System.Linq;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            try
            {
                bool continueProgram = true;
                do
                {
                    Console.WriteLine(Constants.OptionsOnHowToEnterScrambledWords);

                    string option = Console.ReadLine() ?? string.Empty; // if no string is provided

                    switch (option.ToUpper())
                    {
                        case Constants.File:
                            Console.Write(Constants.EnterScrambledWordsViaFile);
                            ExecuteScrambledWordsInFileScenario();
                            break;

                        case Constants.Manual:
                            Console.Write(Constants.EnterScrambledWordsManually);
                            ExecuteScrambledWordsManualEntry();
                            break;

                        default:
                            Console.WriteLine(Constants.EnterScrambledWordsoptionNotRecognised);
                            break;
                    }

                    string continueDecision = string.Empty;

                    do
                    {
                        Console.WriteLine(Constants.OptionsOnContinuingTheProgram);
                        continueDecision = (Console.ReadLine() ?? string.Empty);

                    } while (
                    !continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase) &&
                    !continueDecision.Equals(Constants.No, StringComparison.OrdinalIgnoreCase));

                    continueProgram = continueDecision.Equals(Constants.Yes, StringComparison.OrdinalIgnoreCase);

                } while (continueProgram);
                Console.Write("Press any key to continue ...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorProgramWillBeTerminated + ex.Message);
            }
        }

        private static void ExecuteScrambledWordsManualEntry()
        {
            var manualInput = Console.ReadLine() ?? string.Empty;
            string[] scrambledWords = manualInput.Replace(" ","").Split(',');
            DisplayMatchedWrords(scrambledWords);
        }
        
        private static void ExecuteScrambledWordsInFileScenario()
        {
            try
            {
                var filename = Console.ReadLine() ?? string.Empty;
                string[] scrambledWords = _fileReader.Read(filename);
                DisplayMatchedWrords(scrambledWords);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Constants.ErrorScrambledWordsCannotBeLoaded + 
                    ex.Message);// also would be logged in real application
            }
        }

        private static void DisplayMatchedWrords(string[] scrambledWords)
        {
            //get the normal word list
            string[] wordList = _fileReader.Read(Constants.WordListFileName);

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)   
                {
                    Console.WriteLine(Constants.MatchedFound, matchedWord.ScrambledWord, matchedWord.Word);
                }
            }
            else
            {
                Console.WriteLine(Constants.MatchNotFound);
            }
        }
    }
}
