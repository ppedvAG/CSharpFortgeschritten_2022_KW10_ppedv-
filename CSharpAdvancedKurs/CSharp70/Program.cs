using System;

namespace CSharp70
{
    internal class Program
    {
        public static string Vorname { get; set; }
        public static string Nachname { get; set; }
        public static string ZweiterVorname { get; set; }

        public static (string, string, string) VollenNamenAusgeben()
        {
            return (Vorname, !string.IsNullOrEmpty(ZweiterVorname) ? ZweiterVorname : string.Empty, Nachname);
        }



        public static ref int Zahlensuche(int gesuchteZahl, int[] zahlen)
        {
            for (int i = 0; i < zahlen.Length; i++)
            {
                if (zahlen[i] == gesuchteZahl)
                    return ref zahlen[i];
            }

            throw new IndexOutOfRangeException();
        }


        static void Main(string[] args)
        {
            (string firstName, string SecondFirstName, string LastName) = VollenNamenAusgeben();

            (string Vorname, string ZweiterVorname, _) = VollenNamenAusgeben(); //ausblenden von Felder mit _



            //Deconstruct Sample
            Kunde kunde = new Kunde() { Id= 123, Name = "Harry Weinfuhrt", Stammkunde = true };

            var (id, name, stammkunde) = kunde;


            //Rückgabe per Referenz

            int[] zahlen = { 5, 7, 123, 456, 789, 321, 654 };
            ref int position = ref Zahlensuche(789, zahlen);

            position = 100_000_000;
            Console.WriteLine(zahlen[4]); //100_000_000

        }


    }


    public class Kunde
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Stammkunde { get; set; }

        public void Deconstruct(out int Id, out string Name, out bool Stammkunde)
        {
            Id = this.Id;
            Name = this.Name;
            Stammkunde = this.Stammkunde;
        }

    }
}
