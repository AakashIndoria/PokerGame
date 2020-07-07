// Driver class...

using PokerApp.src;
using System;

namespace PokerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Good Luck !!!");
            Console.WriteLine("");

            // Main menue comes here...

            Console.WriteLine("...Wlcome to the poker game...");
            Console.WriteLine("");
            Console.WriteLine("Please press '1' to play game.");
            Console.WriteLine("");
            Console.WriteLine("Please press '2' to give a test file.");
            Console.WriteLine("");
            Console.WriteLine("Please press '3' to Quit the game...");
            Console.WriteLine("");

            // User input here...
            int choice;
            Console.WriteLine("Please enter your choice: ");
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid number between 1 - 3.");
            }

            // Another check...
            if (choice == 1 || choice == 2 || choice == 3)
            {

                switch (choice)
                {
                    case 1:
                        // Call game class.
                        Game gameObj = new Game();
                        gameObj.run();
                        break;

                    case 2:
                        // Give test file.
                        Console.WriteLine("Reading the file. Please wait...");
                        Console.WriteLine("");

                        TalkToFile newObj = new TalkToFile();
                        newObj.Talk();
                        break;

                    case 3:
                        // Exit program...
                        Console.WriteLine("Exiting Program...");
                        Console.WriteLine("Please wait...");
                        System.Threading.Thread.Sleep(500);
                        break;

                    // Final line of defence...
                    default:
                        Console.WriteLine("Error: Wrong input, please try again...");
                        break;
                }
            }
            else {
                Console.WriteLine("Error: Wrong input, please enter a number between 1 - 3.");
            }
        }
    }
}
