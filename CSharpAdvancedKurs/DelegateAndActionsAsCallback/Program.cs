using System;

namespace DelegateAndActionsAsCallback
{
    public delegate void ResultDelegate (string msg);
    public delegate void PercentChangeDelegate(int percent);
    internal class Program
    {
        static void Main(string[] args)
        {
            MyApp myApp = new MyApp();

            ResultDelegate resultDelegate = new ResultDelegate(myApp.ShowResult);
            PercentChangeDelegate percentChangeDelegate = new PercentChangeDelegate(myApp.ShowPercent);

            Process(resultDelegate, percentChangeDelegate);
        }

        public static void Process(ResultDelegate resultDelegate, PercentChangeDelegate percentChangeDelegate)
        {
            //Rechenintensives
            //for + tab + tab
            for (int i = 0; i < 100; i++)
            {
                percentChangeDelegate(i);
            }


            //ShowResult("fertig"); 
            resultDelegate("fertig");
        }

        public static void ShowResult(string msg)
        {
            Console.WriteLine(msg);
        }
    }

    public class MyApp
    {
        public void ShowResult(string msg)
        {
            Console.WriteLine(msg);
        }

        public void ShowPercent(int percent)
        {
            Console.WriteLine(percent);
        }
    }
}
