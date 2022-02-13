using Moq;
using Xunit;
using RockPaperScissorsGame.Domaine.GameAction;

namespace RockPaperScissorsGame.Domaine.Tests.GameAction
{
    public class ActionOptionComparerTest
    {
        [Fact]
        public void InGame_CompareRockWithScissors_RockWins()
        {
            var rock = new RockPaperScissorsGame.Domaine.GameAction.Rock();
            var scissors = new Scissors();
            var cut = new ActionOptionComparer();

            var result = cut.Compare(rock, scissors);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void InGame_ComparePaperWithRock_PaperWins()
        {
            var rock = new Rock();
            var paper = new Paper();
            var cut = new ActionOptionComparer();

            var result = cut.Compare(paper, rock);

            Assert.Equal(-1, result);
        }

        [Fact]
        public void InGame_CompareScissorsWithPaper_ScissorsWins()
        {
            var scissors = new Scissors();
            var paper = new Paper();
            var cut = new ActionOptionComparer();

            var result = cut.Compare(scissors, paper);

            Assert.Equal(-1, result);
        }
    }
}