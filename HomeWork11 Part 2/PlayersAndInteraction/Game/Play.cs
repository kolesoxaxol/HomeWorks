using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayersAndInteraction.Behaviour;

namespace PlayersAndInteraction.Game
{
    public static class Play
    {
        private static List<IGuessable> _behaviour;

        private static Dictionary<int, string> _typeOfPlayers;

        private static List<Player> _listOfPlayers;

        private static List<int> _allGuesses;

        private static int _minValue;

        private static int _maxValue;

        private static int _winNumber;

        private static int _amountOfPlayers;

        static Play()
        {
            _listOfPlayers = new List<Player>();
            _allGuesses = new List<int>();

            _behaviour = new List<IGuessable>();

            _behaviour.Add(new CasualPlayer());
            _behaviour.Add(new NotePlayer());
            _behaviour.Add(new UberPlayer());
            _behaviour.Add(new CheaterPlayer());
            _behaviour.Add(new UberCheaterPlayer());


            _typeOfPlayers = new Dictionary<int, string>
            {
                { 0, "Casual" },
                { 1, "Note" },
                { 2, "Uber" },
                { 3, "Cheater" },
                { 4, "UberCheater" }
            };

        }

        public static void CreateGame()
        {
            Console.WriteLine("Select amount of players from 2 to 8.");

            _amountOfPlayers = int.Parse(Console.ReadLine());

            for (int i = 0; i < _amountOfPlayers; i++)
            {
                foreach (KeyValuePair<int, string> type in _typeOfPlayers)
                {
                    Console.WriteLine($"{ type.Key}, {type.Value}");
                }

                Console.WriteLine("Select one of the player types!");

                int result = int.Parse(Console.ReadLine());

                Player player = new Player();
                player.SetName();
                player.Behaviour = _behaviour[result];

                _listOfPlayers.Add(player);
            }

            Console.WriteLine("Select minimum value of weight.");

            _minValue = int.Parse(Console.ReadLine());

            Console.WriteLine("Select maximum value of weight.");

            _maxValue = int.Parse(Console.ReadLine());

            foreach (Player player in _listOfPlayers)
            {
                player.Behaviour.GenerateList(_minValue, _maxValue);
            }

        }
        public static void PlayGame()
        {
            _winNumber = RandomGenerator.RandomGenerator.RandomNumber(_minValue, _maxValue);

            Console.WriteLine("Select amount of total tries for all players.");

            int amountOfTries = int.Parse(Console.ReadLine());

            int indexOfTries = 0;

            bool noWinner = true;

            while (indexOfTries < amountOfTries && noWinner)
            {
                foreach (Player player in _listOfPlayers)
                {
                    int guess = player.Behaviour.MakeGuess(_winNumber, _allGuesses);

                    _allGuesses.Add(guess);

                    bool win = guess == _winNumber;
                    if (win)
                    {
                        Console.WriteLine($"Player {player.Name} wins!");
                        noWinner = false;
                        break;
                    }
                    else
                    {
                        indexOfTries++;
                    }

                }
            }

            if (noWinner)
            {
                List<int> allBestGuess = new List<int>();
                foreach (Player player in _listOfPlayers)
                {
                    int bestGuess = player.Behaviour.FindBestGuess(_winNumber);
                    allBestGuess.Add(bestGuess);
                }

                int bestResult = allBestGuess.Min();

                int playerIndex = allBestGuess.IndexOf(bestResult);

                Player winner = _listOfPlayers[playerIndex];

                Console.WriteLine($"Player {winner.Name} wins by the closest guess!");
            }
        }

        public static void ClearGame()
        {
            _listOfPlayers = new List<Player>();
            _allGuesses = new List<int>();
            _amountOfPlayers = 0;
            _minValue = 0;
            _maxValue = 0;
            _winNumber = 0;

        }

    }
}
