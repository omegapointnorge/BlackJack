using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        private static readonly Random rng = new Random();
        public Queue<Card> Cards;

        public Deck()
        {
            var cards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                for (var i = 1; i < 14; i++)
                    cards.Add(new Card {Rank = i, Suit = suit});

            Cards = new Queue<Card>(Shuffel(cards));
        }

        public Card Draw()
        {
            return Cards.Dequeue();
        }

        public static IEnumerable<Card> Shuffel(IList<Card> cards)
        {
            var n = cards.Count;
            while (n > 1)
            {
                n--;
                var k = rng.Next(n + 1);
                var value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }

            return cards;
        }
    }
}