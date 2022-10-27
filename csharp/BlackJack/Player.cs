using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace BlackJack
{
    public class Player: Participant
    {
        /// <summary>
        /// Function for getting the answer of the player
        /// </summary>
        /// <returns>The answer which was typed into the console</returns>
        public string GetNextAnswer()
        {
            return Console.ReadLine();
        }
    }
}
