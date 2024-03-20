using ChessBoard;
using ChessBoard.Exceptions;
using ChessConsoleApp;
using ChessConsoleApp.ChessGame;

try
{
    ChessMatch match = new();

    while (!match.Finished)
    {
        try
        {
            Console.Clear();
            Display.PrintBoard(match.Board);
            Console.WriteLine($"\nTurn: {match.Turn}");
            Console.WriteLine($"Waiting for {match.CurrentPlayer} to play");

            Console.Write("\nOrigin: ");
            Position origin = Display.ReadChessPosition().ToPosition();

            match.ValidateOriginPosition(origin);

            bool[,] possibleMovement = match.Board.Piece(origin).PossibleMovement();

            Console.Clear();
            Display.PrintBoard(match.Board, possibleMovement);

            Console.Write("\nDestiny: ");
            Position destiny = Display.ReadChessPosition().ToPosition();

            match.ValidateDestinyPosition(origin, destiny);

            match.Play(origin, destiny);
        }
        catch (BoardException e)
        { 
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}
catch (FormatException e)
{
    Console.WriteLine(e.Message);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

