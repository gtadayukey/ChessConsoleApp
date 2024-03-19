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

        private bool CanMove(Position position)
        {
            if (Board.ValidPosition(position))
            {
                Piece piece = Board.Piece(position);
                return piece == null;
            }

            return false;
        }

        private bool CanEat(Position position)
        {
            if (Board.ValidPosition(position) && Board.ExistPiece(position))
            {
                Piece piece = Board.Piece(position);
                return piece.Color != Color;
            }
           
            return false;
        }

        public override bool[,] PossibleMovement()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];
            Position position = new(0, 0);

            int[] positionsToValidate;

            if (Color == ChessColor.Black)
            {
                positionsToValidate = new int[] { 1, 2 };
            }
            else
            {
                positionsToValidate = new int[] { -1, -2 };
            }

            position.SetValues(Position.Row + positionsToValidate[0], Position.Column);

            if(CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            if (MovementAmount == 0)
            {
                position.SetValues(Position.Row + positionsToValidate[1], Position.Column);
                if (CanMove(position))
                {
                    matrix[position.Row, position.Column] = true;
                }
            }

            for(int i = -1; i < 2; i += 2)
            {
                position.SetValues(Position.Row + positionsToValidate[0], Position.Column + i);

                if (CanEat(position))
                {
                    matrix[position.Row, position.Column] = true;
                }
            }

            return matrix;
        }
    }
}
