using Moq;
using RockPaperScissorsGame.Domaine.GameAction;
using RockPaperScissorsGame.Domaine.Players;
using Xunit;

namespace RockPaperScissorsGame.Domaine.Tests
{
    public class PlayerTest
    {
        private Mock<IUIInterface> _mockUIInterface;
        public PlayerTest()
        {
            _mockUIInterface = new Mock<IUIInterface>();
        }

        [Fact]
        public void WhenPlayerNeedRandomActionOption_RandomAction_ReturnAActionOption()
        {
            var cut = new Bot(_mockUIInterface.Object);

            var result = cut.Play();

            Assert.True(typeof(IActionOption).IsAssignableFrom(result.GetType()));
        }
    }
}