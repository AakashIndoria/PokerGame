// Actual algorithm for Poker game...

using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerApp
{
    class Algorithm
    {
        Dictionary<string, int> rankMapping = new Dictionary<string, int>();
        Dictionary<string, int> cardMapping = new Dictionary<string, int>();
        Dictionary<string, int> scoreMapingP1 = new Dictionary<string, int>();
        Dictionary<string, int> scoreMapingP2 = new Dictionary<string, int>();
        Dictionary<int, int> trackPatternP1 = new Dictionary<int, int>();
        Dictionary<int, int> trackPatternP2 = new Dictionary<int, int>();

        public Algorithm()
        {
            // Dictionary for Ranking...
            this.rankMapping.Add("HC", 1);
            this.rankMapping.Add("P", 2);
            this.rankMapping.Add("TP", 3);
            this.rankMapping.Add("TK", 4);
            this.rankMapping.Add("S", 5);
            this.rankMapping.Add("F", 6);
            this.rankMapping.Add("FH", 7);
            this.rankMapping.Add("FK", 8);
            this.rankMapping.Add("SF", 9);
            this.rankMapping.Add("RF", 10);

            // Dictionary for Card value...
            this.cardMapping.Add("T", 10);
            this.cardMapping.Add("J", 11);
            this.cardMapping.Add("Q", 12);
            this.cardMapping.Add("K", 13);
            this.cardMapping.Add("A", 14);

            // Dictionary to keep Score for player one...
            this.scoreMapingP1.Add("HC", 0);
            this.scoreMapingP1.Add("P", 0);
            this.scoreMapingP1.Add("TP", 0);
            this.scoreMapingP1.Add("TK", 0);
            this.scoreMapingP1.Add("S", 0);
            this.scoreMapingP1.Add("F", 0);
            this.scoreMapingP1.Add("FH", 0);
            this.scoreMapingP1.Add("FK", 0);
            this.scoreMapingP1.Add("SF", 0);
            this.scoreMapingP1.Add("RF", 0);

            // Dictionary to keep Score for player two...
            this.scoreMapingP2.Add("HC", 0);
            this.scoreMapingP2.Add("P", 0);
            this.scoreMapingP2.Add("TP", 0);
            this.scoreMapingP2.Add("TK", 0);
            this.scoreMapingP2.Add("S", 0);
            this.scoreMapingP2.Add("F", 0);
            this.scoreMapingP2.Add("FH", 0);
            this.scoreMapingP2.Add("FK", 0);
            this.scoreMapingP2.Add("SF", 0);
            this.scoreMapingP2.Add("RF", 0);
        }

        // func to calculate Straight...
        public int Straight(IEnumerable<String> hand)
        {
            List<int> firstHand = new List<int>();

            int result = 0;

            if (hand.Count() != 0)
            {
                String sameSuitCheck = "";

                bool suitCheck = true;

                foreach (var card in hand)
                {
                    card.ToUpper();
                    String first = card.Substring(0, 1);
                    String second = card.Substring(1);

                    if (sameSuitCheck.Length == 0)
                    {
                        sameSuitCheck = second;
                    }

                    if (!second.Contains(sameSuitCheck))
                    {
                        suitCheck = false;
                    }

                    int val = 0;

                    if (cardMapping.ContainsKey(first))
                    {
                        val = cardMapping[first];
                    }
                    else
                    {
                        val = Int32.Parse(first);
                    }

                    if (val > 0)
                    {
                        firstHand.Add(val);
                    }
                }

                if (firstHand.Count > 0)
                {
                    // Assending sort...
                    firstHand.Sort();
                    bool isConsecutive = !firstHand.Select((i, j) => i - j).Distinct().Skip(1).Any();
                    if (isConsecutive)
                    {
                        // Types of flush...
                        if (suitCheck)
                        {
                            // Case for Royal Flush...
                            if (firstHand.Contains(10) && firstHand.Contains(11) && firstHand.Contains(12) && firstHand.Contains(13) && firstHand.Contains(14))
                            {

                                result = 4;
                                return result;

                            }
                            else
                            {
                                // Straight Flush...
                                result = 3;
                                return result;
                            }
                        }
                        // Case for straight...
                        else
                        {
                            result = 2;
                            return result;
                        }
                    }
                    else if (suitCheck)
                    {
                        // Case for Flush...
                        result = 1;
                        return result;
                    }
                    // Case for non-straight...
                    else
                    {
                        result = 0;
                        return result;
                    }
                }
            }
            return result;
        }


        // func to calculate the high card for the player...
        public int HighCard(IEnumerable<String> hand)
        {

            List<int> firstHand = new List<int>();

            int highest = 0;

            if (hand.Count() != 0)
            {

                foreach (var card in hand)
                {

                    card.ToUpper();
                    String first = card.Substring(0, 1);
                    int val = 0;

                    if (cardMapping.ContainsKey(first))
                    {
                        val = cardMapping[first];
                    }
                    else
                    {
                        val = Int32.Parse(first);
                    }

                    if (val > 0)
                    {
                        firstHand.Add(val);
                    }
                }

                if (firstHand.Count > 0)
                {
                    // Assending sort...
                    firstHand.Sort();
                    highest = firstHand[firstHand.Count - 1];
                }
            }
            return highest;
        }


        // Meth used in case of clash...
        public String Clash(IEnumerable<String> hand, IEnumerable<String> handTwo)
        {
            String result = "Error";

            List<int> firstHand = new List<int>();
            List<int> secondHand = new List<int>();

            int highestOne = 0;
            int highestTwo = 0;


            if (hand.Count() != 0)
            {

                foreach (var card in hand)
                {

                    card.ToUpper();
                    String first = card.Substring(0, 1);
                    int val = 0;

                    if (cardMapping.ContainsKey(first))
                    {
                        val = cardMapping[first];
                    }
                    else
                    {
                        val = Int32.Parse(first);
                    }

                    if (val > 0)
                    {
                        firstHand.Add(val);
                    }
                }

                if (firstHand.Count > 0)
                {
                    highestOne = firstHand.Sum();
                }
            }

            if (handTwo.Count() != 0)
            {
                foreach (var card in handTwo)
                {

                    card.ToUpper();
                    String first = card.Substring(0, 1);
                    int val = 0;

                    if (cardMapping.ContainsKey(first))
                    {
                        val = cardMapping[first];
                    }
                    else
                    {
                        val = Int32.Parse(first);
                    }

                    if (val > 0)
                    {
                        secondHand.Add(val);
                    }
                }

                if (secondHand.Count > 0)
                {
                    highestTwo = secondHand.Sum();
                }
            }


            // Check for pair...

            var myKeyOne = trackPatternP1.FirstOrDefault(x => x.Value == 2).Key;
            var myKeyTwo = trackPatternP2.FirstOrDefault(x => x.Value == 2).Key;

            if (myKeyOne > myKeyTwo)
            {
                result = "P1";
                return result;
            }
            else if (myKeyTwo > myKeyOne)
            {
                result = "P2";
                return result;
            }
            else if (myKeyOne == myKeyTwo)
            {

                if (highestOne > highestTwo)
                {
                    result = "P1";
                    return result;
                }
                else
                {

                    result = "P2";
                    return result;
                }
            }
            return result;
        }

        // Meth for pair...
        public Dictionary<int, int> Pair(IEnumerable<String> hand)
        {
            List<int> firstHand = new List<int>();

            if (hand.Count() != 0)
            {
                foreach (var card in hand)
                {
                    card.ToUpper();
                    String first = card.Substring(0, 1);
                    int val = 0;

                    if (cardMapping.ContainsKey(first))
                    {
                        val = cardMapping[first];
                    }
                    else
                    {
                        val = Int32.Parse(first);
                    }

                    if (val > 0)
                    {
                        firstHand.Add(val);
                    }
                }

                if (firstHand.Count > 0)
                {
                    Dictionary<int, int> b = firstHand.GroupBy(item => item).ToDictionary(item => item.Key, item => item.Count());

                    return b;
                }
            }
            return new Dictionary<int, int>();
        }

        // Meth to be used in case of file reading...
        public String Playgame(String line)
        {
            // Clash resolve...
            String clashresult = "Error";

            // Final score for pOne...
            int scPOne = 0;
            int scPTwo = 0;

            // Flags to check the Full House scenario...
            bool threeOfKindP1 = false;
            bool pairP1 = false;

            bool threeOfKindP2 = false;
            bool pairP2 = false;

            // Counter for players...

            String result = "Error";

            if (line.Length != 0)
            {
                // Converting String to array.
                IEnumerable<String> all = line.Split(' ');

                IEnumerable<String> p1 = all.Skip(0).Take(all.Count() / 2);
                IEnumerable<String> p2 = all.Skip((all.Count() / 2)).Take(all.Count() - 1);


                // Call to high card...
                int p1HighCard = this.HighCard(p1);
                int p2HighCard = this.HighCard(p2);

                if (p1HighCard != 0 && p2HighCard != 0)
                {

                    if (p1HighCard > p2HighCard)
                    {
                        this.scoreMapingP1["HC"] = 1;
                    }
                    else if (p1HighCard < p2HighCard)
                    {
                        this.scoreMapingP2["HC"] = 1;
                    }
                    else
                    {
                        this.scoreMapingP1["HC"] = 1;
                        this.scoreMapingP2["HC"] = 1;
                    }
                }

                this.trackPatternP1 = this.Pair(p1);
                this.trackPatternP2 = this.Pair(p2);
                int twoPairP1 = 0;
                foreach (KeyValuePair<int, int> kvp in this.trackPatternP1)
                {

                    if (kvp.Value == 2)
                    {
                        twoPairP1++;
                    }

                    if (kvp.Value >= 2)
                    {
                        this.scoreMapingP1["P"] = 2;

                        // First flag for pair P1...
                        pairP1 = true;

                        if (kvp.Value >= 3)
                        {
                            this.scoreMapingP1["TK"] = 4;

                            // Second flag for Three of a kind P1...
                            threeOfKindP1 = true;

                            if (kvp.Value == 4)
                            {
                                this.scoreMapingP1["FK"] = 8;
                            }
                        }
                    }
                }
                if (twoPairP1 == 2)
                {
                    this.scoreMapingP1["TP"] = 3;
                }

                int twoPairP2 = 0;
                foreach (KeyValuePair<int, int> kvp in this.trackPatternP2)
                {

                    if (kvp.Value == 2)
                    {
                        twoPairP2++;
                    }

                    if (kvp.Value >= 2)
                    {
                        this.scoreMapingP2["P"] = 2;

                        // First flag for pair P2...
                        pairP2 = true;

                        if (kvp.Value >= 3)
                        {
                            this.scoreMapingP2["TK"] = 4;

                            // Second flag for Three of a kind P2...
                            threeOfKindP2 = true;

                            if (kvp.Value == 4)
                            {
                                this.scoreMapingP2["FK"] = 8;
                            }
                        }
                    }
                }
                if (twoPairP2 == 2)
                {
                    this.scoreMapingP2["TP"] = 3;
                }


                // Call to Straight()
                int stP1 = this.Straight(p1);
                int stP2 = this.Straight(p2);

                if (stP1 != 0 || stP2 != 0)
                {

                    // RF one hand...

                    if (stP1 == 4)
                    {
                        this.scoreMapingP1["RF"] = 10;
                    }

                    if (stP2 == 4)
                    {
                        this.scoreMapingP2["RF"] = 10;
                    }

                    // F, S or SF scenarios...
                    if (stP1 == 1)
                    {
                        this.scoreMapingP1["F"] = 6;
                    }
                    if (stP1 == 2)
                    {
                        this.scoreMapingP1["S"] = 5;
                    }
                    if (stP1 == 3)
                    {
                        this.scoreMapingP1["SF"] = 9;
                    }

                    if (stP2 == 1)
                    {
                        this.scoreMapingP2["F"] = 6;
                    }
                    if (stP2 == 2)
                    {
                        this.scoreMapingP2["S"] = 5;
                    }
                    if (stP2 == 3)
                    {
                        this.scoreMapingP2["SF"] = 9;
                    }
                }

                // full House...
                if (threeOfKindP1 && pairP1)
                {
                    this.scoreMapingP1["FH"] = 7;
                }
                else if (threeOfKindP2 && pairP2)
                {
                    this.scoreMapingP2["FH"] = 7;
                }

                // Check the winner...

                // Sorting the dictionary for highest value...
                scoreMapingP1 = scoreMapingP1.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                scoreMapingP2 = scoreMapingP2.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                scPOne = scoreMapingP1.Last().Value;
                scPTwo = scoreMapingP2.Last().Value;

                // Calc of winning player...
                if (scPOne != 0 || scPTwo != 0)
                {

                    if (scPOne > scPTwo)
                    {
                        // Console.WriteLine("Player One Wins...");
                        return ("P1");
                    }
                    else if (scPOne < scPTwo)
                    {
                        // Console.WriteLine("Player Two Wins...");
                        return ("P2");
                    }
                    else
                    {
                        // Count the cards...

                        clashresult = this.Clash(p1, p2);

                        return clashresult;

                    }
                }
            }
            else
            {
                Console.WriteLine("Error: Data not returned by file.");
            }
            return result;
        }

        // Meth to be used in case of players playing the game...
        public String Playgame(String playerOne, String playerTwo)
        {
            String result = "Error";

            result = "Method under progress...";

            return result;
        }
    }
}
