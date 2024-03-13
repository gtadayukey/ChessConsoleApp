using ChessBoard;
using ChessBoard.Enums;
using ChessBoard.Exceptions;
using ChessConsoleApp;
using ChessConsoleApp.ChessGame;
using ChessGame;

ChessPosition chessPosition = new('c', 7);

Console.WriteLine(chessPosition);

Console.WriteLine(chessPosition.ToPosition());