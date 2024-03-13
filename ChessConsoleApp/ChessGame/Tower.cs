using ChessBoard;
using ChessBoard.Enums;

namespace ChessGame
{
    internal class Tower : Piece
    {
        public Tower(Board board, PieceColor color) : base(board, color) { }

        public override string ToString()
        {
            return "T";
        }
    }
}
