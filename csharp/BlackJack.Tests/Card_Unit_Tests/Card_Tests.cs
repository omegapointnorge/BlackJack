using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack.Tests.Card_Unit_Tests
{
    public class Card_Tests : Scenario
    {
        [TestFixture]
        public class TheWriteRankMethod
        {
            private Card _card;
            public TheWriteRankMethod()
            {
                _card = new Card();
            }

            [Test]
            public void Should_Return_Number_When_less_than_10()
            {
                _card.Rank = 5;
                var result = _card.WriteRank();

                Assert.AreEqual(int.TryParse(result,out _),true, "Card doesn't return number when it should");
            }

            [Test]
            public void Should_Return_Number_When_Greater_Than_10_Or_Ace()
            {
                _card.Rank = 12;
                Assert.IsInstanceOf<string>(_card.WriteRank(), "Card doesn't return string when it should");
            }
        }
    }
}
