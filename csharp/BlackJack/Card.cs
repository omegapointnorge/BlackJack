namespace BlackJack
{
    public class Card
    {
        public Suit Suit;
        public int Rank;

        /// <summary>
        /// Makes the Ace, Jack, Queen and King cards be represented as characters instead when printed
        /// </summary>
        /// <returns>The string to be printed to the console</returns>
        public string WriteRank()
        {
            var result = "";
            if(this.Rank == 1 || this.Rank > 10)
            {
                switch (this.Rank)
                {
                    case 1:
                        result = "A";
                        break;
                    case 11:
                        result = "J";
                        break;
                    case 12:
                        result = "Q";
                        break;
                    case 13:
                        result = "K";
                        break;
                }
            }
            else
            {
                result = this.Rank.ToString();
            }

            return result;
        }
    }
}
