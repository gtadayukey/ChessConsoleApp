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
        private readonly HashSet<Piece> Pieces;
        private readonly HashSet<Piece> CapturedPieces;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = ChessColor.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
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
            Board.ValidatePosition(origin);

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
            Board.ValidatePosition(destiny);

            if (!Board.Piece(origin).CanMoveTo(destiny))
            {
                throw new BoardException("Invalid destiny position!");
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
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PlacePiece(piece, destiny);

            if(capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
        }

        public HashSet<Piece> PiecesCaptured(ChessColor color)
        {
            HashSet<Piece> aux = new();

            foreach(Piece x in CapturedPieces)
            {
                if(x.Color == color)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Piece> PiecesInGame(ChessColor color)
        {
            HashSet<Piece> aux = new();

            foreach (Piece x in CapturedPieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            
            aux.ExceptWith(PiecesCaptured(color));

            return aux;
        }

        public void PlaceNewPiece(char column, int row, Piece piece)
        {
            Board.PlacePiece(piece, new ChessLabel(column, row).ToPosition());
            Pieces.Add(piece);
        }

        private void BuildBoardSetup()
        {

            PlaceNewPiece('a', 1, new Tower(Board, ChessColor.White));
            PlaceNewPiece('b', 1, new Horse(Board, ChessColor.White));
            PlaceNewPiece('c', 1, new Bishop(Board, ChessColor.White));
            PlaceNewPiece('d', 1, new Queen(Board, ChessColor.White));
            PlaceNewPiece('e', 1, new King(Board, ChessColor.White));
            PlaceNewPiece('f', 1, new Bishop(Board, ChessColor.White));
            PlaceNewPiece('g', 1, new Horse(Board, ChessColor.White));
            PlaceNewPiece('h', 1, new Tower(Board, ChessColor.White));
            PlaceNewPiece('a', 2, new Pawn(Board, ChessColor.White));
            PlaceNewPiece('b', 2, new Pawn(Board, ChessColor.White));
            PlaceNewPiece('c', 2, new Pawn(Board, ChessColor.White));
            PlaceNewPiece('d', 2, new Pawn(Board, ChessColor.White));
            PlaceNewPiece('e', 2, new Pawn(Board, ChessColor.White));
            PlaceNewPiece('f', 2, new Pawn(Board, ChessColor.White));
            PlaceNewPiece('g', 2, new Pawn(Board, ChessColor.White));
            PlaceNewPiece('h', 2, new Pawn(Board, ChessColor.White));
            
            PlaceNewPiece('a', 8, new Tower(Board, ChessColor.Black));
            PlaceNewPiece('b', 8, new Horse(Board, ChessColor.Black));
            PlaceNewPiece('c', 8, new Bishop(Board, ChessColor.Black));
            PlaceNewPiece('d', 8, new Queen(Board, ChessColor.Black));
            PlaceNewPiece('e', 8, new King(Board, ChessColor.Black));
            PlaceNewPiece('f', 8, new Bishop(Board, ChessColor.Black));
            PlaceNewPiece('g', 8, new Horse(Board, ChessColor.Black));
            PlaceNewPiece('h', 8, new Tower(Board, ChessColor.Black));
            PlaceNewPiece('a', 7, new Pawn(Board, ChessColor.Black));
            PlaceNewPiece('b', 7, new Pawn(Board, ChessColor.Black));
            PlaceNewPiece('c', 7, new Pawn(Board, ChessColor.Black));
            PlaceNewPiece('d', 7, new Pawn(Board, ChessColor.Black));
            PlaceNewPiece('e', 7, new Pawn(Board, ChessColor.Black));
            PlaceNewPiece('f', 7, new Pawn(Board, ChessColor.Black));
            PlaceNewPiece('g', 7, new Pawn(Board, ChessColor.Black));
            PlaceNewPiece('h', 7, new Pawn(Board, ChessColor.Black));
        }
    }
}
