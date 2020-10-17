using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

/*
Följande program läser in en sträng bekräftar att det är ett giltig lösenord enligt följande regler:

Minst 8 tecken långt.
Innehåller minst en stor bokstav.
Innehåller minst en liten bokstav.
Innehåller minst en siffra.
Inmatningen Aa11Bb22 ger exempelvis resultatet true.

Programmet innehåller ett fel. Utgå från den här felrapporten: "Programmet ger fel resultat när jag matar in sw2e1op26ijh8ygw4oit."

Hitta nu minimal indata som fortfarande ger fel resultat, enbart genom att köra programmet och utan att läsa källkoden. När ni har hittat vad ni tror är minimal indata, läs källkoden och ändra den så att programmet fungerar.
*/
namespace Felsökning___Övn._2
{
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            while (true)
            {
                Console.Write("Enter password to validate: ");
                string input = Console.ReadLine();

                Console.WriteLine(ValidPassword(input));

                Console.WriteLine();
            }
        }

        // Check that a password follows these rules:
        //
        // - at least 8 characters long
        // - contains at least one uppercase letter
        // - contains at least one lowercase letter
        // - contains at least one number
        //
        // For example, ValidPassword("Aa11Bb22") returns true.
        public static bool ValidPassword(string password)
        {
            bool valid = false;

            if (password.Length >= 8)
            {
                valid = true;
            }

            int upperCaseCount = password.Count(c => Char.IsUpper(c));
            valid = valid && upperCaseCount > 0;

            int lowerCaseCount = password.Count(c => Char.IsLower(c));
            valid = valid && lowerCaseCount > 0; //Felet var att det tidigare stod: valid = lowerCaseCount > 0; saknade valid = valid

            int numberCount = password.Count(c => Char.IsNumber(c));
            valid = valid && numberCount > 0;

            return valid;
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void FirstCondition()        // - at least 8 characters long
        {
            bool result;
            Assert.AreEqual(result = false, Program.ValidPassword("orhanalbayati"));
        }
        [TestMethod]
        public void FirstAndSecondCondition()         // - at least 8 characters long  
                                                      //contains at least one uppercase letter
        {
            bool result;
            Assert.AreEqual(result = false, Program.ValidPassword("Orhanalbayati"));
        }
        [TestMethod]
        public void FirstSecondThirdCondition()        // - at least 8 characters long
                                                       // - contains at least one uppercase letter
                                                       // - contains at least one lowercase letter
        {
            bool result;
            Assert.AreEqual(result = false, Program.ValidPassword("Orhanalbayati"));
        }
        [TestMethod]
        public void AllConditions()        // - at least 8 characters long
                                           // - contains at least one uppercase letter
                                           // - contains at least one lowercase letter
                                           // - contains at least one number
        {
            bool result;
            Assert.AreEqual(result = true, Program.ValidPassword("Orhanalbayati1"));
        }
        [TestMethod]
        public void ShouldBeFalse1()        // - at least 8 characters long
        {
            bool result;
            Assert.AreEqual(result = false, Program.ValidPassword("sw2e1op26ijh8ygw4oit"));
        }
        [TestMethod]
        public void ShouldBeFalse2()        // - at least 8 characters long
        {
            bool result;
            Assert.AreEqual(result = false, Program.ValidPassword("hejhej88"));
        }
        [TestMethod]
        public void ShouldBeTrue()        // - at least 8 characters long
        {
            bool result;
            Assert.AreEqual(result = true, Program.ValidPassword("HejHej88"));
        }
    }
}
