using ChessBoard;
using ChessBoard.Enums;

namespace ChessGame
{
    internal class Horse : Piece
    {
        public Horse(Board board, ChessColor color) : base(board, color) { }

        public override string ToString()
        {
            return "H";
        }

        private bool CanMove(Position position)
        {
            if (Board.ValidPosition(position))
            {
                Piece piece = Board.Piece(position);
                return piece == null || piece.Color != Color;
            }

            return false;
        }

        public override bool[,] PossibleMovement()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];
            Position position = new(0, 0);

            int[,] positionsToValidate = {
                                           { -2, 1 },
                                           { -2, -1 },
                                           { 2, 1 },
                                           { 2, -1 },
                                           { 1, -2 },
                                           { -1, -2 },
                                           { 1, 2 },
                                           { -1, 2 }
            };

            for (int i = 0; i < positionsToValidate.GetLength(0); i++)
            {
                int rowPoint = positionsToValidate[i, 0];
                int collumnPoint = positionsToValidate[i, 1];
                position.SetValues(Position.Row + rowPoint, Position.Column + collumnPoint);

                if (CanMove(position))
                {
                    matrix[position.Row, position.Column] = true;
                }
            }

            return matrix;
        }
    }
}
