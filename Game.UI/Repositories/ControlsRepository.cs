using System.Collections.Generic;
using Game.Core.Enums;
using Game.Core.GameModels;

namespace Game.UI.Repositories
{
    public class ControlsRepository : IControlsRepository
    {
        private TicTacToeControlsModel _ticTacToeControlsModel;

        public ControlsRepository(TicTacToeControlsModel ticTacToeControlsModel)
        {
            _ticTacToeControlsModel = ticTacToeControlsModel;
        }

        public IEnumerable<GameMode> GetGameModes()
        {
           return _ticTacToeControlsModel.GameModes;
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _ticTacToeControlsModel.Players;
        }
    }
}
