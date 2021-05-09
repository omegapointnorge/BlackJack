using System.Linq;
using NUnit.Framework;

namespace BlackJack.Tests.Given_Deck
{
    public class When_initialized : Scenario
    {
        private Deck _deck;
        public override void When()
        {
            _deck = new Deck();
        }

        [Test]
        public void Should_have_52_cards()
        {
            Assert.AreEqual(52, _deck.Cards.Count);
        }

        [Test]
        public void Should_have_4_distinct_suits()
        {
            Assert.AreEqual(4, _deck.Cards.Select(x => (int)x.Suit).Distinct().ToList().Count);
        }
    }
}
