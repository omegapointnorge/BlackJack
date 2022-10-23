using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            var player = new Player();
            var dealer = new Dealer();

            var dealerCard = dealer.GetNewCard(deck);
            dealer.AddCardToHand(dealerCard);
            Console.WriteLine("Dealer drew {0} {1}", dealerCard.Suit, dealerCard.Rank);

            while (true)
            {
                Console.WriteLine("Stand, Hit");
                string read = Console.ReadLine();
                if (read == "Hit")
                {
                    // Get a card from a specific index and remove it afterwards
                    var card = player.GetNewCard(deck);
                    deck.Cards = new Queue<Card>(deck.Cards.Where(newCard => newCard != card));

                    player.AddCardToHand(card);
                    var total = player.GetSumOfHand();

                    if (total > 21)
                    {
                        Console.WriteLine("The sum of your hand exceedes 21, which means you've lost this round");
                        break;
                    }

                    player.WriteStatsToConsole("You", card);
                }
                else if (read == "Stand")
                {
                    break;
                }
            }

            dealer.FinishGame(deck);
            var playerSum = player.GetSumOfHand();
            var dealerSum = dealer.GetSumOfHand();
            Console.WriteLine("Dealer has {0}, you have {1}", dealerSum, playerSum);

            if(playerSum > 21 && playerSum > 21)
            {
                Console.WriteLine("Both the player and dealer busted, better luck next round");
            }else if (dealerSum > 21 || playerSum > 21)
            {
                bool playerBust = playerSum > 21;
                string prefix = playerBust ? "player" : "dealer";
                string suffix = playerBust ? "dealer" : "player";
                Console.WriteLine("{0} went bust, {1} wins!", prefix, suffix);
            }else
            {
                if(playerSum == dealerSum)
                {
                    Console.WriteLine("The score is equal meaning there is no winner");
                } else
                {
                    var winner = playerSum > dealerSum ? "You are" : "The dealer is";
                    Console.WriteLine("{0} the winner of this round, congratualtions!",winner);
                }
            }
        }
    }
}
