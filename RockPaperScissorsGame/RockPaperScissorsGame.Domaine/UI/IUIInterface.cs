using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame
{
    public interface IUIInterface
    {
        void WriteLine(string s);
        string? ReadLine();
        void MakeASeparation();
    }
}
