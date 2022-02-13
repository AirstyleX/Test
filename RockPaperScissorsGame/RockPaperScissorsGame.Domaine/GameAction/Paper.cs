using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame.Domaine.GameAction
{
    internal class Paper : IActionOption
    {
        public List<Type> Beats
        {
            get
            {
                return new List<Type>() { typeof(Rock) };
            }
        }

        public string Name
        {
            get { return "Paper"; }
        }

        public string Letter
        {
            get { return "P"; }
        }

        public string NameWithLetter
        {
            get { return "[P]aper"; }
        }
    }
}
