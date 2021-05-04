using BlackJack.Data;

namespace BlackJack.Repositories
{
    public interface IDeck
    {
        public Card DrawCard();
        public void Shuffle();
        public void ResetDeck();
    }
}
