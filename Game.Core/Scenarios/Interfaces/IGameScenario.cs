namespace Game.Core.Scenarios.Interfaces
{
    public interface IGameScenario
    {


        PlayResponse Execute(PlayRequest playRequest);
    }
}