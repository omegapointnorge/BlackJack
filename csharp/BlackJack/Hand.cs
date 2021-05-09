using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Hand
    {
        public List<Card> Cards;
        private const int BustLimit = 21;

        public Hand()
        {
            Cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            Cards.Add(card);
        }

        public int CalculateHand()
        {
            var countAces = Cards.Count(x => x.Rank == 1);
            var total = Cards.Where(x => x.Rank != 1).Sum(x => Math.Min(x.Rank, 10));

            return countAces switch
            {
                0 => total,
                1 => total + 11 > BustLimit ? total + 1 : total + 11,
                _ => total + 11 + countAces - 1 > BustLimit ? total + countAces : total + 11 + countAces - 1
            };
        }

        public bool Busted()
        {
            return CalculateHand() > BustLimit;
        }
    }
}