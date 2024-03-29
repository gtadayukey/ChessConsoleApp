﻿using ChessBoard;
using ChessGame;


namespace ChessDisplay
{
    class Display
    {
        public static void PrintMatch(ChessMatch match)
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine($"\nTurn: {match.Turn}");
            if (!match.Finished)
            {
                Console.WriteLine($"Waiting for {match.CurrentPlayer} to play");
                if (match.Check)
                {
                    Console.WriteLine("CHECK !");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE !!!");
                Console.WriteLine($"Winner: {match.CurrentPlayer}");
            }
        }

        public static void GetUserInputs(ChessMatch match)
        {
            Console.Write("\nOrigin: ");
            Position origin = ReadChessLabel().ToPosition();

            match.ValidateOriginPosition(origin);

            bool[,] possibleMovement = match.Board.Piece(origin).PossibleMovements();

            Console.Clear();
            PrintBoard(match.Board, possibleMovement);

            Console.Write("\nDestiny: ");
            Position destiny = ReadChessLabel().ToPosition();

            match.ValidateDestinyPosition(origin, destiny);

            match.Play(origin, destiny);
        }


        private static void PrintBoard(Board board)
        {
            Console.WriteLine("    a b c d e f g h\n");

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + "   ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.Piece(i, j));
                }
                Console.Write("  " + (8 - i) + "\n");
            }
            Console.WriteLine("\n    a b c d e f g h");
        }

        private static void PrintBoard(Board board, bool[,] possibleMovement)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alteredBackground = ConsoleColor.DarkGray;

            Console.WriteLine("    a b c d e f g h\n");

            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write(8 - i + "   ");
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


        private static void PrintCapturedPieces(ChessMatch match)
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

        private static void PrintSet(HashSet<Piece> set)
        {
            Console.Write("[ ");
            foreach (Piece piece in set)
            {
                Console.Write($"{piece} ");
            }
            Console.Write("]");
        }

        private static void PrintPiece(Piece piece)
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

        private static ChessLabel ReadChessLabel()
        {

            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input) && input.Length == 2)
            {
                if (char.IsLetter(input[0]) && char.IsNumber(input[1]))
                {
                    char column = input[0];
                    int row = int.Parse(input[1] + "");

                    return new ChessLabel(column, row);
                }
            }

            throw new BoardException("Invalid input!");

        }

        public static char ReadPromotion()
        {
            Console.Write("\nChosse promotional piece [ Q T B H ]: ");
            string? input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                input = input.ToUpper();

                if (char.IsLetter(input[0]) && input.Length == 1)
                {
                    char character = input[0];

                    return character;
                }
            }

            return 'Q';
        }
    }
}
