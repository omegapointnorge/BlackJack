using BlackJack.GameElements;

namespace BlackJack.Game
{
    public static class BlackJackValidator
    {
        public const int BlackJackLimit = 21;
        public const int DealerLimit = 18;

        public static bool ValidateHand(Hand hand)
        {
            return hand.GetHandSum() <= BlackJackLimit;
        }
    }
}
