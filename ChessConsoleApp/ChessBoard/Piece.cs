using ChessBoard.Enums;
using System.Drawing;

namespace ChessBoard
{
    internal class Piece
    {
        public Position? Position { get; set; }
        public PieceColor Color { get; protected set; }
        public int MovementsQuantity { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, PieceColor color)
        {
            Position = null;
            Color = color;
            Board = board;
            MovementsQuantity = 0;
        }
    }
}
