using System;


namespace BattleShip.UI
{
    public class GameFlow
    {
        
        ConsoleOutput play = new ConsoleOutput();
        ConsoleInput input = new ConsoleInput();
        
        private static Random _rng = new Random();

        public static void PlayGame()
        {
            Player p1 = new Player();
            Player p2 = new Player();
            string player1;
            string player2;
            
            
            ConsoleOutput.DisplayTitle();
            player1 = ConsoleInput.GetPlayerOneName();
            p1.SetName(player1);
            player2 = ConsoleInput.GetPlayerTwoName();
            p2.SetName(player2);
            
            Console.Clear();
            p1.PlaceShipOnBoard();
            Console.Clear();
            p2.PlaceShipOnBoard();

            int whoseTurn = _rng.Next(1, 3);
            do
            {
                if (whoseTurn == 1)
                {
                    Console.Clear();
                    p2.DisplayBoard(p1);
                    p2.FireShotAtBoard(p1);
                    whoseTurn = 2;


                }
                else
                {
                    Console.Clear();
                    p1.DisplayBoard(p2);
                    p1.FireShotAtBoard(p2);
                    whoseTurn = 1;

                }
                Console.ReadLine();
            } while (!p1.GetWonGame() && !p2.GetWonGame());
            
        }
        public static bool PlayAgain()
        {
            while (true) 
            {
                Console.Write("Would you like to play again [Y/N]?");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y")
                    return true;
                if (answer == "n")
                    return false;
            }
        }
    }
}
