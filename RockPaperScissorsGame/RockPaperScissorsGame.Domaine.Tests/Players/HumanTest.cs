using Moq;
using RockPaperScissorsGame.Domaine.GameAction;
using RockPaperScissorsGame.Domaine.Players;
using System.Collections.Generic;
using Xunit;

namespace RockPaperScissorsGame.Domaine.Tests
{
    public class HumanTest
    {
        private Mock<IUIInterface> _mockUIInterface;
        public HumanTest()
        {
            _mockUIInterface = new Mock<IUIInterface>();
        }

        [Fact]
        public void HumanTurnToPlay_PlayAR_ReturnARock()
        {
            _mockUIInterface.Setup(f => f.Question(It.IsAny<string>(), It.IsAny<List<string>>())).Returns("R");
            var cut = new Human(_mockUIInterface.Object);

            var result = cut.Play();

            Assert.Equal(typeof(Rock), result.GetType());
        }

        [Fact]
        public void HumanTurnToPlay_PlayAS_ReturnAScissorsk()
        {
            _mockUIInterface.Setup(f => f.Question(It.IsAny<string>(), It.IsAny<List<string>>())).Returns("S");
            var cut = new Human(_mockUIInterface.Object);

            var result = cut.Play();

            Assert.Equal(typeof(Scissors), result.GetType());
        }

        [Fact]
        public void HumanTurnToPlay_PlayAP_ReturnAPaper()
        {
            _mockUIInterface.Setup(f => f.Question(It.IsAny<string>(), It.IsAny<List<string>>())).Returns("P");
            var cut = new Human(_mockUIInterface.Object);

            var result = cut.Play();

            Assert.Equal(typeof(Paper), result.GetType());
        }
    }
}
