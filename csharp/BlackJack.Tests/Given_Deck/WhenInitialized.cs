using BlackJack.GameElements;
using NUnit.Framework;
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
            Assert.AreEqual(52, _deck.GetDeckSize());
        }

        [Test]
        public void Should_have_4_distinct_suits()
        {
            Assert.AreEqual(4, _deck.GetDeck().Select(x => (int)x.Suit).Distinct().ToList().Count);
        }
    }
}
