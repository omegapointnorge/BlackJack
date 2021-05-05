using BlackJack.Data;
using System.Collections.Generic;

namespace BlackJack.Repositories
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
