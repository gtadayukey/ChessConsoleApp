﻿using ChessBoard;
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
            Display.PrintMatch(match);

            Console.Write("\nOrigin: ");
            Position origin = Display.ReadChessLabel().ToPosition();

            match.ValidateOriginPosition(origin);

            bool[,] possibleMovement = match.Board.Piece(origin).PossibleMovement();

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
    }
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

