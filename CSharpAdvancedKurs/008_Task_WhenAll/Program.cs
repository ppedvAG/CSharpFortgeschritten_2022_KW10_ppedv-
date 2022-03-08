using System;
using System.Collections.Generic; //List
using System.Threading;
using System.Threading.Tasks;

namespace _008_Task_WhenAll
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Task<int>> taskCollection = new List<Task<int>>();

            for (int counter =1; counter <= 10; counter++)
            {
                int baseValue = counter;

                taskCollection.Add(Task.Factory.StartNew(GetSquareValue, baseValue));
            }

            //Ergebnisse werden heraus extrahiert
            Task<int[]> taskResults = Task.WhenAll(taskCollection); //Alle Tasks müssen in der List fertig verarbeitet werden 
            //1,4,9,16,25,36,49,65,81,100

            int[] results = taskResults.Result;


            int sum = 0;

            for (int counter =0; counter < results.Length;counter++)
            {
                var result = results[counter];
                Console.Write($"{result}{((counter == results.Length - 1) ? "=" : "+")}");
                sum += result;
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }

        public static int GetSquareValue(object baseValue)
        {
            Random rand = new Random();

            int sec = rand.Next(5000, 10000);

            Thread.Sleep(sec);

            return (int)baseValue * (int)baseValue;
        }
                
    }
}
