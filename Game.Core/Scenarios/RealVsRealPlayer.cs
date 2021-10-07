using Game.Core.Enums;
using Game.Core.Factories.Interfaces;
using Game.Core.Scenarios.Interfaces;

namespace Game.Core.Scenarios
{
    public class RealVsRealPlayer : IGameScenario
    {
        private readonly Players.Interfaces.IPlayer _playerOne;
        private readonly Players.Interfaces.IPlayer _playerTwo;
        private Players.Interfaces.IPlayer _currentPlayer;

        public RealVsRealPlayer(IPlayerFactory playerFactory, Player player)
        {
            _playerOne = playerFactory.BuildRealPlayer();
            _playerTwo = playerFactory.BuildRealPlayer();

            _playerOne.SetPlayer(player);
            _playerTwo.SetPlayer(player == Player.O ? Player.X : Player.O);
        }

        PlayResponse IGameScenario.Execute(PlayRequest playRequest)
        {
            _currentPlayer = GetCurrentPlayer();
            PlayResponse playResponse = _currentPlayer.Play(playRequest);
            return playResponse;
        }

        private Players.Interfaces.IPlayer GetCurrentPlayer()
        {
            return (_currentPlayer != null && _currentPlayer == _playerOne) ? _playerTwo : _playerOne;
        }
    }
}
