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
            while (true)
            {
                var deck = new Deck();
                var hand = new List<Card>();
                var total = 0;
                var dealerHand = new List<Card>();
                var dealerTotal = 0;
                var dealerCard = deck.Cards.Dequeue();
                dealerHand.Add(dealerCard);
                Console.WriteLine("Dealer Drew a {0} {1}", dealerCard.Suit, dealerCard.Rank);

                while (true)
                {
                    Console.WriteLine($"{ConsoleCommands.Stand}, {ConsoleCommands.Hit}");
                    string read = Console.ReadLine();
                    if (read == ConsoleCommands.Hit)
                    {
                        var card = deck.Cards.Dequeue();

                        hand.Add(card);

                        total = hand.Sum(x => Math.Min((int)x.Rank, 11));
                        var aces = hand.Where(x => x.Rank is CardRank.A).ToList();
                        var i = 0;
                        while (total > 21 && i < aces.Count)
                        {
                            total = total - 10;
                            i++;
                        }
                        Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, card.Rank, total);
                        if (total > 21)
                            break;
                    }
                    else if (read == ConsoleCommands.Stand)
                    {
                        break;
                    }
                }
                if (total == 21)
                    Console.WriteLine("Winner $$");
                else if (total > 21)
                    Console.WriteLine("over 21.... You lost");
                else
                {
                    while (dealerTotal < 17)
                    {
                        var card2 = deck.Cards.Dequeue();
                        dealerHand.Add(card2);

                        dealerTotal = dealerHand.Sum(x => Math.Min((int)x.Rank, 10));

                        Console.WriteLine("Dealer Drew a {0} {1}", card2.Suit, card2.Rank);
                    }
                    Console.WriteLine("Dealer Stops at {0}", dealerTotal);
                    if (dealerTotal < total)
                    {
                        Console.WriteLine("House wins");
                    }
                    else if (dealerTotal == total)
                    {
                        Console.WriteLine("Draw");
                    }
                    else
                    {
                        Console.WriteLine("Player Wins");
                    }
                }
            }
        }
    }
    internal static class ConsoleCommands
    {
        internal static string Hit = "Hit";
        internal static string Stand = "Stand";
    }

}
