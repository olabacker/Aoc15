using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public enum LightOperation { TurnOn, TurnOff, Toggle }

    class Program
    {
        static void Main(string[] args)
        {
            string input = Properties.Resources.aoc6;

            var grid = new PowerGrid();

            foreach (string row in input.Split(Environment.NewLine))
            {
                string[] split = row.Split(' ');

                Coord start = new Coord(split[split.Length - 3]);
                Coord end = new Coord(split[split.Length - 1]);

                LightOperation op;

                if (split[0] == "toggle")
                {
                    op = LightOperation.Toggle;
                }
                else
                {
                    if (split[1] == "on")
                    {
                        op = LightOperation.TurnOn;
                    }
                    else
                    {
                        op = LightOperation.TurnOff;
                    }
                }


                grid.OperateLights(start.X, start.Y, end.X, end.Y, op);
            }

            //grid.OperateLights(0, 0, 2, 2, LightOperation.TurnOn);

            Console.WriteLine(grid.GetAll().Sum(l => l.Brightness));
        }

        private class Coord
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            public Coord(string input)
            {
                string[] split = input.Split(',');
                X = int.Parse(split[0]);
                Y = int.Parse(split[1]);
            }
        }

        public class PowerGrid
        {
            private Light[,] _lightGrid = new Light[1000, 1000];

            public PowerGrid()
            {
                for(int i = 0; i < 1000; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        _lightGrid[i,j] = new Light();
                    }
                }
            }

            public IEnumerable<Light> GetAll()
            {
                for (int i = 0; i < 1000; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        yield return _lightGrid[i, j];
                    }
                }
            }

            public void OperateLights(int startx, int starty, int endx, int endy, LightOperation op)
            {

                for (int i = startx; i < endx+1; i++)
                {
                    for (int j = starty; j < endy+1; j++)
                    {
                        switch (op)
                        {
                            case LightOperation.TurnOn:
                                _lightGrid[i, j].Brightness++;
                                break;
                            case LightOperation.TurnOff:
                                if(_lightGrid[i,j].Brightness > 0)
                                {
                                    _lightGrid[i, j].Brightness--;
                                }

                                break;
                            case LightOperation.Toggle:
                                _lightGrid[i, j].Brightness = _lightGrid[i, j].Brightness + 2; 
                                break;
                        }
                    }
                }
            }

         
        }
        public class Light
        {
            public int Brightness { get; set; } = 0;
        }


    }
}
