using System;

namespace SOLID_SingleResponsibilityPrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    #region BadCode

    public class BadEmployee
    {
        //Datenstruktur
        public int Id { get; set; } 
        public string Name { get; set; }


        //Methode im DataAccess Layer
        public void InsertEmployeeToTable(BadEmployee employee)
        {
            //any Code
        }


        //Export-Methode - Service Layer oder Export->UI Präsentation-Layer
        public void GenerateReport()
        {
            //any Code
        }
    }
    #endregion

    #region Bessere Variante
    public class Employee
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
    }

    public class EmployeeRepository
    {
        public void Insert(Employee employee)
        {
            //Any Code
        }
    }

    public class GenerateReport
    {
        public void Generate()
        {
            //any Code
        }
    }
    #endregion
}
