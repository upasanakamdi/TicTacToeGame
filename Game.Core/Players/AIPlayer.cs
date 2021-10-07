using Game.Core.Enums;
using Game.Core.Scenarios;

namespace Game.Core.Players
{
    public class AIPlayer : Interfaces.IPlayer
    {
        private IEngine _gameEngine;

        public AIPlayer(IEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

        public Player Player { get; private set; }

        PlayResponse Interfaces.IPlayer.Play(PlayRequest playRequest)
        {
            PlayResponse playResponse = new PlayResponse();
            int boardLength = playRequest.TicTacToeBoard.Count;

            for (int i = 0; i < boardLength; i++)
            {
                for (int j = 0; j < boardLength; j++)
                {
                    if (playRequest.TicTacToeBoard[i][j].Equals(Enums.Player.Unknown))
                    {
                        playRequest.TicTacToeBoard[i][j] = Player;
                        playResponse.TicTacToeBoard = playRequest.TicTacToeBoard;
                        playResponse.PlayerWon = _gameEngine.CheckForVictory(playRequest.TicTacToeBoard, Player);
                        return playResponse;
                    }
                }
            }

            return playResponse;
        }

        public void SetPlayer(Player player)
        {
            Player = player;
        }
    }
}
