
namespace Game.Core
{
    public class GameInitializer : IInitialiser
    {
        string[][] IInitialiser.InitializeBoard(string[][] ticTacToeBoard)
        {
            var length = ticTacToeBoard.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                ticTacToeBoard[i] = new string[length];
                for (int j = 0; j < length; j++)
                {
                    ticTacToeBoard[i][j] = string.Empty;
                }
            }
            return ticTacToeBoard;
        }
    }
}
