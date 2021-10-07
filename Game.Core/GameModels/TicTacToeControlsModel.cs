using Game.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.Core.GameModels
{
    public class TicTacToeControlsModel
    {
        public IEnumerable<GameMode> GameModes { get; }
        public IEnumerable<Enums.Player> Players { get; }

        public TicTacToeControlsModel()
        {
            GameModes = Enum.GetValues(typeof(GameMode)).Cast<GameMode>();
            Players = Enum.GetValues(typeof(Enums.Player)).Cast<Enums.Player>();
        }
    }
}
