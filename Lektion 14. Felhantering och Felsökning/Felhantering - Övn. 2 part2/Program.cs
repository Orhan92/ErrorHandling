using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*
 Skriv ett program som visar upp en samling filmtitlar från en array och ber användaren att välja en av dem genom att mata in index på alternativet (genom att mata in en siffra, inte genom ShowMenu). När användaren har valt ett alternativ ska programmet skriva ut för användaren vilken filmtitel de valde.

Om användaren matar in ett felaktigt index (alltså mindre/större än arrayens minsta/största index) ska programmet be användaren om nytt värde tills de matar in ett giltigt värde. Lös denna uppgift på två olika sätt:

Med if-satser. ("Be om tillåtelse")
 */
namespace Felhantering___Övn._2_part2
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            var movieTitles = new[]
            {
                "Gladiator [0]",
                "Lion King [1]",
                "Rapunzel [2]",
                "Mickey Mouse [3]",
                "Titanic [4]"
            };

            foreach (string title in movieTitles)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();
            Console.WriteLine("Choose movie title by typing in the number of the movie title and press Enter: ");

            bool running = true;
            while (running)
            {
                int userChoice = int.Parse(Console.ReadLine());

                if (userChoice < 0 || userChoice >= movieTitles.Length)
                {
                    Console.WriteLine("You did not type in a valid number to display any of the titles, try again: ");
                }

                for (int i = 0; i < movieTitles.Length; i++)
                {
                    if (userChoice == i)
                    {
                        Console.WriteLine("You picked movie: " + movieTitles[i]);
                        running = false;
                    }
                }
            }
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
