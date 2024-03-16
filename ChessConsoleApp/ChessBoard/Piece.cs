using ChessBoard.Enums;
using System.Drawing;

namespace ChessBoard
{
    internal abstract class Piece
    {
        public Position? Position { get; set; }
        public ChessColor Color { get; protected set; }
        public int MovementAmount { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Board board, ChessColor color)
        {
            Position = null;
            Color = color;
            Board = board;
            MovementAmount = 0;
        }

        public void AddMovementAmount()
        {
            MovementAmount++;
        }

        public abstract bool[,] PossibleMovement();
    }
}
