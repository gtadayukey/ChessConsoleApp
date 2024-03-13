using ChessBoard;
using ChessBoard.Enums;

namespace ChessGame
{
    internal class King : Piece
    {
        public King(Board board, PieceColor color) : base(board, color) { }

        public override string ToString()
        {
            return "K";
        }
    }
}
