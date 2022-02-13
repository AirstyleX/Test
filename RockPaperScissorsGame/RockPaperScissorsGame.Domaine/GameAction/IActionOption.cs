using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame.Domaine.GameAction
{
    public interface IActionOption
    {
        List<Type> Beats { get; }

        string Name { get; }
    }
}
