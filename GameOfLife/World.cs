using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class World
    {
        public World()
        {
            _b = new bool[12, 12];
            b2 = new bool[12, 12];
            Generate();
        }

        private bool[,] _b;
        private bool[,] b2;

        public bool[,] CurrentWorld
        {
            get
            {
                var currentWorld = new bool[12, 12];
                Array.Copy(_b, currentWorld, 144);
                return currentWorld;
            }
        }

        private void Generate()
        {
            var r = new Random();
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (r.NextDouble() < 0.3)
                    {
                        _b[i, j] = true;
                    }
                }
            }

        }

        public void Print()
        {
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (j == 0 || j == 11 || i == 0 || i == 11)
                    {
                        Console.Write("#");
                    }
                    else if (_b[i, j])
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("0");
                    }
                }
                Console.WriteLine();
            }
        }

        public void StepGeneration()
        {
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (_b[i, j])
                    {
                        switch (check(i, j))
                        {
                            case 0:
                                b2[i, j] = false;
                                break;
                            case 1:
                                b2[i, j] = false;
                                break;
                            case 2:
                                b2[i, j] = true;
                                break;
                            case 3:
                                b2[i, j] = true;
                                break;
                            default:
                                b2[i, j] = false;
                                break;
                        }
                    }
                    else
                    {
                        if (check(i, j) == 3)
                        {
                            b2[i, j] = true;
                        }
                    }
                }
            }
            _b = b2;
        }

        private int check(int i, int j)
        {
            var c = 0;
            if (_b[i - 1, j - 1])
            {
                c++;
            } if (_b[i - 1, j])
            {
                c++;
            } if (_b[i, j - 1])
            {
                c++;
            } if (_b[i + 1, j - 1])
            {
                c++;
            } if (_b[i - 1, j + 1])
            {
                c++;
            } if (_b[i, j + 1])
            {
                c++;
            } if (_b[i + 1, j])
            {
                c++;
            } if (_b[i + 1, j + 1])
            {
                c++;
            }
            return c;
        }
    }
}
