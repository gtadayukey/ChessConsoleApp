using ChessBoard;

namespace ChessGame
{
    internal class King : Piece
    {
        private readonly ChessMatch Match;

        public King(Board board, ChessColor color, ChessMatch match) : base(board, color)
        {
            Match = match;
        }

        public override string ToString()
        {
            return "K";
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

        private bool TestHookCastling(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece is Hook && MovementAmount == 0;
        }

        public override bool[,] PossibleMovements()
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
                                           { 1, -1 }
            };

            for (int i = 0; i < positionsToValidate.GetLength(0); i++)
            {
                position.SetValues(Position.Row + positionsToValidate[i, 0], Position.Column + positionsToValidate[i, 1]);

                if (CanMove(position))
                {
                    matrix[position.Row, position.Column] = true;
                }
            }

            if (MovementAmount == 0 && !Match.Check)
            {
                // Long Castling
                Position hookPosition1 = new(Position.Row, Position.Column - 4);
                if (TestHookCastling(hookPosition1))
                {
                    Position p1 = new(Position.Row, Position.Column - 1);
                    Position p2 = new(Position.Row, Position.Column - 2);
                    Position p3 = new(Position.Row, Position.Column - 3);

                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null && !Match.IsThreatenedPosition(p1, Color))
                    {
                        matrix[Position.Row, Position.Column - 2] = true;
                    }
                }

                // Short Castling
                Position hookPosition2 = new(Position.Row, Position.Column + 3);
                if (TestHookCastling(hookPosition2))
                {
                    Position p1 = new(Position.Row, Position.Column + 1);
                    Position p2 = new(Position.Row, Position.Column + 2);

                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && !Match.IsThreatenedPosition(p1, Color))
                    {
                        matrix[Position.Row, Position.Column + 2] = true;
                    }
                }
            }


            return matrix;
        }
    }
}
