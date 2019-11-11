using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Properties.Resources.aco3;

            HashSet<House> visitedHouses = new HashSet<House>();

            int santaX = 0;
            int santaY = 0;
            int robotX = 0;
            int robotY = 0;

            bool santaTurn = true;

            foreach (char c in input.ToCharArray())
            {
                var house = new House()
                {
                    X = santaTurn ? santaX : robotX,
                    Y = santaTurn ? santaY : robotY
                };

                if (!visitedHouses.Contains(house))
                {
                    visitedHouses.Add(house);
                }

                bool success = visitedHouses.TryGetValue(house, out House visitingHouse);

                visitingHouse.Visits++;

                if (santaTurn)
                {
                    switch (c)
                    {
                        case '>':
                            santaX++;
                            break;
                        case '<':
                            santaX--;
                            break;
                        case 'v':
                            santaY++;
                            break;
                        case '^':
                            santaY--;
                            break;
                    }
                }
                else
                {
                    switch (c)
                    {
                        case '>':
                            robotX++;
                            break;
                        case '<':
                            robotX--;
                            break;
                        case 'v':
                            robotY++;
                            break;
                        case '^':
                            robotY--;
                            break;
                    }
                }

                santaTurn = !santaTurn;
            }

            Console.WriteLine(visitedHouses.ToList().Count());

        }

        public class House : IEquatable<House>
        {
            public int X { get; set; }

            public int Y { get; set; }

            public int Visits { get; set; } = 0;

            public bool Equals([AllowNull] House other)
            {
                return X == other.X && Y == other.Y;
            }

            public override int GetHashCode()
            {
                int hash = 13;
                hash = (hash * 7) + X.GetHashCode();
                hash = (hash * 7) + Y.GetHashCode();
                return hash;
            }
        }
    }
}
