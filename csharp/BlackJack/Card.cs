namespace BlackJack
{
    public class Card
    {
        public int Rank;
        public Suit Suit;

        public string GetRank()
        {
            var rank = Rank switch
            {
                1 => "A",
                11 => "J",
                12 => "Q",
                13 => "K",
                _ => Rank.ToString()
            };

            return rank;
        }
    }
}