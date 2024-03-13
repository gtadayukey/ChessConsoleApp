using ChessBoard;

namespace ChessConsoleApp
{
    class Display
    {
        public static void PrintBoard(Board board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Columns; j++)
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
