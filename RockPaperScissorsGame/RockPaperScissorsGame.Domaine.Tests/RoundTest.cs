using Moq;
using RockPaperScissorsGame.Domaine.GameAction;
using RockPaperScissorsGame.Domaine.Players;
using Xunit;

namespace RockPaperScissorsGame.Domaine.Tests
{
    public class RoundTest
    {
        private Mock<IUIInterface> _mockUIInterface;

        public RoundTest()
        {
            _mockUIInterface = new Mock<IUIInterface>();
        }

        [Fact]
        public void NewRound_Start_TwoPlayersPlayed()
        {
            var mockPlayer1 = new Mock<IPlayer>();
            mockPlayer1.Setup(f => f.Play()).Returns(new Rock());
            var mockPlayer2 = new Mock<IPlayer>();
            mockPlayer2.Setup(f => f.Play()).Returns(new Paper());
            var cut = new Round(_mockUIInterface.Object, mockPlayer1.Object, mockPlayer2.Object, new ActionOptionComparer(), 1);

            cut.Start();

            mockPlayer1.Verify(f => f.Play(), Times.Once);
            mockPlayer2.Verify(f => f.Play(), Times.Once);
        }

        [Fact]
        public void PlayerOneWins_Start_PlayerOneGetTheVictory()
        {
            var mockPlayer1 = new Mock<IPlayer>();
            mockPlayer1.Setup(f => f.Play()).Returns(new Paper());
            var mockPlayer2 = new Mock<IPlayer>();
            mockPlayer2.Setup(f => f.Play()).Returns(new Rock());
            var cut = new Round(_mockUIInterface.Object, mockPlayer1.Object, mockPlayer2.Object, new ActionOptionComparer(), 1);

            cut.Start();

            mockPlayer1.VerifySet(f => f.WiningRounds = 1, Times.Once);
        }
    }
}
