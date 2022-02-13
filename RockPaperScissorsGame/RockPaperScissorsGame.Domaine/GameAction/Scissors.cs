using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame.Domaine.GameAction
{
    internal class Scissors : IActionOption
    {
        public List<Type> Beats
        {
            get
            {
                return new List<Type>() { typeof(Paper), typeof(FlameThrower) };
            }
        }

        public string Name
        {
            get { return "Scissors"; }
        }
    }
}