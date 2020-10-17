using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*
Utöka programmet för BMI-beräkning så att användaren måste mata in en vikt på mellan 10 och 1,000 kilogram samt en längd mellan 0.1 och 3 meter (eftersom värden utanför dessa intervall troligtvis är felaktiga inmatningar). Vilken felhanteringsteknik är mest lämplig här? Välj en och motivera svaret.

//Använder en "Be om tillåtelse" - IF satser. Man kan använda båda för att fånga upp fel sifferinmatning + stringar
*/
namespace Felhantering___Övn._4
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            double weight = 0;
            double height = 0;

            bool running = true;
            while (running)
            {
                try
                {
                    Console.Write("Please enter your weight: ");
                    weight = double.Parse(Console.ReadLine());
                    Console.Write("Please enter your height: ");
                    height = double.Parse(Console.ReadLine());
                    if (weight > 1000 || weight < 10)
                    {
                        Console.WriteLine("That's not a reliable weight input (try between 10 - 1000). Try again: ");
                    }


                    else if (height < 0.10 || height > 3)
                    {
                        Console.WriteLine("That's not a reliable height input (try between 0.1 - 3). Try again: ");
                    }


                    else
                    {
                        running = false;
                    }
                }

                catch
                {
                    Console.WriteLine("Invalid format.");
                }
            }
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

