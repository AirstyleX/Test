using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame.Domaine.GameAction
{
    internal class ActionOptionComparer : IActionOptionComparer
    {
        public int Compare(IActionOption? x, IActionOption? y)
        {
            if (x == null) throw new ArgumentNullException(nameof(x));
            if (y == null) throw new ArgumentNullException(nameof(y));

            if (x.Beats.Contains(y.GetType()))
            {
                return -1;
            }

            if (y.Beats.Contains(x.GetType()))
            {
                return 1;
            }

            return 0;
        }
    }
}