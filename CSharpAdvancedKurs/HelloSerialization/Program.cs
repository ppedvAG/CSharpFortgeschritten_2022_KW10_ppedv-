using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;

namespace HelloSerialization
{
    //Serialisierung -> Speichern von Objekten in eine Datei
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Person person = new Person()
            {
                Vorname = "Max",
                Nachname = "Moritz",
                Alter = 19,
                Kontostand = 5_000,
                KreditLimit = 50_000
            };

            Stream stream = null;

            ////Binär 
            //BinaryFormatter binaryFormatter = new BinaryFormatter();
            //stream = File.OpenWrite("Person.bin");
            //binaryFormatter.Serialize(stream, person);
            //stream.Close();

            ////einelesen
            //stream = File.OpenRead("Person.bin");
            //Person binPerson = (Person)binaryFormatter.Deserialize(stream);
            //stream.Close();

            //XML
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Person));
            stream = File.OpenWrite("Person.xml");
            xmlSerializer.Serialize(stream, person);
            stream.Close();


            stream = File.OpenRead("Person.xml");
            Person xmlPerson = (Person)xmlSerializer.Deserialize(stream);
            stream.Close();


            //JSON
            string jsonString = JsonConvert.SerializeObject(person);
            await File.WriteAllTextAsync("Person.json", jsonString);

            //auslesen
            string readedJsonString = await File.ReadAllTextAsync("Person.json");
            Person jsonPeron = JsonConvert.DeserializeObject<Person>(readedJsonString);




            //Eigenen CSV Parser mit Erweiterungsmethode
            person.Speichern("Person.csv");

            Person csvPerson = new Person();
            csvPerson.Laden("Person.csv");


            List<string> strList = new List<string>();
            strList.Where
        }
    }

    [Serializable]
    
    public class Person
    {
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Alter { get; set; }

        //[field:NonSerialized]
        [JsonIgnore]
        [XmlIgnore]
        public decimal Kontostand { get; set; }

        /*[field:NonSerialized]  *///Achtung auch bei NewtonSoft wirkt diese Codezeile
        [XmlIgnore]
        [JsonIgnore]
        public decimal KreditLimit;
    }
}
