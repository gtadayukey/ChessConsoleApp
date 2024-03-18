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
            bool[,] matrix = new bool[Board.Rows, Board.Columns];
            Position position = new(0, 0);

            int[,] positionsToValidate = {
                                           { -1, 0 },
                                           { -1, 1 },
                                           { -1, -1 },
                                           { 0, 1 },
                                           { 0, -1 },
                                           { 1, 0 },
                                           { 1, 1 },
                                           { 1, -1 },
            };

            for (int i = 0; i < positionsToValidate.GetLength(0); i++)
            {
                int rowPoint = positionsToValidate[i, 0];
                int collumnPoint = positionsToValidate[i, 1];
                position.SetValues(position.Row + rowPoint, position.Column + collumnPoint);

                if (Board.ValidPosition(position) && CanMove(position))
                {
                    matrix[position.Row, position.Column] = true;
                }
            }

            return matrix;
        }
    }
}
