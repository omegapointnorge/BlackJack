using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Dealer: Participant
    {

        /// <summary>
        /// Function to finish up the game for the dealer
        /// </summary>
        /// <param name="deck"></param>
        public void FinishGame(Deck deck)
        {
            while(true)
            {
                var card = GetNewCardAndUpdateDeck(ref deck);
                AddCardToHand(card);
                var total = GetSumOfHand();
                WriteStatsToConsole("Dealer", card);
                if (total >= 17)
                {
                    break;
                }
            }
        }
    }
}
