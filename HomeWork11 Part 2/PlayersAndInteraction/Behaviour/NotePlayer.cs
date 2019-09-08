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

            int count = this._numbers.Count;

            int indexGuess = RandomGenerator.RandomGenerator.RandomNumber(0, count);

            this._lastGuess = this._numbers[indexGuess];

            bool correctAnswer = this._lastGuess == answer;

            if (!correctAnswer)
            {
                _numbers.Remove(this._lastGuess);
            }

            bool betterGuess = Math.Abs(answer - this._lastGuess) < BestGuess;

            if (betterGuess)
            {
                this.BestGuess = Math.Abs(answer - this._lastGuess);
            }

            return this._lastGuess;

        }
    }
}
