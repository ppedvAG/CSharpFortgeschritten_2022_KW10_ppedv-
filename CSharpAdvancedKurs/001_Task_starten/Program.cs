using System;
using System.Threading.Tasks;

namespace _001_Task_starten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(MacheEtwasInEinemThread); //Funktionszeiger 
            task.Start();
            task.Wait();

            for (int i = 0; i < 1000; i++)
                Console.WriteLine("*");
            Console.ReadLine();

        }

        private static void MacheEtwasInEinemThread()
        {
            for (int i = 0; i < 1000; i++)
                Console.WriteLine("#");
        }
    }
}
