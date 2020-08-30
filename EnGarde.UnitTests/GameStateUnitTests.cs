using System;
using System.Collections.Generic;
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

        [Fact]
        public void TestParameterizedConstructor()
        {
            Dictionary<string, PieceType> pieces = new Dictionary<string, PieceType>();
            pieces["A1"] = PieceType.BLACK_KNIGHT;

            BoardState state1 = new BoardState(ChessColour.White, pieces);

            Assert.NotNull(state1.BoardStateID);
            Console.WriteLine(state1);
            Console.WriteLine(state1.BoardStateID);
        }

        [Fact]
        public void TestParameterizedConstructorInvalidParameter()
        {
            Dictionary<string, PieceType> pieces = new Dictionary<string, PieceType>();
            pieces["a9"] = PieceType.BLACK_KNIGHT;
            Assert.Throws<ArgumentException>(() => new BoardState(ChessColour.White, pieces));
        }
    }
}
