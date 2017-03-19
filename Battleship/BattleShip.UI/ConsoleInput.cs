using System;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class ConsoleInput
    {
        string input;
        int x;
        int y;
        

        public static string GetPlayerOneName()
        {
            Console.Write("Player One please enter your name: ");
            string player1 = Console.ReadLine();
            return player1;
            
        }
        public static string GetPlayerTwoName()
        {
            Console.Write("Player Two please enter your name: ");
            string player2 = Console.ReadLine();
            return player2;
        }

        public static int GetRowCoordinateFromUser()
        {
            while (true)
            {
                
                Console.Write("Please enter a letter A -J for the row: ");
                string input = Console.ReadLine();
                string lowerInput = input.ToLower();
                switch (lowerInput)
                {
                    case "a":
                        return 1;
                    case "b":
                        return 2;
                    case "c":
                        return 3;
                    case "d":
                        return 4;
                    case "e":
                        return 5;
                    case "f":
                        return 6;
                    case "g":
                        return 7;
                    case "h":
                        return 8;
                    case "i":
                        return 9;
                    case "j":
                        return 10;
                }

            }
        }

        public static int ColumnCoordinateFromUser()
        {
            while (true)
            {
                int output;

                Console.Write("Please enter a number 1 - 10 for the column: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out output))
                {
                    return output;
                }
                else
                {
                    Console.WriteLine("That was not a valid number! Press any key to continue ...");
                    Console.ReadKey();
                }
            }

        }


        public static ShipDirection GetDirectionFromUser()
        {
            string input;
            while (true)
            {
                Console.Write("Enter Up, Down, Left or Right: ");
                int direction = 0;
                input = Console.ReadLine();
                string lowerInput = input.ToLower();
                switch (lowerInput)
                {
                    case "up":
                        return ShipDirection.Up;
                    case "down":
                        return ShipDirection.Down;
                    case "left":
                        return ShipDirection.Left;
                    case "right":
                        return ShipDirection.Right;
                }
            }
        }



        

    }
}





