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
        static void Main(string[] args)
        {
            var world = new World();

            world.Print();

            Console.WriteLine("Press any key to start living!!!!!!!!");
            Console.ReadLine();

            var c = 0;
            while (true)
            {
                Console.WriteLine("Generation " + c);
                world.StepGeneration();
                world.Print();

                Thread.Sleep(1500);
                c++;
                Console.WriteLine("____________________________________________");
            }
        }
    }
}
