using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndInteraction.Behaviour
{
    class NotePlayer : BasePlayer, IGuessable
    {
        public int MakeGuess(int answer, List<int> otherGuesses)
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
    }
}
