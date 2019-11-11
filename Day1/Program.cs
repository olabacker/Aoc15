using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Properties.Resources.TextFile1;

            char[] chars = input.ToCharArray();

            int elevation = chars.Count(c => c == '(') - chars.Count(c => c == ')');

            Console.WriteLine(elevation);

            int currentElevation = 0;
            int firstBasementInstruction = -1;

            for(int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];

                if(c == '(')
                {
                    currentElevation++;
                }
                else
                {
                    currentElevation--;
                }

                if(currentElevation == -1)
                {
                    firstBasementInstruction = i + 1;
                    break;
                }
            }

            Console.WriteLine(firstBasementInstruction);

            Console.ReadLine();

        }
    }
}
