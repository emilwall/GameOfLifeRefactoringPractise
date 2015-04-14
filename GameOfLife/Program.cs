using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        private static bool[,] b = new bool[12,12];
        private static bool[,] b2 = new bool[12,12];

        static void Main(string[] args)
        {
            var r = new Random();
            for (int i = 1; i < 11; i++)
            {
                for (int j = 1; j < 11; j++)
                {
                    if (r.NextDouble() < 0.3)
                    {
                        b[i,j] = true;
                    }
                }
            }

            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (j == 0 || j == 11 || i == 0 || i == 11)
                    {
                        Console.Write("#");
                    }
                    else if(b[i,j])
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
            Console.WriteLine("Press any key to start living!!!!!!!!");
            Console.ReadLine();

            var c = 0;
            while(true)
            {
                Console.WriteLine("Generation " + c);
                for (int i = 1; i < 11; i++)
                {
                    for (int j = 1; j < 11; j++)
                    {
                        if (b[i, j])
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
                b = b2;

                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 12; j++)
                    {
                        if (j == 0 || j == 11 || i == 0 || i == 11)
                        {
                            Console.Write("#");
                        }
                        else if (b[i, j])
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
                Thread.Sleep(1500);
                c++;
                Console.WriteLine("____________________________________________");
            }
        }

        private static int check(int i, int j)
        {
            var c = 0;
            if (b[i-1,j-1])
            {
                c++;
            }if (b[i-1,j])
            {
                c++;
            }if (b[i,j-1])
            {
                c++;
            }if (b[i+1,j-1])
            {
                c++;
            }if (b[i-1,j+1])
            {
                c++;
            }if (b[i,j+1])
            {
                c++;
            }if (b[i+1,j])
            {
                c++;
            }if (b[i+1,j+1])
            {
                c++;
            }
            return c;
        }
    }
}
