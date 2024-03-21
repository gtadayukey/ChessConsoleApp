using ChessBoard;
using ChessBoard.Enums;
using ChessConsoleApp.ChessGame;

namespace ChessGame
{
    internal class King : Piece
    {
        private ChessMatch Match;

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

        private bool TestTowerRook(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece is Tower && MovementAmount == 0;
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
                // Normal Rook
                Position towerPosition1 = new(Position.Row, Position.Column - 4);
                if (TestTowerRook(towerPosition1))
                {
                    Position p1 = new(Position.Row, Position.Column - 1);
                    Position p2 = new(Position.Row, Position.Column - 2);
                    Position p3 = new(Position.Row, Position.Column - 3);

                    if (Board.Piece(p1) == null && Board.Piece(p2) == null && Board.Piece(p3) == null)
                    {
                        matrix[Position.Row, Position.Column - 2] = true;
                    }
                }

                // Short Rook
                Position towerPosition2 = new(Position.Row, Position.Column + 3);
                if (TestTowerRook(towerPosition2))
                {
                    Position p1 = new(Position.Row, Position.Column + 1);
                    Position p2 = new(Position.Row, Position.Column + 2);

                    if (Board.Piece(p1) == null && Board.Piece(p2) == null)
                    {
                        matrix[Position.Row, Position.Column + 2] = true;
                    }
                }
            }


            return matrix;
        }
    }
}
