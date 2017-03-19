using System;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    class ConsoleOutput
    {
        Board game = new Board();
        ShotHistory shot = new ShotHistory();

        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Battleship!!\n\n");
            Console.WriteLine("Press any key to start the game...");
            Console.ReadKey();
        }













        

        


    }
}

