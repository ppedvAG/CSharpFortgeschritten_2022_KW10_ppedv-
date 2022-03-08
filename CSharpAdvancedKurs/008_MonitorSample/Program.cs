using System;
using System.Threading;

namespace _008_MonitorSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void KritischerCodeAbschnitt()
        {
            int x = 1;

            if (Monitor.TryEnter(x))
            {
                try
                {
                    //Deadlock potenzieller Code
                }
                finally 
                {
                    Monitor.Exit(x);
                }
            }
        }
    }
}
