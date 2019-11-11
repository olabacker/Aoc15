using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Properties.Resources.aoc5;

            IEnumerable<SantaText> santaTexts = input.Split(Environment.NewLine).Select(s => new SantaText(s));

            Console.WriteLine(santaTexts.Count(t => t.IsNice()));

            Console.WriteLine(santaTexts.Count(t => t.IsSuperNice()));

            Console.WriteLine("Hello World!");
        }

        private class SantaText
        {
            private readonly string _text;

            public SantaText(string text)
            {
                _text = text;
            }

            private HashSet<string> _strangeCombos = new HashSet<string>()
            {
                "ab",
                "cd",
                "pq",
                "xy"
            };

            public bool IsNice()
            {
                int vowelCount = 0;

                char prevChar = '-';

                bool hasStangeCombo = false;

                bool hasDoubleLetters = false;

                foreach (char c in _text.ToCharArray())
                {
                    if (prevChar == c)
                    {
                        hasDoubleLetters = true;
                    }

                    if (IsVowel(c))
                    {
                        vowelCount++;
                    }

                    string s = new string(new char[] {prevChar, c});

                    if (_strangeCombos.Contains(s))
                    {
                        hasStangeCombo = true;
                    }

                    prevChar = c;
                }

                return vowelCount >= 3 && hasDoubleLetters && !hasStangeCombo;
            }

            public bool IsSuperNice()
            {
                string charTrail = string.Empty;

                bool hasDoubleCombos = false;

                bool hasInBetweenChar = false;

                char prevChar = '-';

                foreach (char c in _text.ToCharArray())
                {
                    string s = new string(new char[] { prevChar, c });

                    if (charTrail.Length > 2 && charTrail.Substring(0, charTrail.Length - 1).Contains(s))
                    {
                        hasDoubleCombos = true;
                    }

                    if(charTrail.Length > 1 && charTrail[charTrail.Length -2] == c)
                    {
                        hasInBetweenChar = true;
                    }

                    prevChar = c;

                    charTrail += c;
                }

                return hasDoubleCombos && hasInBetweenChar;
            }

            private bool IsVowel(char c)
            {
                return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
            }
        }
    }
}
