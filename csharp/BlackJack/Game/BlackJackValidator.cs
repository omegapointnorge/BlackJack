using BlackJack.Repositories;

namespace BlackJack.Game
{
    public static class BlackJackValidator
    {
        public const int BlackJackLimit = 21;

        public static bool ValidatePlayerHand(IHand hand)
        {
            if (hand.GetHandSum() > BlackJackLimit)
            {
                return false;
            }

            return true;
        }
    }
}
