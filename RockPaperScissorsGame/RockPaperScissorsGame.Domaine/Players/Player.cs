using RockPaperScissorsGame.Domaine.GameAction;
using System.Reflection;

namespace RockPaperScissorsGame.Domaine.Players
{
    internal abstract class Player
    {
        internal readonly IUIInterface uIInterface;

        protected Player(IUIInterface uIInterface)
        {
            this.uIInterface = uIInterface;
        }

        public string? Name { get; set; }

        public int WiningRounds { get; set; }

        internal IActionOption RandomAction()
        {
            var random = new Random();
            var list = GetListActionOption();
            return list[random.Next(list.Count)];
        }

        private IActionOption GetActionOptionFromType(Type T)
        {
            return (IActionOption)Activator.CreateInstance(T);
        }

        internal List<IActionOption> GetListActionOption()
        {
            var returnList = new List<IActionOption>();
            foreach (var iActionClassesType in Assembly.GetExecutingAssembly().GetTypes().Where(f => f.GetInterfaces().Contains(typeof(IActionOption))))
            {
                returnList.Add(GetActionOptionFromType(iActionClassesType));
            }
            return returnList;
        }
    }
}