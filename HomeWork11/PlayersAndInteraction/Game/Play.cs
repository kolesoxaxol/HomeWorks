using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayersAndInteraction.Players;
using RandomGenerator;

namespace PlayersAndInteraction.Game
{
    public static class Play
    {
        public static List<Player> _listOfPlayers;

        public static List<int> _allGuesses;

        public static List<Func<Player>> _createPlayer;

        public static Dictionary<int, string> _typeOfPlayers;

        public static int _minValue;

        public static int _maxValue;

        public static int _winNumber;

        public static int _amountOfPlayers;

        static Play()
        {
            _listOfPlayers = new List<Player>();
            _allGuesses = new List<int>();

            _createPlayer = new List<Func<Player>>();

            _createPlayer.Add(() => Casual.CreatePlayer());
            _createPlayer.Add(() => Note.CreatePlayer());
            _createPlayer.Add(() => Uber.CreatePlayer());
            _createPlayer.Add(() => Cheater.CreatePlayer());
            _createPlayer.Add(() => UberCheater.CreatePlayer());

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

                _listOfPlayers.Add(_createPlayer[result]());
            }

            Console.WriteLine("Select minimum value of weight.");

            _minValue = int.Parse(Console.ReadLine());

            Console.WriteLine("Select maximum value of weight.");

            _maxValue = int.Parse(Console.ReadLine());

            foreach (Player player in _listOfPlayers)
            {
                player.GenerateList(_minValue, _maxValue);
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
                    int guess = player.MakeGuess(_winNumber, _allGuesses);

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

            if(noWinner)
            {
                List<int> allBestGuess = new List<int>();
                foreach(Player player in _listOfPlayers)
                {
                    int bestGuess = player.FindBestGuess(_winNumber);
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
