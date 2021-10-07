using System;
using System.Linq;
using Game.Core.Enums;

namespace Game.Core
{
    public class GameManager : IManager
    {
        private readonly IInitialiser _gameInitializer;
        private readonly IEngine _gameEngine;
        private string[][] _ticTacToeBoard;
        private IPlayer _player1;
        private IPlayer _player2;
     

        public GameManager(IInitialiser gameInitializer, IEngine gameEngine)
        {
            _gameInitializer = gameInitializer;
            _gameEngine = gameEngine;
        }

        void IManager.StartGame(string[][] ticTacToeBoard, IPlayer player1, IPlayer player2)
        {
            _ticTacToeBoard = _gameInitializer.InitializeBoard(ticTacToeBoard);
            _player1 = player1;
            _player2 = player2;
            ChoosePlayer();
            PlayGame();
        }

       

        private void ChoosePlayer()
        {
            Console.WriteLine("Player1, Do you want to be X or O?");
            while (true)
            {
                var selectedOption = Console.ReadLine().ToUpper();
                var XorO = Player.Unknown;
                if (Enum.TryParse(selectedOption, out XorO))
                {
                    _player1.SetPlayerOption(XorO);

                    var player2Option = Enum.GetValues(typeof(Player))
                        .Cast<Player>()
                        .Where(e => e != XorO && e != Player.Unknown)
                        .First();

                    _player2.SetPlayerOption(player2Option);
                    break;
                }
            }
        }

        private void PlayGame()
        {
            var currentPlayer = _player1;
            var winner = Player.Unknown;

            while (winner.Equals(Player.Unknown))
            {
                winner = PlayerTurnToPlayGame(currentPlayer);

                currentPlayer = currentPlayer == _player1 ? _player2 : _player1;
            }
            Console.WriteLine($"Winner : {winner}");
        }

        private Player PlayerTurnToPlayGame(IPlayer player)
        {
            player.Play(_ticTacToeBoard);

            Console.WriteLine();
            _ticTacToeBoard.ToList().ForEach(e =>
            {
                e.ToList().ForEach(x =>
                {
                    var selection = string.IsNullOrEmpty(x) ? " " : x;
                    Console.Write(selection);
                });
                Console.WriteLine();
            });

            return _gameEngine.CheckForVictory(_ticTacToeBoard, player.GetPlayerOption());
        }
    }
}
