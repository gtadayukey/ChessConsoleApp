using ChessBoard;
using ChessBoard.Exceptions;
using ChessConsoleApp;
using ChessConsoleApp.ChessGame;

try
{
    ChessMatch match = new();

    while (!match.Finished)
    {
        Console.Clear();
        Display.PrintBoard(match.Board);

        Console.Write("\nOrigin: ");
        Position origin = Display.ReadChessPosition().ToPosition();

        bool[,] possibleMovement = match.Board.Piece(origin).PossibleMovement();

        Console.Clear();
        Display.PrintBoard(match.Board, possibleMovement);

        Console.Write("\nDestiny: ");
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

