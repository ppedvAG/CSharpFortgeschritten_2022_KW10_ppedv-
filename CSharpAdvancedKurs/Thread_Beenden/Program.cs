using System;
using System.Threading;

namespace Thread_Beenden
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Thread thread = new Thread(MachEtwas);
                thread.Start();


                Thread.Sleep(3000);
                thread.Abort(); //.NET 3.5.2 könnte diese Methode noch als nicht obselete eingestuft sein?! 
                thread.Interrupt(); //Alternative einen Thread zu beenden, bzw setzten den Status auf Abbruch.

                Console.WriteLine("Main Methode ist fertig");
                
            }
            catch(ThreadInterruptedException ex)
            {
                Console.WriteLine("Methode wurde mit Interrupt beendet" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString()); //Message + StackTrace
            }

            Console.ReadLine();
        }


        //Methode läuft ~10 Sekunden lang
        private static void MachEtwas()
        {
            
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("zzzzZZZZZzzzzZZZZzzzzzZZZZ");
                Thread.Sleep(200); //0,2 Sek pro Loop Interval warten 
            }
        }
    }
}
