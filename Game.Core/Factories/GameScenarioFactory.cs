using System.Collections.Generic;
using Game.Core.Enums;
using Game.Core.Factories.Interfaces;
using Game.Core.Scenarios;
using Game.Core.Scenarios.Interfaces;

namespace Game.Core.Factories
{
    public class GameScenarioFactory : IGameScenarioFactory
    {
        private IPlayerFactory _playerFactory;

        public GameScenarioFactory(IPlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        IGameScenario IGameScenarioFactory.Create(GameMode gameMode, Player player)
        {
            var gameScenarioDict = new Dictionary<GameMode, IGameScenario>()
            {
                {GameMode.TwoPlayer, new RealVsRealPlayer(_playerFactory, player)},
                {GameMode.AI, new RealVsAIPlayer(_playerFactory, player)},
                {GameMode.None, new UnknownScenario()}
            };
            return gameScenarioDict[gameMode];
        }
    }
}