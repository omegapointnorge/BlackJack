using System;

namespace BlackJack
{
    class Program
    {
        private static void Main()
        {
            var choice = "Y";
            while("Y".Equals(choice))
            {
                new Game.BlackJack().Start();
                Console.Write("Do you want to play again? Y/N");
                choice = Console.ReadLine();
            }
        }
    }
}
