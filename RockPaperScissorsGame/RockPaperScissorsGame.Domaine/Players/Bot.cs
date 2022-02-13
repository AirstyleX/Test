using RockPaperScissorsGame.Domaine.GameAction;

namespace RockPaperScissorsGame.Domaine.Players
{
    internal class Bot : Player, IPlayer
    {
        private IActionOption? _lastActionOption;
        public Bot(IUIInterface uIInterface) : base(uIInterface)
        {
        }

        public IActionOption Play()
        {
            if (_lastActionOption == null)
            {
                _lastActionOption = RandomAction();
            }
            else
            {
                var list = GetListActionOption();
                _lastActionOption = list.First(f => f.Beats.Contains(_lastActionOption.GetType()));
            }
            return _lastActionOption;
        }
    }
}