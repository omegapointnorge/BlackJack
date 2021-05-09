using System.Collections.Generic;
using NUnit.Framework;

namespace BlackJack.Tests
{
    public class GameTest : Scenario
    {
        private Game _game;

        public override void When()
        {
            _game = new Game();
        }

        [Test]
        public void CalculateWinner_DealerMorePointsThanPlayer_ReturnsDelaerWin()
        {
            var player = new List<int> {1, 2};
            var dealer = new List<int> {1, 3};

            AddHands(dealer, player);

            Assert.AreEqual("Dealer won! Player got 13. Dealer got 14", _game.CalculateWinner());
        }

        [Test]
        public void CalculateWinner_PlayerMorePointsThanDelaer_ReturnsPlayerWin()
        {
            var player = new List<int> {1, 12};
            var dealer = new List<int> {1, 3};

            AddHands(dealer, player);

            Assert.AreEqual("Player won! Player got 21. Dealer got 14", _game.CalculateWinner());
        }

        [Test]
        public void CalculateWinner_DealerBust_ReturnsDelaerBust()
        {
            var player = new List<int> {1, 12};
            var dealer = new List<int> {1, 3, 10, 11};

            AddHands(dealer, player);

            Assert.AreEqual("Player won! Player got 21. Dealer got 24", _game.CalculateWinner());
        }

        private void AddHands(List<int> cardsDealer, List<int> cardsPlayer)
        {
            foreach (var rank in cardsDealer)
            {
                var card = new Card
                {
                    Rank = rank,
                    Suit = Suit.Clubs
                };
                _game.DealerHand.AddCard(card);
            }

            foreach (var rank in cardsPlayer)
            {
                var card = new Card
                {
                    Rank = rank,
                    Suit = Suit.Clubs
                };
                _game.PlayerHand.AddCard(card);
            }
        }
    }
}