using ChessBoard;
using ChessBoard.Enums;

namespace ChessGame
{
    internal class Queen : Piece
    {
        public Queen(Board board, PieceColor color) : base(board, color) { }

        public override string ToString()
        {
            return "Q";
        }
    }
}
