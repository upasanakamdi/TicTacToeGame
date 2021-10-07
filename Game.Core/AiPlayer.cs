using System;
using Game.Core.Enums;

namespace Game.Core
{
    public class AiPlayer : IPlayer
    {
        private Player _player;

        Player IPlayer.GetPlayerOption()
        {
            return _player;
        }

        void IPlayer.Play(string[][] ticTacToeBoard)
        {
            var length = ticTacToeBoard.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (ticTacToeBoard[i][j].Equals(string.Empty))
                    {
                        ticTacToeBoard[i][j] = _player.ToString();
                        return;
                    }
                }
            }
        }

        void IPlayer.SetPlayerOption(Player player)
        {
            _player = player;
        }
    }
}
