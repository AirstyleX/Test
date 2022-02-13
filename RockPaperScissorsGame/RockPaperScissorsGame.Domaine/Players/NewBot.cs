using RockPaperScissorsGame.Domaine.GameAction;

namespace RockPaperScissorsGame.Domaine.Players
{
    internal class NewBot : Player, IPlayer
    {
        public NewBot(IUIInterface uIInterface) : base(uIInterface)
        {
        }

        public IActionOption Play()
        {
            return RandomAction();
        }
    }
}