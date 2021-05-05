using BlackJack.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.GameElements
{
    public class Deck : IDeck
    {
        private Queue<Card> _cards;

        public Deck()
        {
            ResetDeck();
            Shuffle();
        }

        public Card DrawCard()
        {
            try
            {
                return _cards.Dequeue();
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Deck is empty! Resetting the deck...");
                ResetDeck();
                return _cards.Dequeue();
            }
        }

        public int GetDeckSize() => _cards.Count;

        public IEnumerable<Card> GetDeck() => _cards;

        /// <summary>
        /// https://stackoverflow.com/a/4262134/2174510
        /// </summary>
        public void Shuffle()
        {
            var random = new Random();
            _cards = new Queue<Card>(_cards.OrderBy(card => random.Next()));
        }

        public void ResetDeck()
        {
            var cardList = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                cardList.AddRange(from RankValue rankValue in Enum.GetValues(typeof(RankValue))
                    select new Card
                    {
                        Rank = new Rank((int) rankValue),
                        Suit = suit
                    });
            }

            _cards = new Queue<Card>(cardList);
            Shuffle();
        }
    }
}
