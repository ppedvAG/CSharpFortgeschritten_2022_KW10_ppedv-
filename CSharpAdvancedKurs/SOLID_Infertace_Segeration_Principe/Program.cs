using System;

namespace SOLID_Infertace_Segeration_Principe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public interface IBadVehicle
    {
        void ICanFly();
        void ICanDrive();
        void ICanSwim();
    }

    public class MulitVehicle : IBadVehicle
    {
        public void ICanDrive()
        {
           //Fahren
        }

        public void ICanFly()
        {
            //Fahren
        }

        public void ICanSwim()
        {
            //Schwimmen
        }
    }

    public class BadCarVehicle : IBadVehicle
    {
        public void ICanDrive()
        {
            //Fahren
        }


        //Implementierung wird nicht beötigt
        public void ICanFly()
        {
            throw new NotImplementedException(); 
        }

        //Implementierung wird nicht beötigt
        public void ICanSwim()
        {
            throw new NotImplementedException();
        }
    }


    public interface IFlyVehicle
    {
        void Fly();
    }

    public interface IDriveVehicle
    {
        void Drive();
    }

    public interface ISwimVehicle
    {
        void Swim();
    }


    public class MultiVehicle2 : IFlyVehicle, IDriveVehicle, ISwimVehicle
    {
        public void Drive()
        {
            throw new NotImplementedException();
        }

        public void Fly()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

    public class AmphibischeVehicle : ISwimVehicle, IDriveVehicle
    {
        public void Drive()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

}
