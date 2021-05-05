using BlackJack.Data;
using BlackJack.Game;
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
            var sum = _hand.Sum(card => card.Rank.GetValue());
            while (sum > BlackJackValidator.BlackJackLimit)
            {
                var ace = _hand.Find(card => card.Rank.GetValue() == 11);
                if (ace != null)
                    ace.Rank.SetValue(1);
                else
                    break;
                sum = _hand.Sum(card => card.Rank.GetValue());
            }

            return sum;
        }

        public void ResetHand()
        {
            _hand = new List<Card>();
        }
    }
}
