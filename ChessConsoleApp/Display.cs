using ChessBoard;
using ChessBoard.Enums;

namespace ChessConsoleApp
{
    class Display
    {
        public static void PrintBoard(Board board)
        {
            Console.WriteLine("    a b c d e f g h\n");

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write((8 - i) + "   ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.Piece(i, j) == null)
                    {
                        Console.Write("- ");
                        continue;
                    }
                    PrintPiece(board.Piece(i, j));
                    Console.Write(" ");
                }
                Console.Write("  " + (8 - i) + "\n");
            }
            Console.WriteLine("\n    a b c d e f g h");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == ChessColor.White)
            {
                Console.Write(piece);
                return;
            }

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(piece);
            Console.ForegroundColor = aux;

        }
    }
}
