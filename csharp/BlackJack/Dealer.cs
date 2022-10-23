using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    public class Dealer : Player
    {

        public void FinishGame(Deck deck)
        {
            while(true)
            {
                // Draw card
                // If sum of hand is greater than 17, stop drawing and compare
                // If not, draw another card
                // When finished compare the scores and announce the winner
                var card = GetNewCard(deck);
                AddCardToHand(card);
                var total = GetSumOfHand();
                WriteStatsToConsole("Dealer ", card);
                if (total >= 17)
                {
                    break;
                }
            }
        }
    }
}
