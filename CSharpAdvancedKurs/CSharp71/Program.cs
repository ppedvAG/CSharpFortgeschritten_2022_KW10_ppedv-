using System;

namespace CSharp71
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Summe(11, 22);
            Summe(12, 12, 12);


        }

        public static long Summe(int zahl1, int zahl2 = default, int zahl3 = default)
        {
            return zahl1 + zahl2 + zahl3; //default = 0
        }
    }
}
