using System;

namespace BlackJack
{
    internal class Program
    {
        private static void Main()
        {
            var game = new Game();
            game.Start();
            Console.WriteLine(game.CalculateWinner());
        }
    }
}