using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    class Program
    {
        private static readonly Dictionary<string, ushort> cache = new Dictionary<string, ushort>();
        private static readonly Dictionary<string, string> wires = Properties.Resources.aoc7.Split(Environment.NewLine).ToDictionary(k => k.Split(' ').Last());

        static void Main(string[] args)
        {
            var value = Recursive("a");
            Console.WriteLine(value);
            cache.Clear();
            cache["b"] = value;
            Console.WriteLine(Recursive("a"));
        }

        private static ushort Recursive(string s)
        {
            ushort temp;
            if (ushort.TryParse(s, out temp) || cache.TryGetValue(s, out temp)) return temp;
            var parsed = wires[s].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (parsed.Reverse().Skip(3).FirstOrDefault()?.ToUpperInvariant())
            {
                case "AND": return cache[parsed.Last()] = (ushort)(Recursive(parsed[0]) & Recursive(parsed[2]));
                case "OR": return cache[parsed.Last()] = (ushort)(Recursive(parsed[0]) | Recursive(parsed[2]));
                case "LSHIFT": return cache[parsed.Last()] = (ushort)(Recursive(parsed[0]) << Recursive(parsed[2]));
                case "RSHIFT": return cache[parsed.Last()] = (ushort)(Recursive(parsed[0]) >> Recursive(parsed[2]));
                case "NOT": return cache[parsed.Last()] = (ushort)~Recursive(parsed[1]);
                default: return cache[parsed.Last()] = Recursive(parsed[0]);
            }
        }
    }
}
