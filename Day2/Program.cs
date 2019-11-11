using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Properties.Resources.aoc2;

            string[] packagesInput = input.Split(Environment.NewLine);

            List<Package> packages = new List<Package>();

            foreach(string package in packagesInput)
            {
                int[] split = package.Split('x').Select(s => int.Parse(s)).ToArray();
                packages.Add(new Package(split[0], split[1], split[2]));
            }

            Console.WriteLine(packages.Select(p => p.RequiredWrappingPaper).Sum());

            Console.WriteLine(packages.Select(p => p.Ribbon).Sum());
        }


        public class Package
        {
            private int _length { get; set; }
            private int _width { get; set; }
            private int _height { get; set; }
            private int TotalArea => 2 * _length * _width + 2 * _width * _height + 2 * _height * _length;
            public int RequiredWrappingPaper => TotalArea + GetSmallestSizeArea();
            public int Ribbon => GetWrappingRibbon() + GetBowRibbon();

            public Package(int length, int width, int height)
            {
                _length = length;
                _width = width;
                _height = height;
            }

            private int GetSmallestSizeArea()
            {
                int[] areas = { _length * _width, _width * _height, _height * _length };

                return areas.Min();
            }

            private int GetWrappingRibbon()
            {
                List<int> sides = new List<int>{ _length, _width, _height };

                sides.Remove(sides.Max());

                return sides.Select(s => 2*s).Sum();
            }

            private int GetBowRibbon()
            {
                return _length * _width * _height;
            }
        }
    }
}
