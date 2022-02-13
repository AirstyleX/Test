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

        public string Question(string question, List<string> answersAllow)
        {
            WriteLine(question);
            var line = ReadLine();
            if (!string.IsNullOrEmpty(line))
            {
                if (answersAllow.Contains(line.ToUpper()))
                    return line.ToUpper();
            }
            WriteLine($"Not a valid option");
            return Question(question, answersAllow);
        }
    }
}
