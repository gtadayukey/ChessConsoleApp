using ChessBoard;
using ChessBoard.Enums;
using ChessGame;
using System.Drawing;

namespace ChessConsoleApp.ChessGame
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        private int Turn { get; set; }
        private ChessColor Color { get; set; }
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            Color = ChessColor.White;
            Finished = false;
            BuildBoardSetup();
        }

        public void ExecuteMovement(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.AddMovementAmount();
            Board.RemovePiece(destiny);
            Board.PlacePiece(piece, destiny);   
        }

        private void BuildBoardSetup()
        {
            Board.PlacePiece(new Queen(Board, ChessColor.Black), new ChessLabel('e', 4).ToPosition());


            //Board.PlacePiece(new Tower(Board, ChessColor.White), new ChessPosition('a', 1).ToPosition());
            //Board.PlacePiece(new Horse(Board, ChessColor.White), new ChessPosition('b', 1).ToPosition());
            //Board.PlacePiece(new Bishop(Board, ChessColor.White), new ChessPosition('c', 1).ToPosition());
            //Board.PlacePiece(new Queen(Board, ChessColor.White), new ChessPosition('d', 1).ToPosition());
            //Board.PlacePiece(new King(Board, ChessColor.White), new ChessPosition('e', 1).ToPosition());
            //Board.PlacePiece(new Bishop(Board, ChessColor.White), new ChessPosition('f', 1).ToPosition());
            //Board.PlacePiece(new Horse(Board, ChessColor.White), new ChessPosition('g', 1).ToPosition());
            //Board.PlacePiece(new Tower(Board, ChessColor.White), new ChessPosition('h', 1).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessPosition('a', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessPosition('b', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessPosition('c', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessPosition('d', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessPosition('e', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessPosition('f', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessPosition('g', 2).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.White), new ChessPosition('h', 2).ToPosition());

            //Board.PlacePiece(new Tower(Board, ChessColor.Black), new ChessPosition('a', 8).ToPosition());
            //Board.PlacePiece(new Horse(Board, ChessColor.Black), new ChessPosition('b', 8).ToPosition());
            //Board.PlacePiece(new Bishop(Board, ChessColor.Black), new ChessPosition('c', 8).ToPosition());
            //Board.PlacePiece(new Queen(Board, ChessColor.Black), new ChessPosition('d', 8).ToPosition());
            //Board.PlacePiece(new King(Board, ChessColor.Black), new ChessPosition('e', 8).ToPosition());
            //Board.PlacePiece(new Bishop(Board, ChessColor.Black), new ChessPosition('f', 8).ToPosition());
            //Board.PlacePiece(new Horse(Board, ChessColor.Black), new ChessPosition('g', 8).ToPosition());
            //Board.PlacePiece(new Tower(Board, ChessColor.Black), new ChessPosition('h', 8).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessPosition('a', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessPosition('b', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessPosition('c', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessPosition('d', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessPosition('e', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessPosition('f', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessPosition('g', 7).ToPosition());
            //Board.PlacePiece(new Pawn(Board, ChessColor.Black), new ChessPosition('h', 7).ToPosition());
        }
    }
}
