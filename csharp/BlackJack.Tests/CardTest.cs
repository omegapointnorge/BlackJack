using NUnit.Framework;

namespace BlackJack.Tests
{
    public class CardTest : Scenario
    {
       [Test] 
       public void GetRank_GetOne_ReturnsA()
       {
           var card = new Card
           {
               Rank = 1,
               Suit = Suit.Clubs
           };

           Assert.AreEqual("A", card.GetRank());
       }

       [Test] 
       public void GetRank_GetEleven_ReturnsJ()
       {
           var card = new Card
           {
               Rank = 11,
               Suit = Suit.Clubs
           };

           Assert.AreEqual("J", card.GetRank());
       }
    }
}