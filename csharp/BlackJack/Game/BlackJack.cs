using BlackJack.Data;
using BlackJack.GameElements;
using System;

namespace BlackJack.Game
{
    public class BlackJack : CardGame
    {
        private GameState _state;
        private IDeck _deck;
        private Hand _playerHand;
        private Hand _dealerHand;
        
        protected override void Setup()
        {
            _state = GameState.Running;
            _deck = new Deck();
            _playerHand = new PlayerHand();
            _dealerHand = new DealerHand();
        }
        
        protected override void GameLoop()
        {
            while (true)
            {
                var dealerCard = Hit(_dealerHand);
                while (_state == GameState.Running)
                {
                    Console.WriteLine($"Dealer has {dealerCard.Rank}");

                    var playerChoice = GetPlayerChoice();
                    if (!Enum.TryParse<PlayerChoice>(playerChoice, true, out var choice))
                    {
                        Console.WriteLine("That choice is not supported. Please try again.");
                        continue;
                    }

                    switch (choice)
                    {
                        case PlayerChoice.Hit:
                            var card = Hit(_playerHand);
                            // Fetch this beforehand because aces might be set to 1 and it would print 1 instead of A.
                            var cardValue = card.Rank.ToString();
                            var total = _playerHand.GetHandSum();
                            Console.WriteLine($"Hit with {card.Suit} {cardValue}. Total is {total}");
                            break;
                        case PlayerChoice.Stand:
                            PlayDealer();
                            DetermineWinner();
                            break;
                        case PlayerChoice.Fold:
                            _state = GameState.PlayerLoss;
                            break;
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

        protected override void ResetGame()
        {
            _deck.ResetDeck();
            _playerHand.ResetHand();
            _dealerHand.ResetHand();
            _state = GameState.Running;
        }

        private void PlayDealer()
        {
            while (_dealerHand.GetHandSum() < BlackJackValidator.DealerLimit)
            {
                var card = Hit(_dealerHand);
                Console.WriteLine($"Dealer hit and got {card.Rank}. Dealers total is {_dealerHand.GetHandSum()}");
            }
        }

        private Card Hit(Hand hand)
        {
            var card = _deck.DrawCard();
            hand.AddToHand(card);
            return card;
        }

        private void ValidatePlay()
        {
            if (!BlackJackValidator.ValidateHand(_playerHand))
            {
                _state = GameState.PlayerLoss;
            }
            
            if (!BlackJackValidator.ValidateHand(_dealerHand))
            {
                _state = GameState.DealerLoss;
            }
        }

        private void DetermineWinner()
        {
            var playerHandSum = _playerHand.GetHandSum();
            var dealerHandSum = _dealerHand.GetHandSum();
            if (playerHandSum == dealerHandSum)
            {
                _state = GameState.Draw;
            }
            else if (playerHandSum > dealerHandSum)
            {
                _state = GameState.DealerLoss;
            }
            else if (dealerHandSum > playerHandSum)
            {
                _state = GameState.PlayerLoss;
            }
        }

        private void CheckState()
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
