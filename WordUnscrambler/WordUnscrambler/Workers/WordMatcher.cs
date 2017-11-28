using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordUnscrambler.Data;

namespace WordUnscrambler.Workers
{
    public class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            var matchedWords = new List<MatchedWord>();

            foreach (var scrambledWord in scrambledWords)   
            {
                foreach (var word in wordList)  
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))// later try with '=='
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));// here i want to add not just word 
                    }                                                       // but like object with scrambledWord and word
                                                                            // into the MatchedWords struct
                    else
                    {
                        var scrambledWordArray = scrambledWord.ToCharArray();
                        var wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        var sortedScrambledWord = new string(scrambledWordArray);
                        var sortedWord = new string(wordArray);

                        if(sortedScrambledWord.Equals(sortedWord, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }
                    }
                }

            }

            return matchedWords;
        }

        private MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedword = new MatchedWord
            {
                ScrambledWord = scrambledWord,
                Word = word
            };

            return matchedword;
        }
            
    }
}

