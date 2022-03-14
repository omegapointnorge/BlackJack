using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack
{
    public class Deck
    {
        public Queue<Card> Cards;

        private List<Card> UnshuffledCards;
        public Deck()
        {
            UnshuffledCards = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    UnshuffledCards.Add(new Card() { Rank = rank, Suit = suit });
                }
            }
            var rnd = new Random();
            var randomized = UnshuffledCards.OrderBy(card => rnd.Next());
            Cards = new Queue<Card>();
            foreach (Card card in randomized)
            {
                Cards.Enqueue(card);
            }
        }
    }

}
