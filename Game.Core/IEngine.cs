using System.Collections.ObjectModel;
using Game.Core.Enums;

namespace Game.Core
{
    public interface IEngine
    {
        Player CheckForVictory(string[][] ticTacToeBoard, Player player);

        bool CheckForVictory(ObservableCollection<ObservableCollection<Enums.Player>> ticTacToeBoard, Player player);
    }
}
