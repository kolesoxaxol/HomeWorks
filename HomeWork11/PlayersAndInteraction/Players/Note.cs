using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndInteraction.Players
{
    public class Note : Player
    {
        public override int MakeGuess(int answer, List<int> otherGuesses)
        {
            foreach (int guesses in otherGuesses)
            {
                this._numbers.Remove(guesses);
            }

            int count = this._numbers.Count;

            int indexGuess = RandomGenerator.RandomGenerator.RandomNumber(0, count);

            this._lastGuess = this._numbers[indexGuess];

            this.AllGuesses.Add(this._lastGuess);

            return this._lastGuess;

        }
        public static Player CreatePlayer()
        {
            try
            {
                Note player = new Note();
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
