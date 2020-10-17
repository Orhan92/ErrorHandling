using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
 * Följande program läser in en sträng kontrollerar om den är ett palindrom (alltså samma baklänges som framlänges). Det bryr sig enbart om bokstäver och struntar i skillnaden mellan små och stora bokstäver. Inmatningen A man, a plan, a canal: Panama! ger exempelvis resultatet true.

 * Programmet innehåller ett fel. Utgå från den här felrapporten: "Programmet ger fel resultat när jag matar in A man, a plan, a canal: Panama!."

 * Hitta nu minimal indata som fortfarande ger fel resultat, enbart genom att köra programmet och utan att läsa källkoden. När ni har hittat vad ni tror är minimal indata, läs källkoden och ändra den så att programmet fungerar.
 */
namespace Felsökning___Övn._3
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            while (true)
            {
                Console.Write("Enter text to check for palindrome: ");
                string input = Console.ReadLine();

                Console.WriteLine(IsPalindrome(input));

                Console.WriteLine();
            }
        }

        // Check if a string is the same backwards as forwards, disregarding everything except letters, and treating uppercase and lowercase letters as equal.
        // For example, IsPalindrome("A man, a plan, a canal: Panama!") returns true.
        public static bool IsPalindrome(string text)
        {
            string normalized = "";
            foreach (char c in text)
            {
                if (Char.IsLetter(c))// || c == ' ')    Det bortkommenterade var felet i koden. 
                    //Antar att .Isletter inte räknar med tecken då, det innehåller endast bokstäver. Får fråga Jakob om IsLetter endast räknar med bokstäver då. 
                {
                    normalized += c; 
                }
            }
            normalized = normalized.ToLower();

            string reversed = "";
            foreach (char c in normalized)
            {
                reversed = c + reversed;
            }

            return normalized == reversed;
        }
    }

    [TestClass]
    public class ProgramTests
    {
        bool result;

        [TestMethod]
        public void FirstPalindrome()        // - at least 8 characters long
        {  
            Assert.AreEqual(result = true, Program.IsPalindrome("A man, a plan, a canal: Panama!"));
        }
        [TestMethod]
        public void SecondPalindrome()        // - at least 8 characters long
        {
            Assert.AreEqual(result = true, Program.IsPalindrome("Eva, Can I Stab Bats In A Cave?"));
        }
        [TestMethod]
        public void ThirdPalindrome()        // - at least 8 characters long
        {
            Assert.AreEqual(result = true, Program.IsPalindrome("Madam In Eden, I'm Adam"));
        }
        [TestMethod]
        public void FourthPalindrome()        // - at least 8 characters long
        {
            Assert.AreEqual(result = true, Program.IsPalindrome("Eva, can I see bees in a cave?"));
        }

    }
}
