using BlackJack.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Repositories
{
    public class Hand : IHand
    {
        private List<Card> _hand;

        public Hand()
        {
            ResetHand();
        }

        public void AddToHand(Card card)
        {
            _hand.Add(card);
        }

        public int GetHandSum()
        {
            return _hand.Sum(x => Math.Min(x.Rank, 10));
        }

        public void ResetHand()
        {
            _hand = new List<Card>();
        }
    }
}
