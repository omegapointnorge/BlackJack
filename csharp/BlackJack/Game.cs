using System;
using System.Collections.Generic;
using System.Linq;


namespace BlackJack
{
    public class BlackJackGame
    {
        public void PlayRound()
        {
            var deck = new Deck();
            var hand = new List<Card>();
            var total = 0;

            var dealerHand = new List<Card>();
            var dealerTotal = 0;

            var dealerCard = deck.Cards.Dequeue();

            Console.WriteLine("\n");
            Console.WriteLine("New Round, dealer starts");
            Console.WriteLine("-------------------------------------");

            dealerHand.Add(dealerCard);

            Console.WriteLine("Dealer Drew a {0} {1}", dealerCard.Suit, dealerCard.Rank);

            while (true)
            {
                Console.WriteLine($"{ConsoleCommands.Stand}, {ConsoleCommands.Hit}");
                string read = Console.ReadLine();

                if (string.Equals(read, ConsoleCommands.Hit,StringComparison.OrdinalIgnoreCase))
                {
                    var card = deck.Cards.Dequeue();

                    hand.Add(card);

                    total = FindTotal(hand);

                    Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, card.Rank, total);
                    if (total > 21)
                        break;
                }
                else if (string.Equals(read, ConsoleCommands.Stand, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }
            }
            if (total == 21)
                Console.WriteLine("Winner $$");
            else if (total > 21)
                Console.WriteLine("over 21.... You lost");
            else
            {
                while (dealerTotal < 17)
                {
                    var card2 = deck.Cards.Dequeue();
                    dealerHand.Add(card2);

                    dealerTotal = FindTotalDealer(dealerHand);

                    Console.WriteLine("Dealer Drew a {0} {1}", card2.Suit, card2.Rank);
                }
                Console.WriteLine("Dealer Stops at {0}", dealerTotal);
                if (dealerTotal > total)
                {
                    Console.WriteLine("House wins");
                }
                else if (dealerTotal == total)
                {
                    Console.WriteLine("Draw");
                }
                else
                {
                    Console.WriteLine("Player Wins");
                }
            }
        }

        #region Private Functions

        private int FindTotal(List<Card> hand)
        {
            var total = hand.Sum(x => Math.Min((int)x.Rank, 11));
            var aces = hand.Where(x => x.Rank is CardRank.A).ToList();
            var i = 0;
            while (total > 21 && i < aces.Count)
            {
                total = total - 10;
                i++;
            }
            return total;
        }

        private int FindTotalDealer(List<Card> dealerHand)
        {
            var dealerTotal = dealerHand.Sum(x => Math.Min((int)x.Rank, 10));
            var aces = dealerHand.Where(x => x.Rank is CardRank.A).ToList();
            var i = 0;
            if (21 > dealerTotal && dealerTotal > 17)
                return dealerTotal;
            while (dealerTotal > 21 && i < aces.Count)
            {
                dealerTotal = dealerTotal - 10;
                i++;
            }
            return dealerTotal;
        }
        #endregion
    }
}
