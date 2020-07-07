// Class to talk with external files.

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;

namespace PokerApp.src
{
    class TalkToFile
    {
        public void Talk()
        {
            // Final counters...
            int pOneWins = 0;
            int pTwoWins = 0;

            try
            {   // Open the text file using a stream reader.
                String filePath = "..\\TestFile.txt";

                // using IEnumerable...
                IEnumerable<String> lines = File.ReadLines(filePath);

                foreach (var line in lines)
                {
                    // Call to Algorithm class.
                    Algorithm algObj = new Algorithm();
                    String result = algObj.Playgame(line);

                    if (!result.Contains("Error"))
                    {
                        if (result.Contains("P1"))
                        {
                            pOneWins += 1;
                        }
                        else {
                            pTwoWins += 1;
                        }
                    }
                    else {
                        Console.WriteLine("Error: Something went wrong in Algo class...");
                    }
                }

                Console.WriteLine("OUTPUT: ");

                Console.WriteLine("");
                Console.WriteLine("Player 1: "+ pOneWins);
                Console.WriteLine("Player 2: "+ pTwoWins);
                Console.WriteLine("");
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: The file could not be read:");
                Console.WriteLine(e.Message);
                Console.WriteLine("");
            }
        }
    }
}