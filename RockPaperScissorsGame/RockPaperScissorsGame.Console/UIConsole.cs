using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame.Console
{
    internal class UIConsole : IUIInterface
    {
        public string? ReadLine()
        {
            return System.Console.ReadLine();
        }

        public void WriteLine(string s)
        {
            System.Console.WriteLine(s);
        }

        public void MakeASeparation()
        {
            System.Console.WriteLine("---------------------------------------------------------------------------");
        }
    }
}
