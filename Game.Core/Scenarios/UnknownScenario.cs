using Game.Core.Scenarios.Interfaces;

namespace Game.Core.Scenarios
{
    public class UnknownScenario : IGameScenario
    {
        PlayResponse IGameScenario.Execute(PlayRequest playRequest)
        {
            return new PlayResponse();
        }
    }
}
