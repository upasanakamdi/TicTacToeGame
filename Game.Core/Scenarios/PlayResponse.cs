using Game.Core.Enums;
using System.Collections.ObjectModel;

namespace Game.Core.Scenarios
{
    public class PlayResponse
    {
        public ObservableCollection<ObservableCollection<Enums.Player>> TicTacToeBoard { get; set; }
        public bool PlayerWon { get; set; }
    }
}
