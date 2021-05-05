using System.Collections.Generic;
using System.Linq;
using BlackJack.Data;
using BlackJack.Game;

namespace BlackJack.GameElements
{
    public abstract class Hand
    {
        protected List<Card> CardHand;

        protected Hand()
        {
            CardHand = new List<Card>();
        }

        public virtual void AddToHand(Card card)
        {
            CardHand.Add(card);
        }

        public virtual int GetHandSum()
        {
            var sum = CardHand.Sum(card => card.Rank.GetValue());
            while (sum > BlackJackValidator.BlackJackLimit)
            {
                var ace = CardHand.Find(card => card.Rank.GetValue() == 11);
                if (ace != null)
                    ace.Rank.SetValue(1);
                else
                    break;
                sum = CardHand.Sum(card => card.Rank.GetValue());
            }

            return sum;
        }

        public virtual void ResetHand()
        {
            CardHand = new List<Card>();
        }
    }
}
