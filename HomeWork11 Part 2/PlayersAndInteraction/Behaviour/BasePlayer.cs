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

        public BasePlayer()
        {
            _lastGuess = Int32.MinValue;
            this.BestGuess = Int32.MaxValue;
        }

        public int BestGuess { get; set; }

        public void GenerateList(int minValue, int maxValue)
        {
            List<int> tempList = new List<int>();

            for (int i = minValue; i <= maxValue; i++)
            {
                tempList.Add(i);
            }

            _numbers = tempList;
        }

    }
}
