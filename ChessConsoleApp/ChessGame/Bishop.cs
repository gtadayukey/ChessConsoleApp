﻿using ChessBoard;
using ChessBoard.Enums;

namespace ChessGame
{
    internal class Bishop : Piece
    {
        public Bishop(Board board, PieceColor color) : base(board, color) { }

        public override string ToString()
        {
            return "B";
        }
    }
}
