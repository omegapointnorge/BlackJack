using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Tests.Player_Unit_Tests
{
    public class Player_Tests : Scenario
    {

        // Decided to follow this design principle for the tests
        // https://haacked.com/archive/2012/01/02/structuring-unit-tests.aspx/

        private Participant _player;
        private Deck _deck;

        public override void When()
        {
            _player = new Participant();
            _deck = new Deck();
        }


        [Test]
        public void Should_Have_empty_hand()
        {
            Assert.AreEqual(0, _player.Hand.Count, "Count of hand is wrong when initialized");
        }

        [Test]
        public void Sum_Should_Be_0_when_Length_is_0()
        {
            Assert.AreEqual(_player.GetSumOfHand(), 0, "Sum of cards is wrong when initialized");
        }

        [TestFixture]
        public class TheSumOfHandMethod
        {

            private Player _player;
            private Deck _deck;

            public TheSumOfHandMethod()
            {
                _player = new Player();
                _deck = new Deck();
            }

            [Test]
            public void Sum_Should_Be_Correct()
            {
                var card1 = new Card();
                card1.Suit = Suit.Clubs;
                card1.Rank = 5;

                var card2 = new Card();
                card2.Suit = Suit.Clubs;
                card2.Rank = 5;

                _player.Hand.Add(card1);
                _player.Hand.Add(card2);

                Assert.AreEqual(_player.GetSumOfHand(), 10, "Sum of hand is wrong when adding two cards");
            }

            [Test]
            public void Should_Return_Number()
            {
                Assert.IsInstanceOf<int>(_player.GetSumOfHand());
            }
        }

        [TestFixture]
        public class TheGetNewCardMethod
        {
            private Participant _player;
            private Deck _deck;

            public TheGetNewCardMethod()
            {
                _player = new Participant();
                _deck = new Deck();
            }

            [Test]
            public void Should_Give_A_New_Card()
            {
                var card = _player.GetNewCard(ref _deck);
                Assert.IsInstanceOf<Card>(card, "Card is of wrong type");
            }
        }

        [TestFixture]
        public class TheGetNewCardAndUpdateDeckMethod
        {
            private Participant _player;
            private Deck _deck;

            public TheGetNewCardAndUpdateDeckMethod()
            {
                _player = new Participant();
                _deck = new Deck();
            }

            [Test]
            public void Should_Give_New_Card_And_Update_Deck()
            {
                var card = _player.GetNewCardAndUpdateDeck(ref _deck);
                var count = _deck.Cards.Count;

                Assert.Multiple(() =>
                {
                    Assert.IsInstanceOf<Card>(card, "Card is of wrong type");
                    Assert.AreEqual(51, count, "Count is wrong after removing");
                });
            }
        }

        [TestFixture]
        public class TheAddCardToHandMethod
        {
            private Participant _player;
            private Deck _deck;

            public TheAddCardToHandMethod()
            {
                _player = new Participant();
                _deck = new Deck();
            }

            [Test]
            public void Should_Add_A_Card_To_you_Hand()
            {
                var card1 = new Card();
                card1.Suit = Suit.Clubs;
                card1.Rank = 5;

                _player.AddCardToHand(card1);

                Assert.AreEqual(_player.Hand.Count, 1, "Card didn't get added to your hand");
            }
        }

        [TestFixture]
        public class TheDetermineAceValueMethod
        {
            private Participant _player;
            private Deck _deck;

            public TheDetermineAceValueMethod()
            {
                _player = new Participant();
                _deck = new Deck();
            }

            [Test]
            public void Should_Return_1_When_Sum_Is_Lower_Than_6()
            {
                var card1 = new Card();
                card1.Suit = Suit.Clubs;
                card1.Rank = 6;

                _player.AddCardToHand(card1);

                var result = _player.DetermineAceValue();

                Assert.AreEqual(result, 1, "Did not return 1 when sum was lower than 6");
            }

            [Test]
            public void Should_Return_11_When_sum_Is_Between_7_And_10()
            {
                var card1 = new Card();
                card1.Suit = Suit.Diamonds;
                card1.Rank = 3;

                _player.AddCardToHand(card1);

                var result = _player.DetermineAceValue();

                Assert.AreEqual(result, 11, "Did not return 11 when sum was between 7 and 10");
            }
        }

        [TestFixture]
        public class TheEmptyHandMethod
        {
            private Participant _player;
            private Deck _deck;

            public TheEmptyHandMethod()
            {
                _player = new Participant();
                _deck = new Deck();
            }

            [Test]
            public void Should_Clear_Hand()
            {
                var card1 = new Card();
                card1.Suit = Suit.Clubs;
                card1.Rank = 6;

                _player.EmptyHand();
                Assert.AreEqual(_player.Hand.Count, 0, "Hand is of wrong size after clearing it");
            }
        }
    }
}
