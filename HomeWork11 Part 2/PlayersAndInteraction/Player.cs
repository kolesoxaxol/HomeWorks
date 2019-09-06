using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayersAndInteraction.Behaviour;

namespace PlayersAndInteraction
{
    class Player
    {
        
        public string Name { get; private set; }

        public IGuessable Behaviour {get;set;}

        public void SetName()
        {
            Console.WriteLine("Select a Name of a player:");

            this.Name = Console.ReadLine();
        }
    }
}
