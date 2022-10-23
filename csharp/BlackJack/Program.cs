using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            var hand = new List<Card>();

            while (true)
            {
                Console.WriteLine("Stand, Hit");
                string read = Console.ReadLine();
                if (read == "Hit")
                {
                    var card = deck.Cards.Dequeue();

                    if(card.WriteRank() == "A")
                    {
                        var sum = GetSumOfCards(hand);
                        // If the range is between 6 and 11 then we want Ace to be 11. 
                        // The range could be lower but the dealer should not be able to hit if the score exceededs 17, menaing it *might* result in a draw at worst
                        if(6 < sum && sum < 11)
                        {
                            card.Rank = 11;
                        }
                        else
                        {
                            card.Rank = 1;
                        }
                    }

                    hand.Add(card);
                    var total = GetSumOfCards(hand);

                    if (total > 21)
                    {
                        Console.WriteLine($"The sum of your hand exceedes 21, which means you've lost this round");
                        break;
                    }

                    Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, card.WriteRank(), total);
                }
                else if (read == "Stand")
                {
                    break;
                }
            }
        }

        private static int GetSumOfCards(List<Card> hand)
        {
            if(hand.Count == 0)
            {
                return 0;
            }
            return hand.Sum(x => Math.Min(x.Rank, 10));
        }
    }
}
