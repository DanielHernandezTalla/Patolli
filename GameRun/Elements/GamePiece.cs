using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.Elements
{
    public class GamePiece
    {
        public const int WIDTH = 32;
        public const int HEIGHT = 32;

        public int PieceNumber { get; private set; }
        public int PlayerNumber { get; private set; }
        public GamePieceState PieceState { get; internal set; } = GamePieceState.NotInitialized;
        public Player.PlayerColor Color { get; private set; }

        public enum GamePieceState
        {
            NotInitialized,
            InGame,
            Eliminated,
            Finished
        }

        // Propiedades graficas.
        public Point Location { get; set; }
        public Point RelativeLocation { get; set; }
        public int Width { get; private set; } = WIDTH;
        public int Height { get; private set; } = HEIGHT;

        public GamePiece(int pieceNumber, int playerNumber, Player.PlayerColor color)
        {
            PieceNumber = pieceNumber;
            PlayerNumber = playerNumber;
            Color = color;
        }
    }
}
