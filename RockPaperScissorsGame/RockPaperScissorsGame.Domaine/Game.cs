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
            var answersAllow = new List<string>() { "Y", "N"};
            var answer = _uIInterface.Question("Do you want to play ? [Y]es, [N]o", answersAllow);
            if (answer == "Y")
            {
                New();
            }
        }

        private void New()
        {
            _uIInterface.WriteLine("Game is beginning");
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
            _uIInterface.WriteLine($"{WiningPlayer.Name} wins the game with {WiningPlayer.WiningRounds} victories");
        }

        private IPlayer SetPlayerTwo()
        {
            var answersAllow = new List<string>() { "B", "H" };
            var answer = _uIInterface.Question("Do you want to play against [B]ot or [H]uman ?", answersAllow);
            
            if (answer.ToUpper() == "B")
            {
                return SetBotType();
            }
            return new Human(_uIInterface) { Name = "Player Two" };
        }

        private IPlayer SetBotType()
        {
            var answersAllow = new List<string>() { "O", "N" };
            var answer = _uIInterface.Question("What kind of Bot, [O]ld version or [N]ew version ?", answersAllow);

            if (answer == "N")
            {
                return new NewBot(_uIInterface) { Name = "Player Two" };
            }
            return new Bot(_uIInterface) { Name = "Player Two" };
        }

        private void ProcessRound(int roundNumber)
        {
            var round = new Round(_uIInterface, PlayerOne, PlayerTwo, _actionOptionComparer, roundNumber);
            round.Start();
            _uIInterface.WriteLine($"{PlayerOne.Name}, {PlayerOne.WiningRounds} victories - {PlayerTwo.Name}, {PlayerTwo.WiningRounds} victories");
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