using ChessBoard;
using ChessBoard.Enums;
using ChessBoard.Exceptions;
using ChessConsoleApp;
using ChessConsoleApp.ChessGame;
using ChessGame;

try
{
    ChessMatch match = new();

    while (!match.Finished)
    {
        Console.Clear();
        Display.PrintBoard(match.Board);

        Console.Write("\nOrigin: ");
        Position origin = Display.ReadChessPosition().ToPosition();
        Console.Write("Destiny: ");
        Position destiny = Display.ReadChessPosition().ToPosition();

        match.ExecuteMovement(origin, destiny);
    }


}
catch(BoardException e)
{
    Console.WriteLine(e.Message);
} 
catch(FormatException e)
{
    Console.WriteLine(e.Message);
}
catch(Exception e)
{
    Console.WriteLine(e.Message);
}

