using System;
using System.Threading;

namespace Mutex_ProgramInstance
{
    internal class Program
    {
        static Mutex mutex;
        static void Main(string[] args)
        {
            if (Program.IsSingleInstance())
            {
                Console.WriteLine("One Instance");
            }
            else
            {
                Console.WriteLine("More than one instance");
            }

            Console.ReadLine();
        }


        static bool IsSingleInstance()
        {
            if (Mutex.TryOpenExisting("ABC", out mutex))
            {
                return false;
            }
            else
            {
                //Erste Programmstart, legt Mutext an
                mutex = new Mutex(false, "ABC");
                return true;
            }
        }
    }
}
