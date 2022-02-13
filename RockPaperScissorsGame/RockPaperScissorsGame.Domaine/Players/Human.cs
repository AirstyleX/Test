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
            uIInterface.WriteLine($"{Name}, choose an option ([R]ock, [P]aper, [S]cissors) :");
            var line = uIInterface.ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                switch (line.ToUpper())
                {
                    case "R":
                        return new Rock();
                    case "P":
                        return new Paper();
                    case "S":
                        return new Scissors();
                }
            }
            uIInterface.WriteLine($"Not a valid option");
            return Play();
        }
    }
}