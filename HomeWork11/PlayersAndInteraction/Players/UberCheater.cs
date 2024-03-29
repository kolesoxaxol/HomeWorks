﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndInteraction.Players
{
    public class UberCheater : Player
    {

        public override int MakeGuess(int answer, List<int> otherGuesses)
        {
            foreach (int guesses in otherGuesses)
            {
                this._numbers.Remove(guesses);
            }

            bool correctAnswer = _numbers[0] == answer;

            if (!correctAnswer)
            {
                this._lastGuess = _numbers[0];

                this.AllGuesses.Add(this._lastGuess);

                _numbers.Remove(_numbers[0]);
            }
            return this._lastGuess;
        }
        public static Player CreatePlayer()
        {
            try
            {
                UberCheater player = new UberCheater();
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
