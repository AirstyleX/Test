using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame.Domaine.GameAction
{
    internal class FlameThrower : IActionOption
    {
        public List<Type> Beats
        {
            get
            {
                return new List<Type>() { typeof(Paper) };
            }
        }

        public string Name
        {
            get { return "FlameThrower"; }
        }

        public string Letter
        {
            get { return "F"; }
        }

        public string NameWithLetter
        {
            get { return "[F]lameThrower"; }
        }
    }
}