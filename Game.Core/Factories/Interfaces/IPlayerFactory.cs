namespace Game.Core.Factories.Interfaces
{
    public interface IPlayerFactory
    {
        Players.RealPlayer BuildRealPlayer();

        Players.AIPlayer BuildAIPlayer();
    }
}
