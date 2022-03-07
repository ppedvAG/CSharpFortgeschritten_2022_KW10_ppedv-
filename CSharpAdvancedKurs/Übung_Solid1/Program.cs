using System;

namespace Übung_Solid1
{
    class Program
    {
        static void Main(string[] args)
        {
            IReportGenerator reportGenerator = new PDFReportGenerator();

            IReportGenerator list10Generator = new List10();

            ReportGeneratorBase crystalReportGenerator = new CrystalReports();

        }
    }


    #region Bad Code

    public class BadEmployee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }

        public string ReportType { get; set; }

        /// <summary>
        /// This method used to insert into employee table
        /// </summary>
        /// <param name="em">Employee object</param>
        /// <returns>Successfully inserted or not</returns>
        public bool InsertIntoEmployeeTable(BadEmployee em)
        {
            // Insert into employee table.
            return true;
        }
        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>


        public void GenerateReport(BadEmployee em)
        {
            if (ReportType == "CRS")
            {
                // Report generation with employee data in Crystal Report.
            }
            if (ReportType == "PDF")
            {
                // Report generation with employee data in PDF.
            }
        }
    }

    #endregion


    public interface IEmployee
    {
        string Marke { get; set; }
        string Modell { get; set; }
        int Baujahr { get; set; }
    }

    public class Employee : IEmployee
    {
        public string Marke { get; set; }
        public string Modell { get; set; }
        public int Baujahr { get; set; }
    }

    //Variante 1
    public class EmployeeRepository
    {
        public void Insert(Employee employee)
        {
            //speicher einen Datensatz
        }
    }


    #region Open Part
    //Variante 1

    public interface IReportGenerator
    {
        //C# 9.0 auf .NET 5
        void Init ()
        {
            Console.WriteLine("Meine Basis Implementierung");
        }

        void Generate(IEmployee em);
    }

    //Variante 2
    public abstract class ReportGeneratorBase
    {
        public string OutPutDirectory { get; set; }
        void Init()
        {
            Console.WriteLine("Meine Basis Implementierung");
        }

        public virtual string ShowReportVersion()
        {
           return "Virtual Methode";
        }
        public abstract void Generate(IEmployee em);
    }

    //Variante 1 und 2 in Kombination
    public abstract class ReportGeneratorBase2 : IReportGenerator
    {
        public abstract void Generate(IEmployee em);
    }
    #endregion

    #region Close Part
    //Variante 1 mit Interface
    public class PDFReportGenerator : IReportGenerator
    {
        public void Generate(IEmployee em)
        {
            //Erstelle ein Report
        }
    }

    //Variante 2 mit abstract class

    public class CrystalReports : ReportGeneratorBase
    {
        public override void Generate(IEmployee em)
        {
            //Erstelle ein Report
        }
    }


    public class List10 : ReportGeneratorBase2 
    {
        public override void Generate(IEmployee em)
        {
           //Erstelle ein Report
        }
    }
    #endregion























}
