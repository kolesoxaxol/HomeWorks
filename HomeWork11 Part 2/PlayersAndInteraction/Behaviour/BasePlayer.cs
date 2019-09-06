using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndInteraction.Behaviour
{
    abstract class BasePlayer
    {
        public List<int> _numbers;

        public int _lastGuess;

        public List<int> AllGuesses { get; set; }

        public BasePlayer()
        {
            this.AllGuesses = new List<int>();
            _lastGuess = Int32.MinValue;
        }
        public void GenerateList(int minValue, int maxValue)
        {
            List<int> tempList = new List<int>();

            for (int i = minValue; i <= maxValue; i++)
            {
                tempList.Add(i);
            }

            _numbers = tempList;
        }

        public int FindBestGuess(int answer)
        {
            int bestGuess = Math.Abs(this.AllGuesses[0] - answer);

            foreach (int guess in this.AllGuesses)
            {
                int difference = Math.Abs(guess - answer);

                bool betterResult = difference < bestGuess;

                if (betterResult)
                {
                    bestGuess = difference;
                }
            }

            return bestGuess;
        }
    }
}
