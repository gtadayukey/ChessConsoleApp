using ChessBoard;
using ChessBoard.Enums;
using ChessBoard.Exceptions;
using ChessConsoleApp.ChessGame;
using System.Text.RegularExpressions;

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

        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine($"\nTurn: {match.Turn}");
            Console.WriteLine($"Waiting for {match.CurrentPlayer} to play");
        }

        public static void PrintCapturedPieces(ChessMatch match)
        {
            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            PrintSet(match.PiecesCaptured(ChessColor.White));
            Console.Write("\nBlack: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintSet(match.PiecesCaptured(ChessColor.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void PrintSet(HashSet<Piece> set)
        {
            Console.WriteLine("[");
            foreach(Piece piece in set)
            {
                Console.WriteLine($"{piece} ");
            }
            Console.WriteLine("]");
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

        public static ChessLabel ReadChessLabel()
        {
            string input = Console.ReadLine();

            char column = input[0];
            int row = int.Parse(input[1] + "");

            return new ChessLabel(column, row);
        }
    }
}
