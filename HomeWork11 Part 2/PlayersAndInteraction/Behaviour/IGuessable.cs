using System.Collections.Generic;

namespace PlayersAndInteraction.Behaviour
{
    interface IGuessable
    {
        int BestGuess { get; set; }

        //other Guesses will contain all players' last guess by the time MakeGuess is called.
        int MakeGuess(int answer, List<int> otherGuesses);

        void GenerateList(int minValue, int MaxValue);
    }
}
