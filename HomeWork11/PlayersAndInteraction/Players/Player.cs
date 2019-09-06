using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndInteraction.Players
{
    public abstract class Player
    {
        public List<int> _numbers;

        public int _lastGuess;

        public Player()
        {
            this.AllGuesses = new List<int>();
            _lastGuess = Int32.MinValue;
        }


        public string Name { get; set; }

        public List<int> AllGuesses { get; set; }

        public void GenerateList(int minValue, int maxValue)
        {
            List<int> tempList = new List<int>();

            for (int i = minValue; i <= maxValue; i++)
            {
                tempList.Add(i);
            }

            _numbers = tempList;
        }

        public virtual int MakeGuess(int answer, List<int> otherGuesses)
        {

            int count = this._numbers.Count;

            int indexGuess = RandomGenerator.RandomGenerator.RandomNumber(0, count - 1);

            this._lastGuess = this._numbers[indexGuess];

            this.AllGuesses.Add(this._lastGuess);

            return this._lastGuess;
        }

        public int FindBestGuess(int answer)
        {
            int bestGuess = Math.Abs(this.AllGuesses[0] - answer);

            foreach (int guess in this.AllGuesses)
            {
                int difference = Math.Abs(guess - answer);

                bool betterResult = difference < bestGuess;

                if(betterResult)
                {
                    bestGuess = difference;
                }
            }

            return bestGuess;
        }

    }
}
