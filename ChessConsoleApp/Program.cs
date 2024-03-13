using ChessBoard;
using ChessBoard.Enums;
using ChessGame;

namespace ChessConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new(8, 8);

            board.PlacePiece(new Tower(board, PieceColor.Black), new Position(0, 0));
            board.PlacePiece(new Queen(board, PieceColor.White), new Position(4, 5));
            board.PlacePiece(new King(board, PieceColor.White), new Position(5, 4));
            board.PlacePiece(new King(board, PieceColor.Black), new Position(0, 1));
            board.PlacePiece(new Tower(board, PieceColor.Black), new Position(7, 4));

            Display.PrintBoard(board);
        }
    }
}