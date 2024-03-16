using ChessBoard;
using ChessBoard.Enums;

namespace ChessGame
{
    internal class King : Piece
    {
        public King(Board board, ChessColor color) : base(board, color) { }

        public override string ToString()
        {
            return "K";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMovement()
        {
            bool[,] matrix = new bool[Board.Rows,Board.Columns];
            Position position = new(0, 0);

            // Top Mid
            position.SetValues(position.Row - 1, position.Column);
            if(Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            // Top Right
            position.SetValues(position.Row - 1, position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            // Top Left
            position.SetValues(position.Row - 1, position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            // Mid Right
            position.SetValues(position.Row, position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            // Mid Left
            position.SetValues(position.Row, position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            // Bottom Mid
            position.SetValues(position.Row + 1, position.Column);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            // Bottom Right
            position.SetValues(position.Row + 1, position.Column + 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            // Bottom Left
            position.SetValues(position.Row + 1, position.Column - 1);
            if (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            return matrix;

        }
    }
}
