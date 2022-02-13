using Moq;
using Xunit;

namespace RockPaperScissorsGame.Domaine.Tests
{
    public class GameTest
    {
        private Mock<IUIInterface> _mockUIInterface;
        public GameTest()
        {
            _mockUIInterface = new Mock<IUIInterface>();
        }

        //[Fact]
        //public void NewGame_Start_DisplayStartMessage()
        //{
        //    _mockUIInterface.SetupSequence(f => f.ReadLine()).Returns("Y").Returns("H");
        //    var cut = new Game(_mockUIInterface.Object, 1);

        //    cut.Start();

        //    _mockUIInterface.Verify(f => f.WriteLine("Game is begging"), Times.Once);
        //}

        //[Fact]
        //public void NewGame_Start_ListOfPlayersIsCreated()
        //{
        //    var cut = new Game(_mockUIInterface.Object, 1);

        //    cut.Start();

        //    Assert.NotNull(cut.PlayerOne);
        //    Assert.NotNull(cut.PlayerTwo);
        //}

        //[Fact]
        //public void NewGame_Start_RoundOneStart()
        //{
        //    var cut = new Game(_mockUIInterface.Object, Consts.NUMBER_OF_ROUNDS_TO_WIN);
        //    var mockRound = new Mock<IRound>();
        //    cut.Rounds[0] = mockRound.Object;

        //    cut.Start();

        //    mockRound.Verify(f => f.Start(1), Times.Once);
        //}

        //[Fact]
        //public void NewGameWithOneHumanPlayer_Start_PlayerTwoMustBeABot()
        //{
        //    var cut = new Game(_mockUIInterface.Object, Consts.NUMBER_OF_ROUNDS_TO_WIN);

        //    Assert.Equal(typeof(Bot), cut.PlayerTwo.GetType());
        //}

        //[Fact]
        //public void NewGameWithTwoHumansPlayer_Start_PlayerTwoMustBeAHuman()
        //{
        //    var cut = new Game(_mockUIInterface.Object, Consts.NUMBER_OF_ROUNDS_TO_WIN);

        //    Assert.Equal(typeof(Human), cut.PlayerTwo.GetType());
        //}
    }
}
