﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndInteraction.Behaviour
{
    class CheaterPlayer : BasePlayer, IGuessable
    {
        public int MakeGuess(int answer, List<int> otherGuesses)
        {
            foreach (int guesses in otherGuesses)
            {
                this._numbers.Remove(guesses);
            }

            int count = this._numbers.Count;

            int indexGuess = RandomGenerator.RandomGenerator.RandomNumber(0, count - 1);

            this._lastGuess = this._numbers[indexGuess];

            bool betterGuess = Math.Abs(answer - this._lastGuess) < BestGuess;

            if (betterGuess)
            {
                this.BestGuess = Math.Abs(answer - this._lastGuess);
            }
            return this._lastGuess;
        }
    }
}
