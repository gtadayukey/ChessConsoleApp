﻿using ChessBoard;
using ChessBoard.Enums;

namespace ChessGame
{
    internal class Horse : Piece
    {
        public Horse(Board board, PieceColor color) : base(board, color) { }

        public override string ToString()
        {
            return "H";
        }
    }
}