using System;

namespace SOLID_OpenClosePrincipe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Employee
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
    }

    public class BadReportGenerator
    {
        public string ReportType { get; set; } = string.Empty; 

        //Negative folgen -> Methode GenerateReport wird zuviele Zeilen beinhalten + mehrere Dlls werden hier anprogrammiert. 
        public void GenerateReport(Employee em)
        {
            if (ReportType == "CR")
            {
                //Möglickeiten mit Crystal Report Dll zusammen zu arbeiten
            }
            else if (ReportType == "List10")
            {

            }
            else if (ReportType == "PDF")
            {

            }
        }


        //WEitere Methoden für die jeweiligen Libraries entstehen 
    }

    //Open Prinzip umreißt die Lösung
    public abstract class ReportGenerator
    {
        public abstract void GenerateReport(Employee em);   //abstrakte Methoden müssen überschrieben werden
    }


    //Close-Prinzip Implementiert 
    public class PDFReportGenerator : ReportGenerator
    {
        public override void GenerateReport(Employee em)
        {
            //any Code
        }

        //Compress Rate 
        //Watermarks
    }


    //Close-Prinzip Implementiert 
    public class CrystalReports : ReportGenerator
    {
        public override void GenerateReport(Employee em)
        {
            
        }

        //Template Vorlagen
        //Template Verzeichnis
    }
}
