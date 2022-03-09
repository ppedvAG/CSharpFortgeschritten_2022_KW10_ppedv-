using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloSerialization
{
    //Eweiterungsmethoden stehen in einer static class + static Methode
    public static class CSVSerializer
    {

        /// <summary>
        /// Speichert eine Person in eine CSV Datei
        /// </summary>
        /// <param name="o">das eigene Personen</param>
        /// <param name="savePath"></param>
        public static void Speichern(this Person p, string savePath)
        {
            File.WriteAllText(savePath, $"{p.Vorname};{p.Nachname};{p.Alter};{p.Kontostand};{p.KreditLimit}");
        }

        public static void Laden(this Person p, string filepath)
        {
            string content = File.ReadAllText(filepath);

            string[] csvPart = content.Split(';');

            p.Vorname = csvPart[0];
            p.Nachname = csvPart[1];
            p.Alter = int.Parse(csvPart[2]);
            p.Kontostand = Convert.ToInt32(csvPart[3]);
            p.KreditLimit = Convert.ToInt32(csvPart[4]);
        }
    }
}
