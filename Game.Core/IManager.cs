namespace Game.Core
{
    public interface IManager
    {
        void StartGame(string[][] ticTacToeBorad, IPlayer player1, IPlayer player2);
    }
}
