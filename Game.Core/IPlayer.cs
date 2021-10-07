using Game.Core.Enums;

namespace Game.Core
{
    public interface IPlayer
    {
        Player GetPlayerOption();
        void SetPlayerOption(Player player);
        void Play(string[][] ticTacToeBoard);
    }
}
