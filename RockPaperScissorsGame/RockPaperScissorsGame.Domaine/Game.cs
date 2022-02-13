using RockPaperScissorsGame.Domaine.GameAction;
using RockPaperScissorsGame.Domaine.Players;

namespace RockPaperScissorsGame.Domaine
{
    public class Game : IGame
    {
        private readonly IUIInterface _uIInterface;
        private readonly int _numberOfRoundsToWin;
        private readonly IActionOptionComparer _actionOptionComparer;

        internal IPlayer PlayerOne { get; private set; }

        internal IPlayer PlayerTwo { get; private set; }

        public Game(IUIInterface uIInterface, int numberOfRoundsToWin)
        {
            _actionOptionComparer = new ActionOptionComparer();
            _uIInterface = uIInterface;
            _numberOfRoundsToWin = numberOfRoundsToWin;
        }

        public void Start()
        {
            _uIInterface.WriteLine("Do you want to play ? [Y]es to play, or any another key to leave");
            var line = _uIInterface.ReadLine();
            if (!string.IsNullOrEmpty(line) && line.ToUpper() == "Y")
            {
                New();
            }
        }

        private void New()
        {
            _uIInterface.WriteLine("Game is begging");
            Process();
            Start();
        }

        private void Process()
        {
            PlayerOne = new Human(_uIInterface) { Name = "Player One" };
            PlayerTwo = SetPlayerTwo();
            var roundNumber = 1;
            ProcessRound(roundNumber);
            while (WiningPlayer == null)
            {
                roundNumber += 1;
                ProcessRound(roundNumber);
            }
            _uIInterface.WriteLine($"{WiningPlayer.Name} wins the game with {WiningPlayer.WiningRounds} wins");
        }

        private IPlayer SetPlayerTwo()
        {
            _uIInterface.WriteLine("Do you want to play against [B]ot or [H]uman ?");
            var line = _uIInterface.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                if (line.ToUpper() == "B")
                {
                    return SetBotType();
                }
                if (line.ToUpper() == "H")
                {
                    return new Human(_uIInterface) { Name = "Player Two" };
                }
            }
            _uIInterface.WriteLine($"Not a valid option");
            return SetPlayerTwo();
        }

        private IPlayer SetBotType()
        {
            _uIInterface.WriteLine("What kind of Bot [O]ld version or [N]ew version ?");
            var line = _uIInterface.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                if (line.ToUpper() == "O")
                {
                    return new Bot(_uIInterface) { Name = "Player Two" };
                }
                if (line.ToUpper() == "N")
                {
                    return new NewBot(_uIInterface) { Name = "Player Two" };
                }
            }
            _uIInterface.WriteLine($"Not a valid option");
            return SetBotType();
        }

        private void ProcessRound(int roundNumber)
        {
            var round = new Round(_uIInterface, PlayerOne, PlayerTwo, _actionOptionComparer, roundNumber);
            round.Start();
            _uIInterface.WriteLine($"{PlayerOne.Name}, {PlayerOne.WiningRounds} wins - {PlayerTwo.Name}, {PlayerTwo.WiningRounds} wins");
        }

        private IPlayer? WiningPlayer
        {
            get
            {
                if (PlayerOne.WiningRounds >= _numberOfRoundsToWin) return PlayerOne;
                if (PlayerTwo.WiningRounds >= _numberOfRoundsToWin) return PlayerTwo;
                return null;
            }
        }
    }
}