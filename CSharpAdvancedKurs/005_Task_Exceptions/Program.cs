using System;
using System.Threading;
using System.Threading.Tasks;

namespace _005_Task_Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task t1 = null, t2 = null, t3 = null, t4 = null;

            try
            {
                t1 = new Task(MachEinenFehler1);
                t1.Start(); //starte ersten Task

                t2 = Task.Factory.StartNew(MachEinenFehler2);//starte zweiten Task

                t3 = Task.Run(MachEinenFehler3); //...
                t4 = Task.Run(MachKeinenFehler);

                Task.WaitAll(t1, t2, t3, t4);
                
            }
            catch(AggregateException ex)
            {
                foreach(Exception innerException in ex.InnerExceptions)
                    Console.WriteLine(innerException.Message);
            }

            //Status abfragen, was ist mit meinen Tasks passiert
            if (t3.IsCompleted)
                Console.WriteLine("Task 3 ist fertig!");
            if (t3.IsFaulted)
                Console.WriteLine("Task 3 hat einen Fehler!");
            if (t3.IsCompletedSuccessfully)
                Console.WriteLine("Task 3 ist sauber durchgelaufen");

            //t3.IsCanceled

            if (t4.IsCompleted)
                Console.WriteLine("Task 4 ist fertig!");
            if (t4.IsFaulted)
                Console.WriteLine("Task 4 hat einen Fehler!");
            if (t4.IsCompletedSuccessfully)
                Console.WriteLine("Task 4 ist sauber durchgelaufen");

            //t4.IsCanceled
        }

        private static void MachEinenFehler1()
        {
            Thread.Sleep(3000);
            throw new DivideByZeroException();
        }

        private static void MachEinenFehler2()
        {
            Thread.Sleep(6000);
            throw new StackOverflowException();
        }

        private static void MachEinenFehler3()
        {
            Thread.Sleep(9000);
            throw new OutOfMemoryException();
        }

        private static void MachKeinenFehler()
        {
            Console.WriteLine("Einen schönen Tag");
        }
    }
}
