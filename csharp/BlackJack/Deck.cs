using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck
    {
        public Queue<Card> Cards;
        public Deck()
        {
            Cards = new Queue<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (int i = 1; i < 14; i++)
                {
                    Cards.Enqueue(new Card() { Rank = i, Suit = suit });
                }
            }

        }
    }
}
