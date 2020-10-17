using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
/*
 Skriv ett program som visar upp en samling filmtitlar från en array och ber användaren att välja en av dem genom att mata in index på alternativet (genom att mata in en siffra, inte genom ShowMenu). När användaren har valt ett alternativ ska programmet skriva ut för användaren vilken filmtitel de valde.

Om användaren matar in ett felaktigt index (alltså mindre/större än arrayens minsta/största index) ska programmet be användaren om nytt värde tills de matar in ett giltigt värde. Lös denna uppgift på två olika sätt:

Med exceptions. ("Be om ursäkt")
 */
namespace Felhantering___Övn._2
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
                try
                {
                    int userChoice = int.Parse(Console.ReadLine());
                    for (int i = userChoice; i <= userChoice; i++)
                    {
                        i = userChoice;
                        Console.WriteLine("You selected: " + movieTitles[i]);
                        running = false;
                    }
                }
                catch
                {
                    Console.WriteLine("You did not pick a valid movie title. You might have used a wrong number input. Try again: ");
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
