using System;
using System.Threading.Tasks;

namespace _003_TaskFactorySample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //https://devblogs.microsoft.com/pfxteam/task-run-vs-task-factory-startnew/

            //https://code-maze.com/csharp-task-run-vs-task-factory-startnew/


            //.NET 4.0  -> starten des Tasks erfolgt automatisch 
            Task task = Task.Factory.StartNew(MacheEtwasInEinemThread); //Task wird sofort gestartet
            task.Wait();

            //.NEt 4.5 -> Task.Run verkürzte Schreibweise Task.Factory.StartNew

            Task task2 = Task.Run(MacheEtwasInEinemThread);
            Console.WriteLine("Bin fertig");
            Console.ReadLine();
        }

        private static void MacheEtwasInEinemThread()
        {
            for (int i = 0; i <100; i++)
                Console.WriteLine("#");
        }

    }
}
