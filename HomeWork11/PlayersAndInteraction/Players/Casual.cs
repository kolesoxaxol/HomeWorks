using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndInteraction.Players
{
    public class Casual : Player
    {

        public static Player CreatePlayer()
        {
            try
            {
                Casual player = new Casual();
                Console.WriteLine("Enter a name!");
                player.Name = Console.ReadLine();

                return player;
            }
            catch
            {
                return null;
            }
        }
    }
}
