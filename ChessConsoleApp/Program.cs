using ChessBoard;
using ChessDisplay;
using ChessGame;


ChessMatch match = new();

while (!match.Finished)
{
    try
    {
        Console.Clear();
        Display.PrintMatch(match);

        Console.Write("\nOrigin: ");
        Position origin = Display.ReadChessLabel().ToPosition();

        match.ValidateOriginPosition(origin);

        bool[,] possibleMovement = match.Board.Piece(origin).PossibleMovements();

        Console.Clear();
        Display.PrintBoard(match.Board, possibleMovement);

        Console.Write("\nDestiny: ");
        Position destiny = Display.ReadChessLabel().ToPosition();

        match.ValidateDestinyPosition(origin, destiny);

        match.Play(origin, destiny);
    }
    catch (BoardException e)
    { 
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
    catch (Exception)
    {
        Console.ReadLine();
    }
}

Console.Clear();
Display.PrintMatch(match);

