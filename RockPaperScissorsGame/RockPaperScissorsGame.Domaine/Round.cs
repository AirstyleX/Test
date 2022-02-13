using RockPaperScissorsGame.Domaine.GameAction;
using RockPaperScissorsGame.Domaine.Players;

namespace RockPaperScissorsGame.Domaine
{
    internal class Round : IRound
    {
        private readonly IUIInterface _uIInterface;
        private readonly IPlayer _playerOne;
        private readonly IPlayer _playerTwo;
        private readonly IActionOptionComparer _cardsComparer;
        private readonly int _roundNumber;

        public Round(IUIInterface uIInterface, IPlayer playerOne, IPlayer playerTwo, IActionOptionComparer cardsComparer, int roundNumber)
        {
            _uIInterface = uIInterface;
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            _cardsComparer = cardsComparer;
            _roundNumber = roundNumber;
        }

        public void Start()
        {
            _uIInterface.MakeASeparation();
            _uIInterface.WriteLine($"Round {_roundNumber} is beginning...");
            Process();
        }

        private void Process()
        {
            var resultBoard = new Dictionary<IPlayer, IActionOption?>
            {
                { _playerOne,  ProcessPlayerPlay(_playerOne)},
                { _playerTwo, ProcessPlayerPlay(_playerTwo)},
            };
            EndOfRound(resultBoard);
        }

        private IActionOption ProcessPlayerPlay(IPlayer player)
        {
            var optionPlayer = player.Play();
            _uIInterface.WriteLine($"{player.Name} plays {optionPlayer.Name}");
            return optionPlayer;
        }

        internal void EndOfRound(Dictionary<IPlayer, IActionOption?> resultBoard)
        {
            var compareResult = _cardsComparer.Compare(resultBoard[_playerOne], resultBoard[_playerTwo]);
            _uIInterface.WriteLine("");
            if (resultBoard[_playerOne] == resultBoard[_playerTwo]
                || compareResult == 0)
            {
                _uIInterface.WriteLine($"No player wins, round {_roundNumber} is restarting...");
                Start();
            }

            if (compareResult == 1)
            {
                _playerTwo.WiningRounds += 1;
                _uIInterface.WriteLine($"{_playerTwo.Name} wins the round {_roundNumber}");
            }

            if (compareResult == -1)
            {
                _playerOne.WiningRounds += 1;
                _uIInterface.WriteLine($"{_playerOne.Name} wins the round {_roundNumber}");
            }
        }
    }
}