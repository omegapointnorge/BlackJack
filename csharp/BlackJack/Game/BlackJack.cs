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
        }

        private void Hit()
        {
            var card = _deck.DrawCard();
            _hand.AddToHand(card);
            var total = _hand.GetHandSum();
            Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, card.Rank, total);
        }

        protected override void ValidatePlay()
        {
            if (!BlackJackValidator.ValidatePlayerHand(_hand))
                _state = GameState.PlayerLoss;
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
