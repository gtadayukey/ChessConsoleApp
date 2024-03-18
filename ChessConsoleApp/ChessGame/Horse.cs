﻿using ChessBoard;
using ChessBoard.Enums;

namespace ChessGame
{
    internal class Horse : Piece
    {
        public Horse(Board board, ChessColor color) : base(board, color) { }

        public override string ToString()
        {
            return "H";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMovement()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];
            Position position = new(0, 0);

            return matrix;
        }
    }
}
