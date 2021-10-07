using Game.Core.Enums;
using System.Collections.Generic;

namespace Game.UI.Repositories
{
    public interface IControlsRepository
    {
        IEnumerable<GameMode> GetGameModes();
        IEnumerable<Player> GetPlayers();
    }
}
