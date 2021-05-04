using BlackJack.Data;

namespace BlackJack.Repositories
{
    public interface IHand
    {
        public void AddToHand(Card card);
        public int GetHandSum();
        public void ResetHand();
    }
}
