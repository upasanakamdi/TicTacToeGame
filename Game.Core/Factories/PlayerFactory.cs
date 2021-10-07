using Game.Core.Factories.Interfaces;
using Game.Core.Players;

namespace Game.Core.Factories
{
    public class PlayerFactory : IPlayerFactory
    {
        private IEngine _gameEngine; 

        public PlayerFactory(IEngine gameEngine)
        {
            _gameEngine = gameEngine;
        }

        public Players.RealPlayer BuildRealPlayer()
        {
            return new Players.RealPlayer(_gameEngine);
        }

        public AIPlayer BuildAIPlayer()
        {
            return new AIPlayer(_gameEngine);
        }
    }
}
