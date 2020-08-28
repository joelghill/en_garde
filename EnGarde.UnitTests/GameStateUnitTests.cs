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
            GameState state = new GameState();

            // Set Starter Board...
            state.A1 = PieceType.WHITE_ROOK;
            state.B1 = PieceType.WHITE_KNIGHT;
            state.C1 = PieceType.WHITE_BISHOP;
            state.D1 = PieceType.WHITE_QUEEN;
            state.E1 = PieceType.WHITE_KING;
            state.F1 = PieceType.WHITE_BISHOP;
            state.G1 = PieceType.WHITE_KNIGHT;
            state.H1 = PieceType.WHITE_ROOK;

            state.A2 = PieceType.WHITE_PAWN;
            state.B2 = PieceType.WHITE_PAWN;
            state.C2 = PieceType.WHITE_PAWN;
            state.D2 = PieceType.WHITE_PAWN;
            state.E2 = PieceType.WHITE_PAWN;
            state.F2 = PieceType.WHITE_PAWN;
            state.G2 = PieceType.WHITE_PAWN;
            state.H2 = PieceType.WHITE_PAWN;

            state.A8 = PieceType.BLACK_ROOK;
            state.B8 = PieceType.BLACK_KNIGHT;
            state.C8 = PieceType.BLACK_BISHOP;
            state.D8 = PieceType.BLACK_QUEEN;
            state.E8 = PieceType.BLACK_KING;
            state.F8 = PieceType.BLACK_BISHOP;
            state.G8 = PieceType.BLACK_KNIGHT;
            state.H8 = PieceType.BLACK_ROOK;

            state.A7 = PieceType.BLACK_PAWN;
            state.B7 = PieceType.BLACK_PAWN;
            state.C7 = PieceType.BLACK_PAWN;
            state.D7 = PieceType.BLACK_PAWN;
            state.E7 = PieceType.BLACK_PAWN;
            state.F7 = PieceType.BLACK_PAWN;
            state.G7 = PieceType.BLACK_PAWN;
            state.H7 = PieceType.BLACK_PAWN;

            Console.WriteLine(state);
        }
    }
}
