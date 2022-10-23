using System;
using System.Collections.Generic;
using System.Linq;

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

        /// <summary>
        /// Removes a card from the deck at a specific index
        /// </summary>
        /// <param name="card"></param>
        public void RemoveCardFromDeck(Card card)
        {
            Cards = new Queue<Card>(Cards.Where(newCard => newCard != card));
        }
    }
}
