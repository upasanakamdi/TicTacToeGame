using Game.Core.Enums;
using Game.Core.Scenarios;

namespace Game.Core.Players
{
    public class RealPlayer : Interfaces.IPlayer
    {
        private IEngine _gameEngine;

        public RealPlayer(IEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

        PlayResponse Interfaces.IPlayer.Play(PlayRequest playRequest)
        {
            PlayResponse playResponse = new PlayResponse();
            if (playRequest.TicTacToeBoard[playRequest.XPosition][playRequest.YPosition].Equals(Enums.Player.Unknown))
            {
                playRequest.TicTacToeBoard[playRequest.XPosition][playRequest.YPosition] = Player;
                playResponse.TicTacToeBoard = playRequest.TicTacToeBoard;
            }

            playResponse.PlayerWon = _gameEngine.CheckForVictory(playRequest.TicTacToeBoard, Player);
            return playResponse;
        }

        public Player Player { get; private set; }

        public void SetPlayer(Player player)
        {
            Player = player;
        }
    }
}
