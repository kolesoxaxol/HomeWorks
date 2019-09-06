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

                this.AllGuesses.Add(this._lastGuess);

                _numbers.Remove(_numbers[0]);
            }
            return this._lastGuess;
        }


    }
}
