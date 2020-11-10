using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace SP_Tema4_Ej5
{
    class Program
    {
        static int counter = 0;
        static void increment()
        {
            counter++;
            Console.WriteLine(counter);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("si, llego");
            MyTimer t = new MyTimer(increment);
            t.interval = 1000;
            string op = "";
            Thread.CurrentThread.IsBackground = true;
            do
            {
                Console.WriteLine("Press any key to start.");
                Console.ReadKey();
                t.run();
                Console.WriteLine("Press any key to pause.");
                Console.ReadKey();
                t.pause();
                Console.WriteLine("Press 1 to restart or Enter to end.");
                op = Console.ReadLine();
                t.acabo = !(op == "1");
            } while (op == "1");

        }
    }
}