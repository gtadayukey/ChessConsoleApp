using ChessBoard;

namespace ChessGame
{
    internal class Pawn : Piece
    {

        private ChessMatch Match;

        public Pawn(Board board, ChessColor color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }

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

        public override bool[,] PossibleMovements()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];
            Position position = new(0, 0);

            int[] positionsToValidate;

            if (Color == ChessColor.Black)
            {
                positionsToValidate = new int[] { 1, 2, 4, 1 };
            }
            else
            {
                positionsToValidate = new int[] { -1, -2, 3, -1 };
            }

            if (Position.Row == positionsToValidate[2])
            {
                Position left = new(Position.Row, Position.Column - 1);
                if (Board.ValidPosition(left) && CanEat(left) && Match.VulnerableEnPassant == Board.Piece(left))
                {
                    matrix[left.Row + positionsToValidate[3], left.Column] = true;
                }
                Position right = new(Position.Row, Position.Column + 1);
                if (Board.ValidPosition(right) && CanEat(right) && Match.VulnerableEnPassant == Board.Piece(right))
                {
                    matrix[right.Row + positionsToValidate[3], right.Column] = true;
                }
            }

            position.SetValues(Position.Row + positionsToValidate[0], Position.Column);

            if (CanMove(position))
            {
                matrix[position.Row, position.Column] = true;

                if (MovementAmount == 0)
                {
                    position.SetValues(Position.Row + positionsToValidate[1], Position.Column);
                    if (CanMove(position))
                    {
                        matrix[position.Row, position.Column] = true;
                    }
                }
            }

            position.SetValues(Position.Row + positionsToValidate[0], Position.Column + 1);

            if (CanEat(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            position.SetValues(Position.Row + positionsToValidate[0], Position.Column - 1);

            if (CanEat(position))
            {
                matrix[position.Row, position.Column] = true;
            }

            return matrix;
        }
    }
}
