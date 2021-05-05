using BlackJack.Data;
using BlackJack.Repositories;
using System;

namespace BlackJack.Game
{
    public class BlackJack : CardGame
    {
        private IDeck _deck;
        private IHand _hand;
        private GameState _state;
        
        protected override void Setup()
        {
            _deck = new Deck();
            _hand = new Hand();
            _state = GameState.Running;
        }
        
        protected override void GameLoop()
        {
            while (true)
            {
                while (_state == GameState.Running)
                {
                    var playerChoice = GetPlayerChoice();
                    if (!Enum.TryParse<PlayerChoice>(playerChoice, true, out var choice))
                    {
                        Console.WriteLine("That choice is not supported. Please try again.");
                        continue;
                    }

                    switch (choice)
                    {
                        case PlayerChoice.Hit:
                            Hit();
                            break;
                        case PlayerChoice.Stand:
                            break;
                        case PlayerChoice.Fold:
                            return;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    ValidatePlay();
                    CheckState();
                }
                
                Console.WriteLine("Play again? Y/N");
                var again = Console.ReadLine();
                if ("Y".ToLower().Equals(again?.ToLower()))
                {
                    ResetGame();
                    continue;
                }

                break;
            }
        }

        private void Hit()
        {
            var card = _deck.DrawCard();
            _hand.AddToHand(card);
            // Fetch this beforehand because aces might be set to 1 and it would print 1 instead of A.
            var cardValue = card.Rank.ToString();
            var total = _hand.GetHandSum();
            Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, cardValue, total);
        }

        protected override void ValidatePlay()
        {
            if (!BlackJackValidator.ValidatePlayerHand(_hand))
                _state = GameState.PlayerLoss;
        }

        protected override void ResetGame()
        {
            _deck.ResetDeck();
            _hand.ResetHand();
            _state = GameState.Running;
        }

        protected override void CheckState()
        {
            switch (_state) 
            {
                case GameState.Running:
                    return;
                case GameState.PlayerLoss:
                    Console.WriteLine("Player loses! Try again next time.");
                    break;
                case GameState.DealerLoss:
                    Console.WriteLine("Player wins! Congratulations!");
                    break;
                case GameState.Draw:
                    Console.WriteLine("It's a draw!");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static string GetPlayerChoice()
        {
            Console.WriteLine("Stand, Hit");
            var read = Console.ReadLine();
            return read;
        }
    }
}
