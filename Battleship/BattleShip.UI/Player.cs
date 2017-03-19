using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class Player
    {
        Board board = new Board();
        private string _name { get; set; }
        public bool notDuplicate;
        public bool _wonGame;

        public string GetName()
        {
            return _name;
        }
        public void SetName(string newName)
        {
            _name = newName;
        }

        public bool GetWonGame()
        {
            return _wonGame;
        }

        
        public void PlaceShipOnBoard()
        {
            
            int row;
            int column;
            ShipDirection direction;

            for (int i = 0; i < 5; i++)
            {
                do
                {

                    ShipType currentShip = (ShipType)i;

                    Console.WriteLine($"{_name} let's place the " + currentShip);
                    row = ConsoleInput.GetRowCoordinateFromUser();
                    column = ConsoleInput.ColumnCoordinateFromUser();
                    direction = ConsoleInput.GetDirectionFromUser();
                    

                    PlaceShipRequest request = new PlaceShipRequest()
                    {
                        Coordinate = new Coordinate(row, column),
                        Direction = direction,
                        ShipType = currentShip,
                    };

                    var response = board.PlaceShip(request);

                    if (response == ShipPlacement.NotEnoughSpace)
                    {
                        Console.WriteLine("There was not enough space to place the ship.");
                    }
                    if (response == ShipPlacement.Overlap)
                    {
                        Console.WriteLine("That overlaps with another ship.");
                    }
                    if (response == ShipPlacement.Ok)
                        break;
                } while (true);

            }

        }
        public void FireShotAtBoard(Player target)
        {
            do
            {

                
            Console.WriteLine($"It's time to shoot, {_name}.");
            int row = ConsoleInput.GetRowCoordinateFromUser();
            int column = ConsoleInput.ColumnCoordinateFromUser();
            var coordinate = new Coordinate(row, column);
            var response = target.board.FireShot(coordinate);
            
            switch (response.ShotStatus)
            {
                    case ShotStatus.Invalid:
                        Console.WriteLine("That's not a valid coordinate. Please try again.");
                    notDuplicate = false;
                    break;
                    case ShotStatus.Duplicate:
                    Console.WriteLine("You already shot there, try a different space.");
                    notDuplicate = false;
                    
                    break;
                    case ShotStatus.Miss:
                        Console.WriteLine($"Sorry, {_name} you missed.");
                    notDuplicate = true;
                        break;
                    case ShotStatus.Hit:
                    Console.WriteLine($"You hit a ship!");
                    notDuplicate = true;
                    break;
                    case ShotStatus.HitAndSunk:
                    Console.WriteLine($"You hit and sunk {response.ShipImpacted}");
                    notDuplicate = true;
                        break;
                    case ShotStatus.Victory:
                    Console.WriteLine($"Congratulations {_name} have sunk all the ships and won the game!!!");
                    _wonGame = true;
                    break;
            }
            } while (!notDuplicate);

        }
        public void DisplayBoard(Player target)
        {

            Console.Clear();

            for (int i = 0; i <= 10; i++)
            {
                for (int j = 0; j <= 10; j++)
                {


                    if (i == 0)
                    {
                        switch (j)
                        {
                            case 0:
                                Console.Write("     ");
                                break;
                            case 1:
                                Console.Write("  1  ");
                                break;
                            case 2:
                                Console.Write("  2  ");
                                break;
                            case 3:
                                Console.Write("  3  ");
                                break;
                            case 4:
                                Console.Write("  4  ");
                                break;
                            case 5:
                                Console.Write("  5  ");
                                break;
                            case 6:
                                Console.Write("  6  ");
                                break;
                            case 7:
                                Console.Write("  7  ");
                                break;
                            case 8:
                                Console.Write("  8  ");
                                break;
                            case 9:
                                Console.Write("  9  ");
                                break;
                            case 10:
                                Console.Write("  10  ");
                                break;

                        }

                    }
                    if (j == 0)
                    {
                        switch (i)
                        {

                            case 1:
                                Console.Write("  A  ");
                                break;
                            case 2:
                                Console.Write("  B  ");
                                break;
                            case 3:
                                Console.Write("  C  ");
                                break;
                            case 4:
                                Console.Write("  D  ");
                                break;
                            case 5:
                                Console.Write("  E  ");
                                break;
                            case 6:
                                Console.Write("  F  ");
                                break;
                            case 7:
                                Console.Write("  G  ");
                                break;
                            case 8:
                                Console.Write("  H  ");
                                break;
                            case 9:
                                Console.Write("  I  ");
                                break;
                            case 10:
                                Console.Write("  J  ");
                                break;
                        }
                    }

                    else if (j > 0 && i > 0)
                    {

                        var coordinate = new Coordinate(i, j);
                        var checkboard = target.board.CheckCoordinate(coordinate);

                        switch (checkboard)
                        {
                            case ShotHistory.Unknown:
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("| O |");
                                break;
                            case ShotHistory.Miss:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("| M |");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case ShotHistory.Hit:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("| H |");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }


                    }

                }
                Console.WriteLine();
            }
        }
    }

    
}

