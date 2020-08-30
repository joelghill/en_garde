using System;
using Xunit;
using EnGarde.Areas.GamePlay.Data;


namespace EnGarde.UnitTests
{
    public class GameStateUnitTests
    {
        [Fact]
        public void PrintGameState()
        {
            BoardState state = new BoardState();
            Console.WriteLine(state);
        }

        [Fact]
        public void TestBoardStateID()
        {
            BoardState state1 = new BoardState(true);
            BoardState state2 = new BoardState(false);

            Assert.NotNull(state1.BoardStateID);
            Assert.NotNull(state2.BoardStateID);

            Assert.NotEqual(state1.BoardStateID, state2.BoardStateID);

            Console.WriteLine(state2.BoardStateID);
        }
    }
}
