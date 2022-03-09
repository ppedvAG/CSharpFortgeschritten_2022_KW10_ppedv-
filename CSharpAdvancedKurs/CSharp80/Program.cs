using System;

namespace CSharp80
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region $ und @ Strings
            int Zahl1 = 123;
            string halloWelt = "Hallo Welt";

            Console.WriteLine("Ausgabe der Variablen " + Zahl1.ToString() + " Ausgabe Text: " + halloWelt);

            Console.WriteLine("Ausgabe der Variablen {0} Ausgabe Text: {1}",Zahl1, halloWelt);

            Console.WriteLine($"Ausgabe der Variable {Zahl1} Ausgabe Text: {halloWelt}");


            string Pfad = "C:\\Windows\\Temp";
            string withEscape = "hallo \t Welt";

            string PfadWithoutEscapes = @"C:\Windows\Temp";

            string myPath = $@"{PfadWithoutEscapes}\n\t";
            #endregion


            IVehicle vehicle = new Vehicle();
            vehicle.StarteMotor();
            vehicle.Tanken();



            Vehicle2 vehilce2 = new Vehicle2();
            vehilce2.Tanken();

            IVehicle castVehicle = (IVehicle)vehilce2;
            castVehicle.Tanken();
            castVehicle.StarteMotor();


            IVehicle2 vehicle2 = new Vehicle2();
            vehicle2.Tanken();
            vehicle2.StarteMotor();



        }
    }


    //Klassik
    public interface IVehicle
    {
        void Tanken();
        void StarteMotor();
    }

    public class Vehicle : IVehicle
    {
        public void StarteMotor()
        {
            Console.WriteLine("Starte Motor");
        }

        public void Tanken()
        {
            Console.WriteLine("Tanken");
        }
    }

    //Interface with Default-Implementation 


    public interface IVehicle2
    {
        void Tanken();
        public void StarteMotor()
        {
            Console.WriteLine("Starte Motor aus IVehivle2 heraus");
            BrumBrum();
        }

        private void BrumBrum()
        {
            Console.WriteLine("Brum Brum");
        }
    }

    public class Vehicle2 : IVehicle2
    {
        public void Lenken()
        {
            throw new NotImplementedException();
        }

        public void Tanken()
        {
            Console.WriteLine("Tanken");
        }
    }

   


}
