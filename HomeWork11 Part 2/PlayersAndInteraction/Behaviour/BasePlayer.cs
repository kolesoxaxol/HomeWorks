using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndInteraction.Behaviour
{
    abstract class BasePlayer
    {
        //There I store all numbers a player has to guess among.
        public List<int> _numbers;

        //will be used to reduce _numbers pool for specific types of behaviour
        public int _lastGuess;

        public BasePlayer()
        {
            //I have to set values for BestGuess upon player creation as it will be used when check for better guess will be done for first time.
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
