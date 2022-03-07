using System;

namespace DelegatesActionsFuncsSamples
{
    delegate int ChangeNumber(int number); //Dieses Delegate kann mit Allen Methoden zusammenarbeiten, die ein int-Rücke + int Paramter vorweisen
    delegate void MultipleDelagte();

    public class Program
    {
        static void MyMethode(out int a, out int b) { a = b = 0; }

        public delegate void OutAction<T1, T2>(out T1 a, out T2 b);

        
       
        static void Main(string[] args)
        {
            #region Delegate
            ChangeNumber changeNumber = new ChangeNumber(Offset5); //Funktionzeiger der Methode
            Console.WriteLine(changeNumber(12));

            MultipleDelagte multipleDelagte = new MultipleDelagte(Load1);
            multipleDelagte += Load2; //mithilfe des += Operators können wir weiter Methoden dranhängen
            multipleDelagte();
            multipleDelagte -= Load1;

            ChangeNumber mulitChangeNumber = new ChangeNumber(Offset5);
            mulitChangeNumber += Offset7;
            int result = mulitChangeNumber(11);
            #endregion

            #region Action
            // Action arbeiten mit Methoden zusammen, die kein Rückgabetyp haben-> VOID
            Action<int> myOffSetActionDelegate = new Action<int>(ShowOffset5);
            myOffSetActionDelegate += ShowOffset7;
            myOffSetActionDelegate(11);
            #endregion

            OutAction<int, int> action = MyMethode;
            int a = 3, b = 5;
            Console.WriteLine("{0}/{1}", a, b);
            action(out a, out b);
            Console.WriteLine("{0}/{1}", a, b);
            Console.ReadKey();


            #region Func Sample
            Func<int, int> myOffSetFuncDelegate = new Func<int, int>(Offset5);

            Func<int, int, int> myOffSetFunDelegate2 = new Func<int, int, int>(Addieren);

            Console.WriteLine(myOffSetFunDelegate2(11, 11));
            #endregion

        }


        static void ShowSet11(ref int zahl1) //ich bin eine Referenz und habe Narrenfreiheit
        {
            zahl1 = 9; //out benötigt immer eine Zuweisung
        }

        static void ShowSet13(in int zahl1)//Referenz die nur readonly ist
        {
            Console.WriteLine(zahl1);
        }
        

        static void ShowSet9(out int zahl1) //Out ist eine Referenz -> aber muss einen Wert zugewiesen bekommen
        {
            zahl1 = 9; //out benötigt immer eine Zuweisung
        }
        static void ShowOffset5(int zahl1)
        {
            Console.WriteLine(zahl1 + 5);
        }

        static void ShowOffset7(int zahl1)
        {
            Console.WriteLine(zahl1 + 7);
        }
        static int Offset5(int zahl1)
            => zahl1 + 5;

        static int Offset7(int zahl)
            => zahl + 7;

        static int Addieren(int zahl1, int zahl2)
            => zahl1 + zahl2;

        static void Load1()
        {

        }
        static void Load2()
        {

        }
    }

    public class ParameterWrapperClass
    {
        public int Param1 { get; set; }
        public int Param2 { get; set; } 
    }

    
}
