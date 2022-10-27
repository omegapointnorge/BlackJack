using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    public class Participant
    {
        Random random = new Random();
        public List<Card> Hand { get; set; }

        public Participant()
        {
            Hand = new List<Card>();
        }
        /// <summary>
        /// Gets the sum of the Cards in your hand
        /// </summary>
        /// <returns>The sum of the Cards</returns>
        public int GetSumOfHand()
        {
            if (Hand.Count == 0)
            {
                return 0;
            }
            return Hand.Sum(x => Math.Min(x.Rank, 10));
        }

        /// <summary>
        /// Gets a new Card from a random position in your deck
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>Returns your new card</returns>
        public Card GetNewCard(ref Deck deck)
        {
            var randomNumber = random.Next(0, deck.Cards.Count);
            // Get a card from a specific index
            var card = deck.Cards.ToArray().ToList()[randomNumber];
            if (card.WriteRank() == "A")
            {
                card.Rank = DetermineAceValue();
            }
            return card;
        }

        /// <summary>
        /// Collected function for getting a new card and simultaneously removing it from the deck
        /// </summary>
        /// <param name="deck"></param>
        /// <returns>The card you drew</returns>
        public Card GetNewCardAndUpdateDeck(ref Deck deck)
        {
            var card = GetNewCard(ref deck);
            deck.RemoveCardFromDeck(card);
            return card;
        }

        /// <summary>
        /// Adds a card to your hand
        /// </summary>
        /// <param name="card">Card to be added to your hand</param>
        public void AddCardToHand(Card card)
        {
            Hand.Add(card);
        }

        /// <summary>
        /// Function to determine the value of Ace, optimized for your best outcome
        /// </summary>
        /// <returns>Either 1 or 11 based of the sum of your current hand</returns>
        public int DetermineAceValue()
        {
            var sum = GetSumOfHand();
            var value = 0;
            // If the range is between 6 and 11 then we want Ace to be 11. 
            // The range could be lower but the dealer should not be able to hit if the score exceededs 17, menaing it *might* result in a draw at worst
            if (6 < sum && sum < 11)
            {
                value = 11;
            }
            else
            {
                value = 1;
            }
            Console.WriteLine("\n Since Ace was drawn the final value became {0}", value);
            return value;
        }

        /// <summary>
        /// Writes the last drawn card's suit and rank as well as the total sum of the cards in your hand to the console
        /// Takes a prefix for the name of the player. You / Dealer
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="card"></param>
        public void WriteStatsToConsole(string prefix, Card card)
        {
            Console.WriteLine("\n {0} hit with {1} {2}. Total is now {3}", prefix, card.Suit, card.Rank, GetSumOfHand());
        }


        /// <summary>
        /// Function for clearing the players current hand
        /// </summary>
        public void EmptyHand()
        {
            Hand.Clear();
        }
    }
}
