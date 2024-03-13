using ChessBoard.Exceptions;

namespace ChessBoard
{
    internal class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        private readonly Piece[,] Pieces;

        public Board(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Pieces = new Piece[Rows, Columns];
        }

        public Piece Piece(int row, int column)
        {
            return Pieces[row, column];
        }

        public Piece Piece(Position position)
        {
            return Pieces[position.Row, position.Column];
        }

        public bool ExistPiece(Position position)
        {
            ValidatePosition(position);
            return Piece(position) != null;
        }

        public void PlacePiece(Piece piece, Position position)
        {
            if(ExistPiece(position))
            {
                throw new BoardException("Already have a piece placed here!");
            }

            Pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public bool ValidPosition(Position position)
        {
            if(position.Row < 0 || position.Column < 0 || position.Row > Rows || position.Column > Columns)
            {
                return false;
            }

            return true;
        }

        public void ValidatePosition(Position position)
        {
            if(!ValidPosition(position))
            {
                throw new BoardException("Invalid Position!");
            }
        }


    }
}
