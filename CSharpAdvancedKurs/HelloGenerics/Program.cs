using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloGenerics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> stringListe = new List<string>(); //intern wird ein Array verwendet (Default-Greöße = 4) 
            stringListe.Add("Max");
            stringListe.Add("Moritz");



            IDictionary<int , string> dictionary = new Dictionary<int , string>();
            dictionary.Add(1, "Peter");
            dictionary.Add(2, "Petra");

            foreach(KeyValuePair<int , string> pair in dictionary)
            {
                //pair.Key
                //pair.Value
            }

            KeyValuePair<int, string> myNewItem = new KeyValuePair<int, string>(3, "Hannes");
            dictionary.Add(myNewItem);

            //Mengenvergleich 
            //if (dictionary.ContainsKey())
        }
    }

    public class DataStore<T>
    {
        private T[] _data = new T[10];

        public T[] Data
        {
            get => _data;
            set => _data = value;
        }

        public T GetDataOrDefault(int index)
        {
            if (index >= 0 && index < 10)
                return _data[index];
            else
                return default(T); // T == null
        }


        public void AddOrUpdate(int index, T item)
        {
            if (index >= 0 && index < 10)
                _data[index] = item;
        }

        public void DisplayDefault<MyType>()
        {
            MyType item1 = default!;
            MyType item = default(MyType);
            Console.WriteLine($"Default value of {typeof(MyType)} is {(item == null ? "null" : item.ToString())}.");
        }
    }


}
