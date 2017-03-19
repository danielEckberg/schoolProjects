using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            GameFlow play = new GameFlow();
            do
            {
                GameFlow.PlayGame();
            } while (GameFlow.PlayAgain());
            
        }
    }
}
