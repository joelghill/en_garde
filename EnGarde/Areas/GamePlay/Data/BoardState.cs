using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;
using EnGarde.Areas.Identity.Data;

namespace EnGarde.Areas.GamePlay.Data
{
    /// <summary>
    /// An class representing a state of play for a chess game
    /// </summary>
    public class BoardState 
    {
        /// <summary>
        /// Creates and instantiates a new instance of the BoardState class
        /// </summary>
        /// <param name="blank">A value indicating whether or not the board should be "blank"</param>
        public BoardState(bool blank=false) {
            if (blank == false) {
                this.CurrentTurn = ChessColour.White;
                this.InitializeBoard();
            }
            this.BoardStateID = this.GenerateID();
        }

        /// <summary>
        /// Creates and initializes a new board state
        /// </summary>
        /// <param name="turn">The current turn</param>
        /// <param name="pieces">Dictionary of the current pieces on the board.</param>
        public BoardState(ChessColour turn, Dictionary<string, PieceType> pieces) {
            this.CurrentTurn = turn;
            Type boardStateType = this.GetType();
            foreach (KeyValuePair<string, PieceType> entry in pieces) {
                PropertyInfo pieceInfo = boardStateType.GetProperty(entry.Key);
                if (pieceInfo == null) {
                    throw new ArgumentException(
                        string.Format("Board state does not have a property with the name \"{0}\"", entry.Key));
                }
                else {
                    pieceInfo.SetValue(this, entry.Value);
                }
            }

            this.BoardStateID = this.GenerateID();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BoardStateID { get; private set; }

        /// <summary>
        /// Gets or sets the colour to play next
        /// </summary>
        public ChessColour CurrentTurn { get; private set; }

        #region Piece Fields
        
        #region "A" file

        public PieceType A1 { get; private set; }
        public PieceType A2 { get; private set; }
        public PieceType A3 { get; private set; }
        public PieceType A4 { get; private set; }
        public PieceType A5 { get; private set; }
        public PieceType A6 { get; private set; }
        public PieceType A7 { get; private set; }
        public PieceType A8 { get; private set; }

        #endregion

        #region "B" file

        public PieceType B1 { get; private set; }
        public PieceType B2 { get; private set; }
        public PieceType B3 { get; private set; }
        public PieceType B4 { get; private set; }
        public PieceType B5 { get; private set; }
        public PieceType B6 { get; private set; }
        public PieceType B7 { get; private set; }
        public PieceType B8 { get; private set; }

        #endregion

        #region "C" file

        public PieceType C1 { get; private set; }
        public PieceType C2 { get; private set; }
        public PieceType C3 { get; private set; }
        public PieceType C4 { get; private set; }
        public PieceType C5 { get; private set; }
        public PieceType C6 { get; private set; }
        public PieceType C7 { get; private set; }
        public PieceType C8 { get; private set; }

        #endregion

        #region "D" file

        public PieceType D1 { get; private set; }
        public PieceType D2 { get; private set; }
        public PieceType D3 { get; private set; }
        public PieceType D4 { get; private set; }
        public PieceType D5 { get; private set; }
        public PieceType D6 { get; private set; }
        public PieceType D7 { get; private set; }
        public PieceType D8 { get; private set; }

        #endregion

        #region "E" file

        public PieceType E1 { get; private set; }
        public PieceType E2 { get; private set; }
        public PieceType E3 { get; private set; }
        public PieceType E4 { get; private set; }
        public PieceType E5 { get; private set; }
        public PieceType E6 { get; private set; }
        public PieceType E7 { get; private set; }
        public PieceType E8 { get; private set; }

        #endregion

        #region "F" file

        public PieceType F1 { get; private set; }
        public PieceType F2 { get; private set; }
        public PieceType F3 { get; private set; }
        public PieceType F4 { get; private set; }
        public PieceType F5 { get; private set; }
        public PieceType F6 { get; private set; }
        public PieceType F7 { get; private set; }
        public PieceType F8 { get; private set; }

        #endregion

        #region "G" file

        public PieceType G1 { get; private set; }
        public PieceType G2 { get; private set; }
        public PieceType G3 { get; private set; }
        public PieceType G4 { get; private set; }
        public PieceType G5 { get; private set; }
        public PieceType G6 { get; private set; }
        public PieceType G7 { get; private set; }
        public PieceType G8 { get; private set; }

        #endregion

        #region "H" file

        public PieceType H1 { get; private set; }
        public PieceType H2 { get; private set; }
        public PieceType H3 { get; private set; }
        public PieceType H4 { get; private set; }
        public PieceType H5 { get; private set; }
        public PieceType H6 { get; private set; }
        public PieceType H7 { get; private set; }
        public PieceType H8 { get; private set; }

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
            Type boardStateType = typeof(BoardState);

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

        /// <summary>
        /// Method to determine whether or not two board states are the same
        /// </summary>
        /// <param name="other">The other object</param>
        /// <returns>True if the board states are identical, False otherwise</returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as BoardState);
        }

        /// <summary>
        /// Method to determine whether or not two board states are the same
        /// </summary>
        /// <param name="other">The other object</param>
        /// <returns>True if the board states are identical, False otherwise</returns>
        public bool Equals(BoardState other)
        {
            // If parameter is null, return false.
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            // Optimization for a common success case.
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            // If run-time types are not exactly the same, return false.
            if (this.GetType() != other.GetType())
            {
                return false;
            }

            // Return true if the fields match.
            // Note that the base class is not invoked because it is
            // System.Object, which defines Equals as reference equality.

            return this.CurrentTurn.Equals(other.CurrentTurn) &&
                    this.A1 == other.A1 &&
                    this.B1 == other.B1 &&
                    this.C1 == other.C1 &&
                    this.D1 == other.D1 &&
                    this.E1 == other.E1 &&
                    this.F1 == other.F1 &&
                    this.G1 == other.G1 &&
                    this.H1 == other.H1 &&

                    this.A2 == other.A2 &&
                    this.B2 == other.B2 &&
                    this.C2 == other.C2 &&
                    this.D2 == other.D2 &&
                    this.E2 == other.E2 &&
                    this.F2 == other.F2 &&
                    this.G2 == other.G2 &&
                    this.H2 == other.H2 &&

                    this.A3 == other.A3 &&
                    this.B3 == other.B3 &&
                    this.C3 == other.C3 &&
                    this.D3 == other.D3 &&
                    this.E3 == other.E3 &&
                    this.F3 == other.F3 &&
                    this.G3 == other.G3 &&
                    this.H3 == other.H3 &&                    
                    
                    this.A4 == other.A4 &&
                    this.B4 == other.B4 &&
                    this.C4 == other.C4 &&
                    this.D4 == other.D4 &&
                    this.E4 == other.E4 &&
                    this.F4 == other.F4 &&
                    this.G4 == other.G4 &&
                    this.H4 == other.H4 &&

                    this.A5 == other.A5 &&
                    this.B5 == other.B5 &&
                    this.C5 == other.C5 &&
                    this.D5 == other.D5 &&
                    this.E5 == other.E5 &&
                    this.F5 == other.F5 &&
                    this.G5 == other.G5 &&
                    this.H5 == other.H5 &&


                    this.A6 == other.A6 &&
                    this.B6 == other.B6 &&
                    this.C6 == other.C6 &&
                    this.D6 == other.D6 &&
                    this.E6 == other.E6 &&
                    this.F6 == other.F6 &&
                    this.G6 == other.G6 &&
                    this.H6 == other.H6 &&

                    this.A7 == other.A7 &&
                    this.B7 == other.B7 &&
                    this.C7 == other.C7 &&
                    this.D7 == other.D7 &&
                    this.E7 == other.E7 &&
                    this.F7 == other.F7 &&
                    this.G7 == other.G7 &&
                    this.H7 == other.H7 &&

                    this.A8 == other.A8 &&
                    this.B8 == other.B8 &&
                    this.C8 == other.C8 &&
                    this.D8 == other.D8 &&
                    this.E8 == other.E8 &&
                    this.F8 == other.F8 &&
                    this.G8 == other.G8 &&
                    this.H8 == other.H8;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                hash = hash * this.CurrentTurn.GetHashCode();
                
                hash = hash * 23 + this.A1.GetHashCode();
                hash = hash * 23 + this.B1.GetHashCode();
                hash = hash * 23 + this.C1.GetHashCode();
                hash = hash * 23 + this.D1.GetHashCode();
                hash = hash * 23 + this.E1.GetHashCode();
                hash = hash * 23 + this.F1.GetHashCode();
                hash = hash * 23 + this.G1.GetHashCode();
                hash = hash * 23 + this.H1.GetHashCode();
                
                hash = hash * 23 + this.A2.GetHashCode();
                hash = hash * 23 + this.B2.GetHashCode();
                hash = hash * 23 + this.C2.GetHashCode();
                hash = hash * 23 + this.D2.GetHashCode();
                hash = hash * 23 + this.E2.GetHashCode();
                hash = hash * 23 + this.F2.GetHashCode();
                hash = hash * 23 + this.G2.GetHashCode();
                hash = hash * 23 + this.H2.GetHashCode();                    
                
                hash = hash * 23 + this.A3.GetHashCode();
                hash = hash * 23 + this.B3.GetHashCode();
                hash = hash * 23 + this.C3.GetHashCode();
                hash = hash * 23 + this.D3.GetHashCode();
                hash = hash * 23 + this.E3.GetHashCode();
                hash = hash * 23 + this.F3.GetHashCode();
                hash = hash * 23 + this.G3.GetHashCode();
                hash = hash * 23 + this.H3.GetHashCode();                    
                
                hash = hash * 23 + this.A4.GetHashCode();
                hash = hash * 23 + this.B4.GetHashCode();
                hash = hash * 23 + this.C4.GetHashCode();
                hash = hash * 23 + this.D4.GetHashCode();
                hash = hash * 23 + this.E4.GetHashCode();
                hash = hash * 23 + this.F4.GetHashCode();
                hash = hash * 23 + this.G4.GetHashCode();
                hash = hash * 23 + this.H4.GetHashCode();

                hash = hash * 23 + this.A5.GetHashCode();
                hash = hash * 23 + this.B5.GetHashCode();
                hash = hash * 23 + this.C5.GetHashCode();
                hash = hash * 23 + this.D5.GetHashCode();
                hash = hash * 23 + this.E5.GetHashCode();
                hash = hash * 23 + this.F5.GetHashCode();
                hash = hash * 23 + this.G5.GetHashCode();
                hash = hash * 23 + this.H5.GetHashCode();

                hash = hash * 23 + this.A6.GetHashCode();
                hash = hash * 23 + this.B6.GetHashCode();
                hash = hash * 23 + this.C6.GetHashCode();
                hash = hash * 23 + this.D6.GetHashCode();
                hash = hash * 23 + this.E6.GetHashCode();
                hash = hash * 23 + this.F6.GetHashCode();
                hash = hash * 23 + this.G6.GetHashCode();
                hash = hash * 23 + this.H6.GetHashCode();

                hash = hash * 23 + this.A7.GetHashCode();
                hash = hash * 23 + this.B7.GetHashCode();
                hash = hash * 23 + this.C7.GetHashCode();
                hash = hash * 23 + this.D7.GetHashCode();
                hash = hash * 23 + this.E7.GetHashCode();
                hash = hash * 23 + this.F7.GetHashCode();
                hash = hash * 23 + this.G7.GetHashCode();
                hash = hash * 23 + this.H7.GetHashCode();

                hash = hash * 23 + this.A8.GetHashCode();
                hash = hash * 23 + this.B8.GetHashCode();
                hash = hash * 23 + this.C8.GetHashCode();
                hash = hash * 23 + this.D8.GetHashCode();
                hash = hash * 23 + this.E8.GetHashCode();
                hash = hash * 23 + this.F8.GetHashCode();
                hash = hash * 23 + this.G8.GetHashCode();
                hash = hash * 23 + this.H8.GetHashCode();

                return hash;
            }
        }

        /// <summary>
        /// Private helper method used to intialize a board State
        /// </summary>
        private void InitializeBoard() {
            // Set Starter Board...
            this.A1 = PieceType.WHITE_ROOK;
            this.B1 = PieceType.WHITE_KNIGHT;
            this.C1 = PieceType.WHITE_BISHOP;
            this.D1 = PieceType.WHITE_QUEEN;
            this.E1 = PieceType.WHITE_KING;
            this.F1 = PieceType.WHITE_BISHOP;
            this.G1 = PieceType.WHITE_KNIGHT;
            this.H1 = PieceType.WHITE_ROOK;

            this.A2 = PieceType.WHITE_PAWN;
            this.B2 = PieceType.WHITE_PAWN;
            this.C2 = PieceType.WHITE_PAWN;
            this.D2 = PieceType.WHITE_PAWN;
            this.E2 = PieceType.WHITE_PAWN;
            this.F2 = PieceType.WHITE_PAWN;
            this.G2 = PieceType.WHITE_PAWN;
            this.H2 = PieceType.WHITE_PAWN;

            this.A8 = PieceType.BLACK_ROOK;
            this.B8 = PieceType.BLACK_KNIGHT;
            this.C8 = PieceType.BLACK_BISHOP;
            this.D8 = PieceType.BLACK_QUEEN;
            this.E8 = PieceType.BLACK_KING;
            this.F8 = PieceType.BLACK_BISHOP;
            this.G8 = PieceType.BLACK_KNIGHT;
            this.H8 = PieceType.BLACK_ROOK;

            this.A7 = PieceType.BLACK_PAWN;
            this.B7 = PieceType.BLACK_PAWN;
            this.C7 = PieceType.BLACK_PAWN;
            this.D7 = PieceType.BLACK_PAWN;
            this.E7 = PieceType.BLACK_PAWN;
            this.F7 = PieceType.BLACK_PAWN;
            this.G7 = PieceType.BLACK_PAWN;
            this.H7 = PieceType.BLACK_PAWN;
        }

        /// <summary>
        /// Generates a unique ID based on the board state
        /// </summary>
        /// <returns>A string unique to this board state</returns>
        private string GenerateID() {
            StringBuilder idBuilder = new StringBuilder();
            idBuilder.AppendFormat("{0}", this.CurrentTurn);

            string[] coloumns = new string[8] {"A", "B", "C", "D", "E", "F", "G", "H" };
            Type boardStateType = typeof(BoardState);

            for (int row = 8; row >= 1; row--) {
                for (int column_index = 0; column_index <= 7; column_index++) {
                    string column = coloumns[column_index];
                    PropertyInfo squareProperty = boardStateType.GetProperty(string.Format("{0}{1}", column, row));
                    PieceType piece = (PieceType)squareProperty.GetValue(this);
                    
                    idBuilder.AppendFormat("-{0} ", (char)piece);
                }
            }

            return idBuilder.ToString();
        }
    }
}