using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame.Domaine.GameAction
{
    internal class Rock : IActionOption
    {
        public List<Type> Beats
        {
            get
            {
                return new List<Type>() { typeof(Scissors), typeof(FlameThrower) };
            }
        }
        public string Name
        {
            get { return "Rock"; }
        }

        public string Letter
        {
            get { return "R"; }
        }

        public string NameWithLetter
        {
            get { return "[R]ock"; }
        }
    }
}
