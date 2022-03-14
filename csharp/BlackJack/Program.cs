using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var blackJack=new BlackJackGame();
            while (true)
            {
                blackJack.PlayRound();
            }
        }
    }
}
