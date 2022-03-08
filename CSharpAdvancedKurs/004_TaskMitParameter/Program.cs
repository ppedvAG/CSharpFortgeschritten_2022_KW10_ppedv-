using System;
using System.Threading.Tasks;

namespace _004_TaskMitParameter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Katze katze = new Katze();


            //Methoden mit Rückgabe-Werte werde mit Task<T> verwendet
            Task<string> task = new Task<string>(MachEtwas, katze);

            task.Start();
            task.Wait();
            Console.WriteLine(task.Result); //Task.Result ist der selbe Typ, den wir bei Task<STRING> eingeben 

            Task<string> taks1 = new Task<string>(() => MachEtwas(katze));
            taks1.Start();
            taks1.Wait();

            //Via Factory

            Task<string> task2 = Task.Factory.StartNew(MachEtwas, katze);
            task2.Wait();
            Console.WriteLine(task2.Result);

            //Task.Run
            Task<string> task3 = new Task<string>(()=>MachEtwas(katze));
            task3.Wait();
            string result = task3.Result;



        }

        private static string MachEtwas(object input)
        {
            if (input is Katze myCat)
            {
                return myCat.Name; //Name wird zurückgegeen
            }

            throw new ArgumentException();
        }
    }

    public class Katze
    {
        public string Name { get; set; } = "Maya";
    }
}
