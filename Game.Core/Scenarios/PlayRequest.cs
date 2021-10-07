using Game.Core.Enums;
using System.Collections.ObjectModel;

namespace Game.Core.Scenarios
{
    public class PlayRequest
    {
        public ObservableCollection<ObservableCollection<Enums.Player>> TicTacToeBoard { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
    }
}
