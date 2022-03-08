using System;
using System.Threading;

namespace _004_ThreadWithParametersAndReturnValue
{
    internal class Program
    {
        private static string retString = string.Empty;
        private static string meinText = "Hello World";


        static void Main(string[] args)
        {
            Thread thread = new Thread(() =>
            {
                //anonyme Methode
                retString = StringToUpper(meinText);

            });
            thread.Start();


            //Ausgelagerte Methode im Vergleich zur obigen anoymen Methode
            Thread thread1 = new Thread(AusgelagerteMethode);
            thread1.Start();
            thread1.Join();
        }

        public static string StringToUpper(string param)
        {
            return param.ToUpper(); 
        }


        public static void AusgelagerteMethode()
        {
            retString = StringToUpper(meinText);
        }



    }
}
