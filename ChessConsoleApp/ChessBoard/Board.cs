namespace ChessBoard
{
    internal class Board
    {
        public int Line { get; set; }
        public int Column { get; set; }
        private readonly Piece[,] Pieces;

        public Board(int line, int column)
        {
            Line = line;
            Column = column;
            Pieces = new Piece[Line, Column];
        }

        public Piece Piece(int line, int column)
        {
            return Pieces[line, column];
        }

        public void PlacePiece(Piece piece, Position position)
        {
            Pieces[position.Line, position.Column] = piece;
            piece.Position = position;
        }
    }
}
