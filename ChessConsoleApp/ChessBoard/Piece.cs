using ChessBoard.Enums;
using System.Drawing;

namespace ChessBoard
{
    internal abstract class Piece
    {
        public Position Position { get; set; }
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
        public void RemoveMovementAmount()
        {
            MovementAmount--;
        }

        public bool HavePossibleMovement()
        {
            bool[,] matrix = PossibleMovements();
            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (matrix[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool PossibleMovement(Position position)
        {
            return PossibleMovements()[position.Row, position.Column];
        }

        public abstract bool[,] PossibleMovements();
    }
}
