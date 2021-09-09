#region Code Identifications

// Created on     2017/08/15
// Last update on 2018/03/14 by Mohammad Mir mostafa 

#endregion

using System;

namespace TestConsole45
{
    partial class App
    {
        protected override void Execute()
        {
            var x = -1.0;
            var a = 0.0;
            while (x < 1)
            {
                a = a + Math.Sqrt(1 - Math.Pow(x, 2)) * 0.1;
                x += 0.1;
            }
            var tpi = 2 * a;
            Console.WriteLine("Calc PI = {0}", tpi);
            Console.WriteLine("     PI = {0}", Math.PI);
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
}