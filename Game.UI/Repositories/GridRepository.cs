using Game.Core.Enums;
using Game.Core.GameModels;

namespace Game.UI.Repositories
{
    public class GridRepository : IGridRepostiory
    {

        private TicTacToeGridModel _ticTacToeGridModel;

        public GridRepository(TicTacToeGridModel ticTacToeGridModel)
        {
            _ticTacToeGridModel = ticTacToeGridModel;
        }

        public Player[][] GetGridData()
        {
            return new Player[3][]
                {
                    new Player[3]{Player.Unknown, Player.Unknown, Player.Unknown},
                    new Player[3]{Player.Unknown, Player.Unknown, Player.Unknown},
                    new Player[3]{Player.Unknown, Player.Unknown, Player.Unknown}
                };
        }
    }
}
