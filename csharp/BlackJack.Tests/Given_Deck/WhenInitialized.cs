using BlackJack.Data;
using BlackJack.GameElements;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Tests.Given_Deck
{
    public class WhenInitialized : Scenario
    {
        private Deck _deck;
        public override void When()
        {
            _deck = new Deck();
        }

        [Test]
        public void Should_have_52_cards()
        {
            _deck.ResetDeck();
            Assert.AreEqual(52, _deck.GetDeckSize());
        }

        [Test]
        public void Should_have_4_distinct_suits()
        {
            Assert.AreEqual(4, _deck.GetDeck().Select(x => (int)x.Suit).Distinct().ToList().Count);
        }

        [Test]
        public void Should_return_rank_value_within_range()
        {
            _deck.ResetDeck();
            foreach (var card in _deck.GetDeck())
            {
                Assert.GreaterOrEqual(card.Rank.GetValue(), 1);
                Assert.LessOrEqual(card.Rank.GetValue(), 11);
            }
        }

        [Test]
        public void Should_print_correct_rank()
        {
            _deck.ResetDeck();
            var royals = _deck.GetDeck().Where(card => card.Rank.GetValue() > 10);
            foreach (var card in royals)
            {
                var rank = card.Rank.GetRankValue();
                switch (rank)
                {
                    case RankValue.Jack:
                        Assert.AreEqual("J", card.Rank.ToString());
                        break;
                    case RankValue.Queen:
                        Assert.AreEqual("Q", card.Rank.ToString());
                        break;
                    case RankValue.King:
                        Assert.AreEqual("K", card.Rank.ToString());
                        break;
                    case RankValue.Ace:
                        Assert.AreEqual("A", card.Rank.ToString());
                        break;
                    default:
                        Assert.Fail($"Unrecognized card rank value: {card.Rank}. Should have been a royal.");
                        break;
                }
            }
        }

        [Test]
        public void Should_be_randomized()
        {
            _deck.ResetDeck();
            var cardList = new List<Card>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                cardList.AddRange(from RankValue rankValue in Enum.GetValues(typeof(RankValue))
                    select new Card
                    {
                        Rank = new Rank((int)rankValue),
                        Suit = suit
                    });
            }
            var sortedDeck = new Queue<Card>(cardList);
            Assert.AreNotEqual(sortedDeck, _deck.GetDeck());
        }
    }
}
