using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

//Utöka metoderna ReadInt och ReadDouble från lektion 8 så att de även klarar av att användaren matar in något annat än ett tal, och i detta fall ber användaren om nytt värde tills de matar in ett giltigt värde.

namespace Lektion_14.Felhantering_och_Felsökning
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            ReadDouble(); //Om användaren knappar in 5,55 så blir svaret 555. Om användaren knappar in 5.55 så blir svaret rätt: 5.55
        }
        public static int ReadInt()
        {
            Console.Write("Enter a number: ");
            int value = 0;

            bool running = true;
            while (running)
            {
                try
                {
                    value = int.Parse(Console.ReadLine());
                    Console.WriteLine("Thank you. Your number input is: " + value);
                    running = false;
                }
                catch
                {
                    Console.WriteLine("You did not enter a valid integer.");
                    Console.WriteLine("Try again: ");
                }
            }
            return value;
        }

        public static double ReadDouble()
        {
            Console.WriteLine("Enter a number with decimals: ");
            double value = 0;

            bool running = true;
            while (running)
            {
                try
                {
                    value = double.Parse(Console.ReadLine());
                    Console.WriteLine("Thank you. Your number input is: " + value);
                    running = false;
                }

                catch
                {
                    Console.WriteLine("You did not enter a valid number with decimals.");
                    Console.WriteLine("Try again: ");
                }
            }
            return value;
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
