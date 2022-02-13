using RockPaperScissorsGame.Domaine.GameAction;

namespace RockPaperScissorsGame.Domaine.Players
{
    public interface IPlayer
    {
        string? Name { get; }

        int WiningRounds { get; set; }

        IActionOption Play();
    }
}