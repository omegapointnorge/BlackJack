using System.Collections.Generic;
using BlackJack.Data;

namespace BlackJack.GameElements
{
    public interface IDeck
    {
        public Card DrawCard();
        public int GetDeckSize();
        public IEnumerable<Card> GetDeck();
        public void Shuffle();
        public void ResetDeck();
    }
}
