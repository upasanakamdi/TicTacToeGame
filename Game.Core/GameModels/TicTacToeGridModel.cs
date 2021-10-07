using Game.Core.Enums;

namespace Game.Core.GameModels
{
    public class TicTacToeGridModel
    {
        public Enums.Player[][] TicTacToeBoard;

        public TicTacToeGridModel()
        {
            TicTacToeBoard = new Enums.Player[3][]
                {
                    new Enums.Player[3]{Enums.Player.Unknown, Enums.Player.Unknown, Enums.Player.Unknown},
                    new Enums.Player[3]{Enums.Player.Unknown, Enums.Player.Unknown, Enums.Player.Unknown},
                    new Enums.Player[3]{Enums.Player.Unknown, Enums.Player.Unknown, Enums.Player.Unknown}
                };
        }
    }
}
