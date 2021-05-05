using System;

namespace BlackJack
{
    class Program
    {
        private static void Main()
        {
            var choice = "Y";
            while("Y".ToLower().Equals(choice?.ToLower()))
            {
                new Game.BlackJack().Start();
                Console.Write("Do you want to play again? Y/N\n");
                choice = Console.ReadLine();
            }
        }
    }
}
