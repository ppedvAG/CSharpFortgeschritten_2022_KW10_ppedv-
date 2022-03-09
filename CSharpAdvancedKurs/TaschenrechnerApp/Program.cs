﻿using System;
using System.Reflection;

namespace TaschenrechnerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly geladeneDll = Assembly.LoadFrom("Taschenrechner.dll");

            Type taschenrechnerClassAsType = geladeneDll.GetType("Taschenrechner.MyCalc");
            
            //Wir erstellen eine Instanz von -> Merken uns den Class-Zeiger von Taschenrechner-Klasse -> tr
            object tr = Activator.CreateInstance(taschenrechnerClassAsType);
            
            MethodInfo methodInfo = taschenrechnerClassAsType.GetMethod("Add", new Type[] {typeof(Int32), typeof(Int32)});

            object result = methodInfo.Invoke(tr, new object[] { 11, 22 });

            
            Console.WriteLine(result); //33
        }
    }
}
