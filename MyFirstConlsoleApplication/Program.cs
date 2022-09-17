using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApplication
{
    internal class Program
    {
        static void Main()
        {
            // 3.7 Add this method into the Main method at the top.
            GetUserNameAndLocation();
            // 4.7 Add this method into the Main method under the GetUserNameAndLocation method call. 
            ChristmasCountDown();

            Console.WriteLine("\n");
            // 5.6 Call the RunExample method from the Program Class under Main and place it beneath the  ChristmasCountdown call.
            GlazerApp.RunExample();
        }
        /*  3. In the Program.cs class file, create a new private method called "GetUserNameAndLocation".
            3.1 Create a new instance of the Person class and give the instance a variable name of "person".
            3.2 Prompt the user with a question "What is your name? " and assign their response to the name variable.
            3.3 Using String Interpolation, reply and prompt the user with "Hi _______! Where are you from? " (See documentation below on String Interpolation)
            3.4 Assign their response to the location attribute of person. 
            3.5 Using String Interpolation, reply and prompt the user with "I have never been to _______. I bet it is nice. Press any key to continue..."
            3.6 Prompt the user to "Press any key to continue." And wait to proceed until a key is pressed.
         */
        private static void GetUserNameAndLocation()
        {
            Person person = new Person();

            Console.WriteLine("What is your name?");
            person.name = Console.ReadLine();

            Console.WriteLine($"Hello, {person.name}! Where are you from?");
            person.location = Console.ReadLine();

            Console.WriteLine($"I have never been to {person.location}. I bet it is nice. Press any key to continue...");

            Console.Read();
        }
        /*
         * 4. In the Program.cs class file, create a new private method called "ChristmasCountdown"
         */
        private static void ChristmasCountDown()
        {
            DateTime currentDate = DateTime.Today;
            DateTime xMas = new DateTime(2022, 12, 25);
            /*
             4.4Create your own variable name to store the calculated value of the number of days until Christmas this year as a whole number.
            */
            int daysUntilXMas = (xMas - currentDate).Days;

            /*
              4.3 Using String Interpolation, output the current date, but not the current time with the following message: "Today's date is: _____"
              4.5 Using String Interpolation, output your variable like so "There are ___ days until Christmas!"
            */
            Console.WriteLine($"Today's date is: {currentDate.ToString("MM/dd/yyyy")}. There are {daysUntilXMas} days until Christmas! Press any key to continue.");

            Console.Read();

        }
    }
}

