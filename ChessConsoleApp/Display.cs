using ChessBoard;
using ChessBoard.Enums;
using ChessConsoleApp.ChessGame;

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
                    PrintPiece(board.Piece(i, j));
                }
                Console.Write("  " + (8 - i) + "\n");
            }
            Console.WriteLine("\n    a b c d e f g h");
        }

        public static void PrintBoard(Board board, bool[,] possibleMovement)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            Console.WriteLine("    a b c d e f g h\n");

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write((8 - i) + "   ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possibleMovement[i, j] == true)
                    {
                        Console.BackgroundColor = alteredBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }

                    PrintPiece(board.Piece(i, j));
                }
                Console.BackgroundColor = originalBackground;

                Console.Write("  " + (8 - i) + "\n");
            }
            Console.WriteLine("\n    a b c d e f g h");
        }

        public static void PrintPiece(Piece piece)
        {

            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == ChessColor.White)
                {
                    Console.Write(piece);
                    Console.Write(" ");
                    return;
                }

                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.Write(" ");
                Console.ForegroundColor = aux;
            }
        }

        public static ChessLabel ReadChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int row = int.Parse(s[1] + "");
            return new ChessLabel(column, row);
        }
    }
}
