using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndInteraction.Behaviour
{
    interface IGuessable
    {
        int BestGuess { get; set; }

        int MakeGuess(int answer, List<int> otherGuesses);

        void GenerateList(int minValue, int MaxValue);
    }
}
