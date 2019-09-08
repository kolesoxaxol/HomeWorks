using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndInteraction.Behaviour
{
    class UberPlayer : BasePlayer, IGuessable
    {

        public int MakeGuess(int answer, List<int> otherGuesses)
        {
            bool correctAnswer = _numbers[0] == answer;

            if (!correctAnswer)
            {
                this._lastGuess = _numbers[0];

                _numbers.Remove(_numbers[0]);
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
