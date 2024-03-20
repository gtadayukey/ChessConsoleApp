using ChessBoard;
using ChessBoard.Enums;
using ChessBoard.Exceptions;
using ChessGame;
using System.Drawing;
using System.Numerics;

namespace ChessConsoleApp.ChessGame
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Turn { get; private set; }
        public ChessColor CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = ChessColor.White;
            Finished = false;
            BuildBoardSetup();
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == ChessColor.White)
            {
                CurrentPlayer = ChessColor.Black;
                return;
            }

            CurrentPlayer = ChessColor.White;
        }

        public void Play(Position origin, Position destiny)
        {
            ExecuteMovement(origin, destiny);
            Turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position origin)
        {
            if (Board.Piece(origin) == null)
            {
                throw new BoardException("Doesn't have a piece here!");
            }
            if (CurrentPlayer != Board.Piece(origin).Color)
            {
                throw new BoardException("The origin piece isn't yours!");
            }
            if (!Board.Piece(origin).HavePossibleMovement())
            {
                throw new BoardException("This piece doesn't have any possible moves!");

            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            bool[,] matrix = Board.Piece(origin).PossibleMovement();

            if (matrix[destiny.Row, destiny.Column] == false)
            {
                throw new BoardException("This piece can't move here!");
            }

            if (Board.ExistPiece(destiny) && CurrentPlayer == Board.Piece(destiny).Color)
            {
                throw new BoardException("Can't eat your own piece!");
            }
        }

        private void ExecuteMovement(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.AddMovementAmount();
            Board.RemovePiece(destiny);
            Board.PlacePiece(piece, destiny);
        }

        private void BuildBoardSetup()
        {

            Board.PlacePiece(new Tower(Board, ChessColor.White), new ChessLabel('a', 1).ToPosition());
            Board.PlacePiece(new Horse(Board, ChessColor.White), new ChessLabel('b', 1).ToPosition());
            Board.PlacePiece(new Bishop(Board, ChessColor.White), new ChessLabel('c', 1).ToPosition());
            Board.PlacePiece(new Queen(Board, ChessColor.White), new ChessLabel('d', 1).ToPosition());
            Board.PlacePiece(new King(Board, ChessColor.White), new ChessLabel('e', 1).ToPosition());
            Board.PlacePiece(new Bishop(Board, ChessColor.White), new ChessLabel('f', 1).ToPosition());
            Board.PlacePiece(new Horse(Board, ChessColor.White), new ChessLabel('g', 1).ToPosition());
            Board.PlacePiece(new Tower(Board, ChessColor.White), new ChessLabel('h', 1).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessLabel('a', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessLabel('b', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessLabel('c', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessLabel('d', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessLabel('e', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessLabel('f', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessLabel('g', 2).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessLabel('h', 2).ToPosition());

            Board.PlacePiece(new Tower(Board, ChessColor.Black), new ChessLabel('a', 8).ToPosition());
            Board.PlacePiece(new Horse(Board, ChessColor.Black), new ChessLabel('b', 8).ToPosition());
            Board.PlacePiece(new Bishop(Board, ChessColor.Black), new ChessLabel('c', 8).ToPosition());
            Board.PlacePiece(new Queen(Board, ChessColor.Black), new ChessLabel('d', 8).ToPosition());
            Board.PlacePiece(new King(Board, ChessColor.Black), new ChessLabel('e', 8).ToPosition());
            Board.PlacePiece(new Bishop(Board, ChessColor.Black), new ChessLabel('f', 8).ToPosition());
            Board.PlacePiece(new Horse(Board, ChessColor.Black), new ChessLabel('g', 8).ToPosition());
            Board.PlacePiece(new Tower(Board, ChessColor.Black), new ChessLabel('h', 8).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessLabel('a', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessLabel('b', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessLabel('c', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessLabel('d', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessLabel('e', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessLabel('f', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessLabel('g', 7).ToPosition());
            Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessLabel('h', 7).ToPosition());
        }
    }
}
