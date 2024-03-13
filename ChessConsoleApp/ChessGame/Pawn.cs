﻿using ChessBoard;
using ChessBoard.Enums;

namespace ChessGame
{
    internal class Pawn : Piece
    {
        public Pawn(Board board, PieceColor color) : base(board, color) { }

        public override string ToString()
        {
            return "P";
        }
    }
}
