// Game class, would run only if the players are ready to play the game...

using System;
using System.Collections.Generic;
using System.Text;

namespace PokerApp
{
    class Game
    {
        public void run() {

            // Setting up the validation flags...
            bool flagOne = false;
            bool flagTwo = false;

            // Show breifing to user...
            Console.WriteLine("");
            Console.WriteLine("...Welcome to the Poker Game...");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("The rules are simple.");
            Console.WriteLine("This program takes two inputs.");
            Console.WriteLine("First is for player one.");
            Console.WriteLine("Second is for player two.");
            Console.WriteLine("Each player has to input the hand that they got.");
            Console.WriteLine("It has to be exactly 5 cards, each for both the players.");
            Console.WriteLine("The input has to be in this format ONLY...");
            Console.WriteLine("");
            Console.WriteLine("AS 3C 9S AH 8S");
            Console.WriteLine("");
            Console.WriteLine("Then the program clauclates and anounces the winner.");
            Console.WriteLine("");
            Console.WriteLine("");

            Console.WriteLine("...THIS METHOD IS CURRENTLY UNDER CONSTRUCTION...");
            Console.WriteLine("");

            // User input here...
            Console.WriteLine("Please enter the cards for player one: ");
            string playerOne = Console.ReadLine();

            if (playerOne.Length != 5) { 
            
            }

            Console.WriteLine("");

            Console.WriteLine("Please enter the cards for player two: ");
            string playerTwo = Console.ReadLine();

            // Validation check for 'hands'...
            if (playerOne.Length != 0 && playerTwo.Length != 0) {
                
            }

            // Final validation check...
            if (flagOne && flagTwo) {
                // Call Algorithm class here...
                Algorithm algObj = new Algorithm();
                algObj.Playgame(playerOne, playerTwo);
            }
            else {
                Console.WriteLine("Error: Something went wrong in run().");
            }
        }
    }
}