using ChessBoard;
using ChessBoard.Enums;
using ChessBoard.Exceptions;
using ChessConsoleApp;
using ChessConsoleApp.ChessGame;
using ChessGame;

Board board = new(8, 8);

board.PlacePiece(new Tower(board, PieceColor.Black), new Position(2, 3));
board.PlacePiece(new Tower(board, PieceColor.Black), new Position(2, 5));
board.PlacePiece(new King(board, PieceColor.Black), new Position(2, 4));
board.PlacePiece(new Queen(board, PieceColor.White), new Position(5, 7));
board.PlacePiece(new King(board, PieceColor.White), new Position(4, 7));

Display.PrintBoard(board);