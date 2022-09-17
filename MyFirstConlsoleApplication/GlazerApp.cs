using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApplication
{
    /*
        5. Create a new class file called "GlazerApp.cs" and set the class to static.
     */
    internal static class GlazerApp
    {
        /*
            5.1 Create a new method called "RunExample". Remember that this method must be set to public so that it can be accessed outside of the GlazerApp class. Make sure to also add the static void keywords.
            5.2 Inside of the RunExample method, add the program example from section 2.1 in the C# Programming Yellow Book by Rob Miles. 
         */
        public static void RunExample()
        {
            double width, height, woodLength, glassArea;
            string widthString, heightString;

            /*
                5.3 Improve the code so that the user is prompted for a width, and assign the width input value to a variable. 
                5.4 Improve the code so that the user is prompted for a height, and assign the height input value to a variable.
             */
            Console.WriteLine("Please enter width: ");
            widthString = Console.ReadLine();
            width = double.Parse(widthString);

            Console.WriteLine("Please enter height: ");
            heightString = Console.ReadLine();
            height = double.Parse(heightString);

            woodLength = 2 * (width + height) * 3.25;
            glassArea = 2 * (width * height);

            /*
                5.5 Output the results in two different lines indicating what the calculated wood length in feet and glass area in square meters.
             */
            Console.WriteLine("The length of the wood is " +
            woodLength + " feet");
            Console.WriteLine("The area of the glass is " +
            glassArea + " square metres");

            Console.Read();
        }
    }
}

