using System;
using System.Collections.Generic;
using System.Linq;

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
                    hand.Add(card);
                    var total = hand.Sum(x => Math.Min(x.Rank, 10));
                    Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, card.Rank, total);
                }
                else if (read == "Stand")
                {
                    break;
                }
            }
        }
    }
}
