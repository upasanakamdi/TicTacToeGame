using Game.Core;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IInitialiser gameInitializer = new GameInitializer();
            IEngine gameEngine = new GameEngine();
            IManager gameManager = new GameManager(gameInitializer, gameEngine);

            IPlayer player1 = new RealPlayer();
            IPlayer player2;
            while (true)
            {
                Console.WriteLine("Choose playing mode - 2PLAYER or AI?");
                var mode = Console.ReadLine().ToUpper();
                if (mode.Equals("2PLAYER"))
                {
                    player2 = new RealPlayer();
                    break;
                }
                else if (mode.Equals("AI"))
                {
                    player2 = new AiPlayer();
                    break;
                }
            }

            string[][] ticTacToeBoard = new string[3][];
            gameManager.StartGame(ticTacToeBoard, player1, player2);
            Console.ReadLine();
        }
    }
}
