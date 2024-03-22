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
        Display.GetUserInputs(match);
    }
    catch (BoardException e)
    {
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        Console.ReadLine();
    }
}

Console.Clear();
Display.PrintMatch(match);

