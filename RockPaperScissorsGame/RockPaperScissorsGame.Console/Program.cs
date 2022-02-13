// See https://aka.ms/new-console-template for more information
using RockPaperScissorsGame;
using RockPaperScissorsGame.Console;
using RockPaperScissorsGame.Domaine;

Console.WriteLine("Welcome to Rock, Paper, Scissors Game");

IUIInterface uIInterface = new UIConsole();

IGame game = new Game(uIInterface, Consts.NUMBER_OF_ROUNDS_TO_WIN);
game.Start();

Console.WriteLine("Have a good day...");