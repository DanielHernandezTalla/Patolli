using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Game
{
    public struct Piece
    {
        public int PieceNumber { get; set; }
        public int PlayerNumber { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public GamePieceState State { get; set; }

        public bool IsAlive;

        // Este enum es una copia de un enum con el mismo nombre que se encuentra en GameRun.Elements.GamePiece
        public enum GamePieceState
        {
            NotInitialized,
            InGame,
            Eliminated,
            Finished
        }

        public void Fill(GameRun.Elements.GamePiece piece)
        {
            PieceNumber = piece.PieceNumber;
            PlayerNumber = piece.PlayerNumber;
            X = piece.Location.X;
            Y = piece.Location.Y;
            Width = piece.Width;
            Height = piece.Height;
            State = (GamePieceState)piece.PieceState;
        }
    }
}
