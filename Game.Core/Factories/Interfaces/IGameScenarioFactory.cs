using Game.Core.Enums;
using Game.Core.Scenarios.Interfaces;

namespace Game.Core.Factories.Interfaces
{
    public interface IGameScenarioFactory
    {
        IGameScenario Create(GameMode gameMode, Enums.Player player);
    }
}
