using ChessBoard.Exceptions;

namespace ChessBoard
{
    internal class Board
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private readonly Piece[,] Pieces;

        public Board(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines, Columns];
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            return Pieces[position.Line, position.Column];
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

            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }

        public bool ValidPosition(Position position)
        {
            if(position.Line < 0 || position.Column < 0 || position.Line > Lines || position.Column > Columns)
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
