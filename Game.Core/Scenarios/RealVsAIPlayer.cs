using Game.Core.Enums;
using Game.Core.Factories.Interfaces;
using Game.Core.Scenarios.Interfaces;

namespace Game.Core.Scenarios
{
    public class RealVsAIPlayer : IGameScenario
    {
        private readonly Players.Interfaces.IPlayer _realPlayer;
        private readonly Players.Interfaces.IPlayer _aiPlayer;
        private Players.Interfaces.IPlayer _currentPlayer;

        public RealVsAIPlayer(IPlayerFactory playerFactory, Player player)
        {
            _realPlayer = playerFactory.BuildRealPlayer();
            _aiPlayer = playerFactory.BuildAIPlayer();

            _realPlayer.SetPlayer(player);
            Player aiPlayer = player == Player.O ? Player.X : Player.O;
            _aiPlayer.SetPlayer(aiPlayer);
        }

        PlayResponse IGameScenario.Execute(PlayRequest playRequest)
        {
            _currentPlayer = GetCurrentPlayer();
            PlayResponse playResponse = _currentPlayer.Play(playRequest);
            if (!playResponse.PlayerWon)
            {
                _currentPlayer = GetCurrentPlayer();
                PlayRequest nextPlayRequest = new PlayRequest {TicTacToeBoard = playResponse.TicTacToeBoard};
                playResponse = _currentPlayer.Play(nextPlayRequest);
            }
            return playResponse;
        }

        private Players.Interfaces.IPlayer GetCurrentPlayer()
        {
            return (_currentPlayer != null && _currentPlayer == _realPlayer) ? _aiPlayer : _realPlayer;
        }
    }
}
