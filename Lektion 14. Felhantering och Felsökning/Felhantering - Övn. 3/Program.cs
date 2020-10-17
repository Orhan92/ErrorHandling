using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*
Gå tillbaka till programmet för BMI-beräkning och svara på följande frågor:

Vad händer om användaren matar in noll som längd? Varför? Hur kan detta hanteras? 
//Jag får svaret: Infinity, Felhantering

Testa att använda int istället för double till vikten och längden. Vad händer i detta scenario om användaren matar in noll som längd? Hur kan detta hanteras?
//Får svaret: Infinity, om jag knappar in 0 på både längd och vikt så får vi svaret: NaN

Detta scenario är inte ett användbart program eftersom det bara fungerar för personer som är exakt 1 eller 2 meter långa, men det kan ni strunta i för denna övning.
*/
namespace Felhantering___Övn._3
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            // Input
            Console.Write("Please enter your weight: ");
            int weight = int.Parse(Console.ReadLine());

            Console.Write("Please enter your height: ");
            int height = int.Parse(Console.ReadLine());

            // Computation
            double bmi = weight / Math.Pow(height, 2);
            double rounded = Math.Round(bmi, 1);

            // Output
            Console.WriteLine("Your BMI is: " + rounded);
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {
            using FakeConsole console = new FakeConsole("First input", "Second input");
            Program.Main();
            Assert.AreEqual("Hello!", console.Output);
        }
    }
}
