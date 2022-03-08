using System;
using System.Threading;

namespace _001_ThreadStarten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(MachEtwasInEinemThread); //Funktionzeiger wird übergeben
            thread.Start(); //thread wird jetzt seperat ausgeführt und die Main-Methode wird weiterbearebitet
            thread.Join(); //Wir warten, bis der Thread abgearbeitet ist (Callback erhält) und danach das Hauptprogramm weiter verarbeitet 
            
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("*");
            }

            Console.ReadLine();
        }

        private static void MachEtwasInEinemThread()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("#");
            }
        }
    }
}
