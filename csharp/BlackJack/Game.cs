using System;

namespace BlackJack
{
    public class Game
    {
        public Hand DealerHand;
        public Deck Deck;
        public Hand PlayerHand;
        private const int DealerLimit = 17;

        public Game()
        {
            Deck = new Deck();
            PlayerHand = new Hand();
            DealerHand = new Hand();
        }

        public void Start()
        {
            var dealerFirstCard = Deck.Draw();
            DealerHand.AddCard(dealerFirstCard);
            Console.WriteLine($"Dealer: Hit with {dealerFirstCard.Suit} {dealerFirstCard.GetRank()}.");
            while (!PlayerHand.Busted())
            {
                Console.WriteLine("Stand, Hit");
                var read = Console.ReadLine();
                if (read == "Hit")
                {
                    var card = Deck.Draw();
                    PlayerHand.AddCard(card);
                    Console.WriteLine($"Hit with {card.Suit} {card.GetRank()}. Total is {PlayerHand.CalculateHand()}.");
                }
                else if (read == "Stand")
                {
                    break;
                }
            }

            while (DealerHand.CalculateHand() < DealerLimit)
            {
                var card = Deck.Draw();
                DealerHand.AddCard(card);
                Console.WriteLine(
                    $"Dealer: Hit with {card.Suit} {card.GetRank()}. Total is {DealerHand.CalculateHand()}.");
            }
        }

        public string CalculateWinner()
        {
            var pointResult = $"Player got {PlayerHand.CalculateHand()}. Dealer got {DealerHand.CalculateHand()}";
            if (PlayerHand.Busted())
                return $"Dealer won! {pointResult}";

            if (DealerHand.Busted())
                return $"Player won! {pointResult}";

            if (DealerHand.CalculateHand() == PlayerHand.CalculateHand())
                return $"Draw! {pointResult}";

            return (DealerHand.CalculateHand() < PlayerHand.CalculateHand() ? "Player won! " : "Dealer won! ") +
                   pointResult;
        }
    }
}