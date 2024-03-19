﻿using ChessBoard;
using ChessBoard.Enums;

namespace ChessGame
{
    internal class Tower : Piece
    {
        public Tower(Board board, ChessColor color) : base(board, color) { }

        public override string ToString()
        {
            return "T";
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.Piece(position);
            if (piece == null || piece.Color != Color)
            {
                return true;
            }

            return false;
        }

        public override bool[,] PossibleMovement()
        {
            bool[,] matrix = new bool[Board.Rows, Board.Columns];
            Position position = new(0, 0);

            // Top
            position.SetValues(Position.Row - 1, Position.Column);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Row--;
            }

            //// Bottom
            //position.SetValues(Position.Row + 1, Position.Column);
            //while (Board.ValidPosition(position) && CanMove(position))
            //{
            //    matrix[position.Row, position.Column] = true;
            //    if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
            //    {
            //        break;
            //    }

            //    position.Row++;
            //}

            // Right
            position.SetValues(Position.Row, Position.Column - 1);
            while (Board.ValidPosition(position) && CanMove(position))
            {
                matrix[position.Row, position.Column] = true;
                if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
                {
                    break;
                }

                position.Column--;
            }

            //// Left
            //position.SetValues(Position.Row, Position.Column + 1);
            //while (Board.ValidPosition(position) && CanMove(position))
            //{
            //    matrix[position.Row, position.Column] = true;
            //    if (Board.Piece(position) != null && Board.Piece(position).Color != Color)
            //    {
            //        break;
            //    }

            //    position.Column++;
            //}


            return matrix;
        }
    }
}
