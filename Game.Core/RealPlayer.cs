using System;
using Game.Core.Enums;

namespace Game.Core
{
    public class RealPlayer : IPlayer
    {
        private Player _player;

        Player IPlayer.GetPlayerOption()
        {
            return _player;
        }

        void IPlayer.Play(string[][] ticTacToeBoard)
        {
            Console.WriteLine($"Enter position X for {_player}");
            int positionX = int.Parse(Console.ReadLine());

            Console.WriteLine($"Enter position Y for {_player}");
            int positionY = int.Parse(Console.ReadLine());

            if (ticTacToeBoard[positionX][positionY].Equals(string.Empty))
            {
                ticTacToeBoard[positionX][positionY] = _player.ToString();
            }
        }

        void IPlayer.SetPlayerOption(Player player)
        {
            _player = player;
        }
    }
}
