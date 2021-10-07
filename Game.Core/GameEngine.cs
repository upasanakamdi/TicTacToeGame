using System.Collections.ObjectModel;
using Game.Core.Enums;

namespace Game.Core
{
    public class GameEngine : IEngine
    { 
        Player IEngine.CheckForVictory(string[][] ticTacToeBoard, Player player)
        {

            var leftDiagonalVictory = 0;
            var rightDiagonalVictory = 0;

            for (int i = 0; i < ticTacToeBoard.Length; i++)
            {
                if (ticTacToeBoard[i][i].Equals(player.ToString()))
                {
                    leftDiagonalVictory++;
                }

                if (leftDiagonalVictory == 3)
                {
                    return player;
                }

                var horizontalVictory = 0;
                var verticalVictory = 0;

                for (int j = 0; j < ticTacToeBoard.Length; j++)
                {
                    if (ticTacToeBoard[i][j].Equals(player.ToString()))
                    {
                        horizontalVictory++;
                    }

                    if (ticTacToeBoard[j][i].Equals(player.ToString()))
                    {
                        verticalVictory++;
                    }

                    if (ticTacToeBoard[i][j].Equals(player.ToString()) && ticTacToeBoard[j][i].Equals(player.ToString()))
                    {
                        rightDiagonalVictory++;
                    }

                    if (horizontalVictory == 3 || verticalVictory == 3 || rightDiagonalVictory == 3)
                    {
                        return player;
                    }
                }
            }
            return Player.Unknown;
        }

        public bool CheckForVictory(ObservableCollection<ObservableCollection<Player>> ticTacToeBoard, Player player)
        {
            var leftDiagonalVictory = 0;
            var rightDiagonalVictory = 0;
            var boardLength = ticTacToeBoard.Count;

            for (int i = 0; i < boardLength; i++)
            {
                if (ticTacToeBoard[i][i].Equals(player))
                {
                    leftDiagonalVictory++;
                }

                if (leftDiagonalVictory == 3)
                {
                    return true;
                }

                var horizontalVictory = 0;
                var verticalVictory = 0;

                for (int j = 0; j < boardLength; j++)
                {
                    if (ticTacToeBoard[i][j].Equals(player))
                    {
                        horizontalVictory++;
                    }

                    if (ticTacToeBoard[j][i].Equals(player))
                    {
                        verticalVictory++;
                    }

                    if (ticTacToeBoard[i][j].Equals(player) && ticTacToeBoard[j][i].Equals(player) && i + j + 1 == boardLength)
                    {
                        rightDiagonalVictory++;
                    }

                    if (horizontalVictory == 3 || verticalVictory == 3 || rightDiagonalVictory == 3)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}