using ChessBoard;

namespace ChessConsoleApp
{
    class Display
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Line; i++)
            {
                for (int j = 0; j < board.Column; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                        continue;
                    }

                    Console.Write($"{board.Piece(i, j)} ");
                }

                Console.WriteLine();
            }
        }
    }
}
