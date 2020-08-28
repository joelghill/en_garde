using System;
using System.Reflection;
using System.Text;
using EnGarde.Areas.Identity.Data;

namespace EnGarde.Areas.GamePlay.Data
{
    /// <summary>
    /// An class representing a state of play for a chess game
    /// </summary>
    public class GameState 
    {
        /// <summary>
        /// The unique identifier of this game state
        /// </summary>
        public int GameStateID { get; set; }

        /// <summary>
        /// Gets and sets the game this state can be found in
        /// </summary>
        public Game ParentGame { get; set; }

        /// <summary>
        /// Gets or sets the colour to play next
        /// </summary>
        public ChessColour CurrentTurn { get; set; }

        /// <summary>
        /// Gets or sets the Date and time of game state creation
        /// </summary>
        public DateTime Created { get; set; }

        #region Piece Fields
        
        #region "A" file

        public PieceType A1 { get; set; }
        public PieceType A2 { get; set; }
        public PieceType A3 { get; set; }
        public PieceType A4 { get; set; }
        public PieceType A5 { get; set; }
        public PieceType A6 { get; set; }
        public PieceType A7 { get; set; }
        public PieceType A8 { get; set; }

        #endregion

        #region "B" file

        public PieceType B1 { get; set; }
        public PieceType B2 { get; set; }
        public PieceType B3 { get; set; }
        public PieceType B4 { get; set; }
        public PieceType B5 { get; set; }
        public PieceType B6 { get; set; }
        public PieceType B7 { get; set; }
        public PieceType B8 { get; set; }

        #endregion

        #region "C" file

        public PieceType C1 { get; set; }
        public PieceType C2 { get; set; }
        public PieceType C3 { get; set; }
        public PieceType C4 { get; set; }
        public PieceType C5 { get; set; }
        public PieceType C6 { get; set; }
        public PieceType C7 { get; set; }
        public PieceType C8 { get; set; }

        #endregion

        #region "D" file

        public PieceType D1 { get; set; }
        public PieceType D2 { get; set; }
        public PieceType D3 { get; set; }
        public PieceType D4 { get; set; }
        public PieceType D5 { get; set; }
        public PieceType D6 { get; set; }
        public PieceType D7 { get; set; }
        public PieceType D8 { get; set; }

        #endregion

        #region "E" file

        public PieceType E1 { get; set; }
        public PieceType E2 { get; set; }
        public PieceType E3 { get; set; }
        public PieceType E4 { get; set; }
        public PieceType E5 { get; set; }
        public PieceType E6 { get; set; }
        public PieceType E7 { get; set; }
        public PieceType E8 { get; set; }

        #endregion

        #region "F" file

        public PieceType F1 { get; set; }
        public PieceType F2 { get; set; }
        public PieceType F3 { get; set; }
        public PieceType F4 { get; set; }
        public PieceType F5 { get; set; }
        public PieceType F6 { get; set; }
        public PieceType F7 { get; set; }
        public PieceType F8 { get; set; }

        #endregion

        #region "G" file

        public PieceType G1 { get; set; }
        public PieceType G2 { get; set; }
        public PieceType G3 { get; set; }
        public PieceType G4 { get; set; }
        public PieceType G5 { get; set; }
        public PieceType G6 { get; set; }
        public PieceType G7 { get; set; }
        public PieceType G8 { get; set; }

        #endregion

        #region "H" file

        public PieceType H1 { get; set; }
        public PieceType H2 { get; set; }
        public PieceType H3 { get; set; }
        public PieceType H4 { get; set; }
        public PieceType H5 { get; set; }
        public PieceType H6 { get; set; }
        public PieceType H7 { get; set; }
        public PieceType H8 { get; set; }

        #endregion

        #endregion

        /// <summary>
        /// String representation of the board State
        /// </summary>
        /// <returns>String represtation of the game board</returns>
        public override string ToString() 
        {
            StringBuilder boardOutputBuilder = new StringBuilder();
            string black = "|\\\\";
            string white = "|  ";
            string currentSquare = white;

            string[] coloumns = new string[8] {"A", "B", "C", "D", "E", "F", "G", "H" };
            Type boardStateType = typeof(GameState);

            for (int row = 8; row >= 1; row--) {
                for (int column_index = 0; column_index <= 7; column_index++) {
                    string column = coloumns[column_index];
                    PropertyInfo squareProperty = boardStateType.GetProperty(string.Format("{0}{1}", column, row));
                    PieceType piece = (PieceType)squareProperty.GetValue(this);
                    
                    // Print either a square or the the current piece
                    if (piece == PieceType.EMPTY)
                    {
                        boardOutputBuilder.Append(currentSquare);
                    } else {
                        boardOutputBuilder.AppendFormat("|{0} ", (char)piece);
                    }

                    if (currentSquare == white) {
                        currentSquare = black;
                    } else {
                        currentSquare = white;
                    }
                }

                boardOutputBuilder.AppendLine("|");

                if (currentSquare == white) {
                    currentSquare = black;
                } else {
                    currentSquare = white;
                }
            }

            return boardOutputBuilder.ToString();
        } 
    }
}