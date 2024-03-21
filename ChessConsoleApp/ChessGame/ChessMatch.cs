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
        public bool Check { get; private set; }
        private readonly HashSet<Piece> Pieces;
        private readonly HashSet<Piece> CapturedPieces;

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Turn = 1;
            CurrentPlayer = ChessColor.White;
            Finished = false;
            Check = false;
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
            Piece capturedPiece = ExecuteMovement(origin, destiny);

            if (IsInCheck(CurrentPlayer))
            {
                UndoPlay(origin, destiny, capturedPiece);
                throw new BoardException("You can't put yourself in check!");
            }

            if (IsInCheck(Opponent(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (IsInCheckMate(Opponent(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                ChangePlayer();
            }

        }

        private void UndoPlay(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece piece = Board.RemovePiece(destiny);
            piece.RemoveMovementAmount();
            if (capturedPiece != null)
            {
                Board.PlacePiece(capturedPiece, destiny);
                CapturedPieces.Remove(capturedPiece);
            }

            Board.PlacePiece(piece, origin);

            // Normal Rook
            if (piece is King && destiny.Row == origin.Column - 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Column - 4);
                Position towerDestiny = new Position(origin.Row, origin.Column - 1);
                Piece tower = Board.RemovePiece(towerDestiny);
                tower.RemoveMovementAmount();
                Board.PlacePiece(tower, towerOrigin);
            }

            // Short Rook
            if (piece is King && destiny.Row == origin.Column + 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Column + 3);
                Position towerDestiny = new Position(origin.Row, origin.Column + 1);
                Piece tower = Board.RemovePiece(towerDestiny);
                tower.RemoveMovementAmount();
                Board.PlacePiece(tower, towerOrigin);
            }

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

            if (!Board.Piece(origin).PossibleMovement(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }

            if (Board.ExistPiece(destiny) && CurrentPlayer == Board.Piece(destiny).Color)
            {
                throw new BoardException("Can't eat your own piece!");
            }
        }

        private Piece ExecuteMovement(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.AddMovementAmount();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.PlacePiece(piece, destiny);

            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }

            // Normal Rook
            if (piece is King && destiny.Column == origin.Column - 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Column - 4);
                Position towerDestiny = new Position(origin.Row, origin.Column - 1);
                Piece tower = Board.RemovePiece(towerOrigin);
                tower.AddMovementAmount();
                Board.PlacePiece(tower, towerDestiny);
            }

            // Short Rook
            if (piece is King && destiny.Column == origin.Column + 2)
            {
                Position towerOrigin = new Position(origin.Row, origin.Column + 3); 
                Position towerDestiny = new Position(origin.Row, origin.Column + 1); 
                Piece tower = Board.RemovePiece(towerOrigin);
                tower.AddMovementAmount();
                Board.PlacePiece(tower, towerDestiny);
            }

            return capturedPiece;
        }

        public HashSet<Piece> PiecesCaptured(ChessColor color)
        {
            HashSet<Piece> aux = new();

            foreach (Piece x in CapturedPieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }

        public HashSet<Piece> PiecesInGame(ChessColor color)
        {
            HashSet<Piece> aux = new();

            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(PiecesCaptured(color));

            return aux;
        }

        private ChessColor Opponent(ChessColor color)
        {
            if (color == ChessColor.White)
            {
                return ChessColor.Black;
            }

            return ChessColor.White;
        }

        private Piece King(ChessColor color)
        {
            foreach (Piece x in PiecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }

            return null;
        }

        public bool IsInCheck(ChessColor color)
        {

            Piece king = King(color);

            if (king == null)
            {
                throw new BoardException($"Does't have a {color} King in game!");
            }

            foreach (Piece x in PiecesInGame(Opponent(color)))
            {
                bool[,] matrix = x.PossibleMovements();
                if (matrix[king.Position.Row, king.Position.Column])
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsInCheckMate(ChessColor color)
        {
            if (!IsInCheck(color))
            {
                return false;
            }

            foreach (Piece x in PiecesInGame(color))
            {
                bool[,] matrix = x.PossibleMovements();
                for (int i = 0; i < Board.Rows; i++)
                {
                    for (int j = 0; j < Board.Columns; j++)
                    {
                        if (matrix[i, j])
                        {
                            Position origin = x.Position;
                            Position destiny = new(i, j);
                            Piece capturedPiece = ExecuteMovement(origin, destiny);
                            bool inCheck = IsInCheck(color);
                            UndoPlay(origin, destiny, capturedPiece);
                            if (!inCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
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
            PlaceNewPiece('e', 1, new King(Board, ChessColor.White, this));
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
            PlaceNewPiece('e', 8, new King(Board, ChessColor.Black, this));
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
