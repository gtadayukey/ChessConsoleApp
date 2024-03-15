using ChessBoard;
using ChessBoard.Enums;

namespace ChessGame
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, ChessColor color) : base(board, color) { }

        public override string ToString()
        {
            return "P";
        }
    }
}
