using System.Collections.Generic;
using NUnit.Framework;

namespace BlackJack.Tests
{
    public class HandTest : Scenario
    {
        private Hand _hand;

        public override void When()
        {
            _hand = new Hand();
        }

        [Test]
        public void CalculateHand_DrawTwoEightSeven_Returns17()
        {
            var cardList = new List<int>(){2, 8, 7};
            AddCards(cardList);
            Assert.AreEqual(17, _hand.CalculateHand());
        }

        [Test]
        public void CalculateHand_DrawNothing_Returns0()
        {
            var cardList = new List<int>();
            AddCards(cardList);
            Assert.AreEqual(0, _hand.CalculateHand());
        }

        [Test]
        public void CalculateHand_DrawAceKing_Returns21()
        {
            var cardList = new List<int>(){1, 13};
            AddCards(cardList);
            Assert.AreEqual(21, _hand.CalculateHand());
        }

        [Test]
        public void CalculateHand_DrawAceAceKing_Returns12()
        {
            var cardList = new List<int>(){1, 13, 1};
            AddCards(cardList);
            Assert.AreEqual(12, _hand.CalculateHand());
        }

        [Test]
        public void Busted_DrawAceAceKingQueen_ReturnsBusted()
        {
            var cardList = new List<int>(){1, 13, 1, 12};
            AddCards(cardList);
            Assert.AreEqual(true, _hand.Busted());
        }

        [Test]
        public void Busted_DrawAceKing_ReturnsNotBusted()
        {
            var cardList = new List<int>(){1, 13};
            AddCards(cardList);
            Assert.AreEqual(false, _hand.Busted());
        }

        private void AddCards(List<int> cards)
        {
            foreach (var rank in cards)
            {
                var card = new Card
                {
                    Rank = rank,
                    Suit = Suit.Clubs
                };
                _hand.AddCard(card);
            }
        }
    }
}