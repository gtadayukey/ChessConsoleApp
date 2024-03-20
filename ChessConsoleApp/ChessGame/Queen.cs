using ChessBoard;
using ChessBoard.Enums;

namespace ChessGame
{
    internal class Queen : Piece
    {
        public Queen(Board board, ChessColor color) : base(board, color) { }

        public override string ToString()
        {
            return "Q";
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
                                           { -1, 0 },
                                           { 1, 0 },
                                           { 0, -1 },
                                           { 0, 1 },
                                           { 1, 1 },
                                           { 1, -1 },
                                           { -1, -1 },
                                           { -1, 1 }
            };

            for (int i = 0; i < positionsToValidate.GetLength(0); i++)
            {
                position.SetValues(Position.Row + positionsToValidate[i, 0], Position.Column + positionsToValidate[i, 1]);

                while (CanMove(position))
                {
                    matrix[position.Row, position.Column] = true;
                    if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                    {
                        break;
                    }

                    position.Row += positionsToValidate[i, 0];
                    position.Column += positionsToValidate[i, 1];
                }
            }

            return matrix;
        }
    }
}
