using BlackJack.Data;
using BlackJack.Game;
using BlackJack.GameElements;
using NUnit.Framework;

namespace BlackJack.Tests.Given_Hand
{
    public class WhenInitialized : Scenario
    {
        [Test]
        public void Should_be_invalid_hand()
        {
            var hand = new PlayerHand();
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.Jack)
            });
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.Queen)
            });
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.King)
            });
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.Ace)
            });

            Assert.False(BlackJackValidator.ValidateHand(hand));
        }

        [Test]
        public void Should_be_valid_hand()
        {
            var hand = new PlayerHand();
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.King)
            });
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.Queen)
            });
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.Ace)
            });

            Assert.True(BlackJackValidator.ValidateHand(hand));
        }

        [Test]
        public void Should_be_hand_value_21()
        {
            var hand = new PlayerHand();
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.King)
            });
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.Ace)
            });

            Assert.AreEqual(21, hand.GetHandSum());
        }

        [Test]
        public void Should_be_hand_value_20()
        {
            var hand = new PlayerHand();
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.Nine)
            });
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.Ace)
            });

            Assert.AreEqual(20, hand.GetHandSum());
        }

        [Test]
        public void Should_be_hand_value_12()
        {
            var hand = new PlayerHand();
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.King)
            });
            hand.AddToHand(new Card
            {
                Suit = Suit.Spades,
                Rank = new Rank(RankValue.Ace)
            });
            hand.AddToHand(new Card
            {
                Suit = Suit.Hearts,
                Rank = new Rank(RankValue.Ace)
            });

            Assert.AreEqual(12, hand.GetHandSum());
        }
    }
}
