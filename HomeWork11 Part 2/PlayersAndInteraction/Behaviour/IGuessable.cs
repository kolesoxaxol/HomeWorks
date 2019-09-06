using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersAndInteraction.Behaviour
{
    interface IGuessable
    {
        int MakeGuess(int answer, List<int> otherGuesses);

        void GenerateList(int minValue, int MaxValue);

        int FindBestGuess(int answer);
    }
}
