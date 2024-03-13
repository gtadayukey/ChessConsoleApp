using ChessBoard;
using ChessBoard.Enums;
using ChessBoard.Exceptions;
using ChessConsoleApp;
using ChessGame;

try
{
    Board board = new(8, 8);

    board.PlacePiece(new Bishop(board, PieceColor.Black), new Position(0, 0));
    board.PlacePiece(new Queen(board, PieceColor.White), new Position(4, 5));
    board.PlacePiece(new King(board, PieceColor.White), new Position(5, 4));
    board.PlacePiece(new King(board, PieceColor.Black), new Position(0, 1));
    board.PlacePiece(new Tower(board, PieceColor.Black), new Position(7, 4));
    board.PlacePiece(new Horse(board, PieceColor.White), new Position(3, 1));
    board.PlacePiece(new Pawn(board, PieceColor.Black), new Position(9, 0));

    Display.PrintBoard(board);
}
catch (BoardException ex)
{
    Console.WriteLine(ex);
}
