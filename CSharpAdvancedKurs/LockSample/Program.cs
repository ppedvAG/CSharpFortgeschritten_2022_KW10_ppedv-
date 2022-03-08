using System;
using System.Threading;

namespace LockSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ParameterizedThreadStart param = null;

            Thread thread = null;

            for (int i = 0; i < 500; i++)
            {
                param = new ParameterizedThreadStart(MachEinKontoUpdate);
                thread = new Thread(param);
                thread.Start();
            }

            Console.WriteLine("fertig");
            Console.ReadLine();
        }


        private static void MachEinKontoUpdate(object state)
        {
            Random rnd = new Random();

            for(int i = 0; i <5000; i++)
            {
                int auswahl = rnd.Next();

                int betrag = rnd.Next(0, 1000);

                if (auswahl % 2 == 0)
                    Konto.Abheben(betrag);
                else
                    Konto.Einzahlen(betrag);
            }
        }
    }

    public static class Konto
    {
        public static decimal Kontostand { get; set; } = 0; //DefaultValue = 0
        public static int TransactionId { get; set; } = 0;

        public static object lockFlagEinzahlen = new object();
        public static object lockFlackAbheben = new object();


        public static void Einzahlen(decimal betrag)
        {
            try
            {
                lock(lockFlagEinzahlen)
                {
                    TransactionId++;
                    Kontostand += betrag;
                }
            }
            catch (Exception ex)    
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Deadlock juhuuu");
            }
        }

        public static void Abheben(decimal betrag)
        {
            try
            {
                //Erste Thread darf in lock .... weitere Thread(s) müssen warten 
                lock (lockFlackAbheben)
                {
                    TransactionId++;
                    Kontostand -= betrag;

                    Console.WriteLine($"{TransactionId} \t Kontostand nach dem Abheben: {Kontostand}");
                }
            }
            catch (Exception ex)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Deadlock juhuuu");
            }
        }
    }
}
