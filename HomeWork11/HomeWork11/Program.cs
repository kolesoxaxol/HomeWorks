using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayersAndInteraction;

namespace HomeWork11
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                PlayersAndInteraction.Game.Play.CreateGame();
                PlayersAndInteraction.Game.Play.PlayGame();
                PlayersAndInteraction.Game.Play.ClearGame();
            }

            Console.ReadKey();


        }
    }
}
