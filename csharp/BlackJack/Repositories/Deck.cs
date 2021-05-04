using BlackJack.Data;
using BlackJack.Repositories;
using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Deck : IDeck
    {
        private Queue<Card> _cards;

        public Deck()
        {
            ResetDeck();
        }

        public Card DrawCard()
        {
            return _cards.Dequeue();
        }

        public void Shuffle()
        {
        }

        public void ResetDeck()
        {
            _cards = new Queue<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                for (var i = 1; i < 14; i++)
                {
                    _cards.Enqueue(new Card { Rank = i, Suit = suit });
                }
            }
        }
    }
}
