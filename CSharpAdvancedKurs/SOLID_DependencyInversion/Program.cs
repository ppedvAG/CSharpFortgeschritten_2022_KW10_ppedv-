using System;

namespace SOLID_DependencyInversion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarService();

            ICar testCar = new DummyCar();

            carService.Repair(testCar); //für Test ist das super! 

            ICar car = new Car();
            car.Marke = "VW";
            car.Modell = "Käfer";
            car.Baujahr = 1977;

            carService.Repair(car); //für Produktiv 
        }
    }

    //Programmierer A: 5 Tage (Fängt Tag 1 an und arbeitet bis Tag 5)
    public class BadCar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }  
        public int Baujahr { get; set; }
    }


    //Programmierer B: 3 Tage (Fängt Tag 5/6 an und arbeitet bis Tag 8/9)
    public class BadCarService
    {
        public void Repair(BadCar car) //Feste Kopplung 
        {
            //repariere Auto
        }
    }


    #region Bessere Variante

    //Contract First Tag1
    public interface ICar
    {
        string Marke { get; set; }
        string Modell { get; set; } 
        int Baujahr { get;set; }
    }

    public interface ICarService
    {
        void Repair(ICar car); //Lose Kopplung 
    }

    //Programmierer A: 5 Tage -> Startet Tag 1 bis Tag 5
    public class Car : ICar
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }
    }

    //Programmierer B: 3 Tage -> Startet Tag bis Tag 3
    public class CarService : ICarService
    {
        public void Repair(ICar car)
        {
           //repariere Auto
        }
    }


    //Dummy-Object oder Mock-Object oder Stub-Object
    public class DummyCar : ICar
    {
        public string Marke { get; set; } = "VW";
        public string Modell { get; set; } = "Polo";
        public int Baujahr { get; set; } = 2000;

    }



    #endregion

}
