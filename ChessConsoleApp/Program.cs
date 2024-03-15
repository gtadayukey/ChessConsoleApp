using ChessBoard;
using ChessBoard.Enums;
using ChessBoard.Exceptions;
using ChessConsoleApp;
using ChessConsoleApp.ChessGame;
using ChessGame;

try
{
    ChessMatch match = new();
    Display.PrintBoard(match.Board);
}
catch
{

}
