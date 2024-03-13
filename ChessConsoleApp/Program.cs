using ChessBoard;

namespace ChessConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Board board = new(8, 8);

            Display.PrintBoard(board);
        }
    }
}