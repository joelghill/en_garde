namespace EnGarde.Areas.GamePlay.Data
{
    /// <summary>
    /// Defines an enumeration for chess piece types using UTF8 chess characters
    /// </summary>
    public enum PieceType 
    {
        EMPTY,
        WHITE_PAWN = '♙',
        BLACK_PAWN = '♟',
        WHITE_BISHOP = '♗',
        BLACK_BISHOP = '♝',
        WHITE_KNIGHT = '♘',
        BLACK_KNIGHT = '♞',
        WHITE_ROOK = '♖',
        BLACK_ROOK = '♜',
        WHITE_QUEEN = '♕',
        BLACK_QUEEN = '♛',
        WHITE_KING = '♔',
        BLACK_KING = '♚',
    }
}