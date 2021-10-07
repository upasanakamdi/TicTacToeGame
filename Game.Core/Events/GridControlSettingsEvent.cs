using Game.Core.Enums;
using Prism.Events;

namespace Game.Core.Events
{
    public class GridControlSettingsEvent : PubSubEvent<GridControlSettings>
    {
    }

    public class GridControlSettings
    {
        public GameMode CurrentGameMode;

        public Player CurrentPlayer;
    }
}
