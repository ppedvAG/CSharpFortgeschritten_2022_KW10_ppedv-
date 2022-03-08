using System;
using System.Threading;
using System.Threading.Tasks;

namespace _006_ContinueWithSample
{
    internal class Program
    {
        private static int[] Lottozahlen = new int[7];
        static void Main(string[] args)
        {
            Task t1 = new Task(() =>
            {
                Lottozahlen[0] = 2;
                Lottozahlen[1] = 12;
                Lottozahlen[2] = 22;
                Lottozahlen[3] = 32;
                Lottozahlen[4] = 42;
                Lottozahlen[5] = 52;
                Lottozahlen[6] = 62;

                Console.WriteLine("Task 1 arbeitet");
                Thread.Sleep(1000);


                //throw new Exception();
            });

            t1.Start();
            t1.ContinueWith(t => AllgemeinerFolgetask());
            t1.ContinueWith(t1 => FolgetaskBeiFehler(), TaskContinuationOptions.OnlyOnFaulted);
            t1.ContinueWith(t1 => FolgetaskBeiErfolg(), TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        private static void AllgemeinerFolgetask()
        {
            Console.WriteLine("Allgemeiner Folgetask");
        }

        private static void FolgetaskBeiFehler()
        {
            Console.WriteLine("FolgetaskBeiFehler");
            Lottozahlen = new int[7];
        }

        private static void FolgetaskBeiErfolg()
        {
            Console.WriteLine("FolgetaskBeiErfolg");
        }
    }
}
