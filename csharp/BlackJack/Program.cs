using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var player = new Player();
            var dealer = new Dealer();
            var play = true;

            while(play)
            {
                StartGame(player, dealer);
                var winner = DetermineWinner(player,dealer);
                WriteScoreToFile(winner, player, dealer);
                Console.WriteLine("\n What would you like to do next?" +
                    " \n 1. Play again (Write 1) " +
                    "\n 2. See the total amount of wins for player and dealer and start a new game(Write 2). " +
                    "\n 3. See the total amount of wins for player and dealer and quit after (write 3)" +
                    "\n 4. Quit the game (Write 4 or any letter)");
                string answer = player.GetNextAnswer();

                switch (answer)
                {
                    case "1":
                        ResetGame(player, dealer);
                        break;
                    case "2":
                        GetStatisticsFromFile();
                        Console.WriteLine("\n Press Enter to proceed");
                        Console.ReadLine();
                        ResetGame(player, dealer);
                        break;
                    case "3":
                        GetStatisticsFromFile();
                        Console.WriteLine("\n Press Enter to proceed");
                        Console.ReadLine();
                        play = false;
                        break;
                    case "4":
                        Console.WriteLine("\n Thanks for playing, see you again next time :)");
                        play = false;
                        break;
                    default:
                        play = false;
                        break;
                }
            }
        }

        public static void StartGame(Player player, Dealer dealer)
        {
            var deck = new Deck();
            var dealerCard = dealer.GetNewCardAndUpdateDeck(ref deck);
            dealer.AddCardToHand(dealerCard);
            dealer.WriteStatsToConsole("Dealer", dealerCard);
            while (true)
            {
                Console.WriteLine("Stand, Hit");
                string read = Console.ReadLine();
                if (read == "Hit")
                {
                    // Get a card from a specific index and remove it afterwards
                    var card = player.GetNewCardAndUpdateDeck(ref deck);
                    player.AddCardToHand(card);
                    var total = player.GetSumOfHand();

                    if (total > 21)
                    {
                        Console.WriteLine("\n The sum of your hand exceedes 21, which means you've lost this round");
                        break;
                    }

                    player.WriteStatsToConsole("You", card);
                }
                else if (read == "Stand")
                {
                    break;
                }
            }
            dealer.FinishGame(deck);
        }

        public static string DetermineWinner(Player player, Dealer dealer)
        {
            var playerSum = player.GetSumOfHand();
            var dealerSum = dealer.GetSumOfHand();
            Console.WriteLine("\n Dealer has {0}, you have {1}", dealerSum, playerSum);
            var winner = String.Empty;

            if (dealerSum > 21 && playerSum > 21)
            {
                winner = "Player & Dealer went bust";
                Console.WriteLine("\n Both the player and dealer busted, better luck next round");
            }
            else if (dealerSum > 21 || playerSum > 21)
            {
                bool playerBust = playerSum > 21;
                string prefix = playerBust ? "player" : "dealer";
                string suffix = playerBust ? "dealer" : "player";
                Console.WriteLine("\n {0} went bust, {1} wins!", prefix, suffix);
                winner = playerBust ? "Dealer" : "Player";
            }
            else
            {
                if (playerSum == dealerSum)
                {
                    winner = "Player & Dealer had equal scores";
                    Console.WriteLine("\n The score is equal meaning there is no winner");
                }
                else
                {
                    winner = playerSum > dealerSum ? "Player" : "Dealer";
                    Console.WriteLine("\n The {0} is winner of this round!", winner);
                }
            }
            return winner;
        }

        public static void WriteScoreToFile(string winner, Player player, Dealer dealer)
        {
            try
            {
            var pathToDir = Path.Combine(Environment.CurrentDirectory,"BlackJack-scores");
            var pathToFile = Path.Combine(pathToDir, "records.txt");

            // If dir / file doesn't already exist, create them
            if (!Directory.Exists(pathToDir))
            {
                Directory.CreateDirectory(pathToDir);
            } else if (!File.Exists(pathToFile))
            {
                File.CreateText(pathToFile);
            }

            using (StreamWriter sw = File.AppendText(pathToFile))
            {
                sw.WriteLine("Winner was {0}", winner);
                if(winner == "Player")
                {
                    sw.WriteLine("With a score of {0}", player.GetSumOfHand());
                } else if(winner == "Dealer")
                {
                    sw.WriteLine("With a score of {0}", dealer.GetSumOfHand());
                } else if(winner == "Player & Dealer, they had equal scores")
                {
                    sw.WriteLine("Player & Dealer had equal scores of {0}",player.GetSumOfHand());
                } else
                {
                    sw.WriteLine(winner);
                }
            }
            } catch(Exception)
            {
                throw new Exception("Something went wrong while write score to file");
            }
        }

        public static void GetStatisticsFromFile()
        {
            string pathToDir = Path.Combine(Environment.CurrentDirectory, "BlackJack-scores");
            string pathToFile = Path.Combine(pathToDir, "records.txt");

            int playerWins = 0;
            int playerOccurrance = 0;

            int dealerWins = 0;
            int dealerOccurrance = 0;

            List<string> lines = new List<string>(File.ReadLines(pathToFile));
            for (var i = 0; i < lines.Count; i++)
            {
                // Check if line contains player / dealer and add the score to the counters
                if(i % 2 == 0)
                {
                        if (lines[i].ToLower().Contains("player & dealer"))
                        {
                            playerOccurrance += 1;
                            dealerOccurrance += 1;
                        }
                        else if (lines[i].ToLower().Contains("player"))
                        {
                            playerWins += 1;
                            playerOccurrance += 1;
                        }
                        else
                        {
                            dealerWins += 1;
                            dealerOccurrance += 1;
                        }
                } 
            }
            int totalOccurrance = playerOccurrance + dealerOccurrance;
            

            Console.WriteLine("The player has won a total of {0} matches and the dealer has won " +
                "a total of {1} matches over the course of {2} games", playerWins, dealerWins, totalOccurrance);
        }

        public static void ResetGame(Player player , Dealer dealer)
        {
            Console.Clear();
            player.EmptyHand();
            dealer.EmptyHand();
        }
    }
}
