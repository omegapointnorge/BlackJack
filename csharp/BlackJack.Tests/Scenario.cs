using NUnit.Framework;

namespace BlackJack.Tests
{
    [TestFixture]
    public abstract class Scenario
    {
        [SetUp]
        public void Setup()
        {
            Given();
            When();
        }

        public virtual void Given() { }

        public virtual void When() { }
    }
}
