using RockPaperScissorsGame.Domaine.GameAction;

namespace RockPaperScissorsGame.Domaine.Players
{
    internal class Human : Player, IPlayer
    {
        public Human(IUIInterface uIInterface) : base(uIInterface)
        {
        }

        public IActionOption Play()
        {
            var listActionOption = GetListActionOption();
            var answerAllows = listActionOption.Select(f => f.Letter).ToList();
            var displayActionOptions = string.Join(", ", listActionOption.Select(f => f.NameWithLetter));

            var answer = uIInterface.Question($"{Name}, choose an option ({displayActionOptions}) :", answerAllows);

            return listActionOption.First(f => f.Letter == answer);
        }
    }
}