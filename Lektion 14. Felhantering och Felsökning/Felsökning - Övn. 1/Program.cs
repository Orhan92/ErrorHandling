using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
Följande program läser in en sträng och ett heltal och upprepar strängen detta antal gånger. Inmatningen ha och 3 ger exempelvis resultatet hahaha.

Programmet innehåller ett fel. Utgå från den här felrapporten: "Programmet ger fel resultat när jag matar in Brad Pitt och 5."

Hitta nu minimal indata som fortfarande ger fel resultat, enbart genom att köra programmet och utan att läsa källkoden. När ni har hittat vad ni tror är minimal indata, läs källkoden och ändra den så att programmet fungerar.
*/
namespace Felsökning___Övn._1
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            while (true)
            {
                Console.Write("Enter text to repeat: ");
                string input = Console.ReadLine();

                Console.Write("Enter number of times to repeat: ");
                int count = int.Parse(Console.ReadLine());

                Console.WriteLine(Repeat(input, count));

                Console.WriteLine();
            }
        }

        // Repeat a string the specified number of times.
        // For example, Repeat("ha", 3) returns "hahaha".
        public static string Repeat(string original, int count)
        {
            string repeated = "";
            for (int i = 0; i < count; i++) //Felet var tidigare att det stod ; i <= count;     tog bort =
            {
                repeated += original;
            }
            return repeated;
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
