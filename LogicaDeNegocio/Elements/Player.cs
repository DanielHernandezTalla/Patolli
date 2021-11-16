using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Elements
{
    public class Player
    {
        /// <summary>
        /// Número identificador de un jugador. Es en base cero y hace referencia al indice correspondiente
        /// en el arreglo principal de jugadores del Game.
        /// </summary>
        public int PlayerNumber { get; private set; }
        public string Name 
        { 
            get
            {
                return name;
            }
            internal set
            {
                if (value == null)
                    name = "";
                else
                    name = value;
            }
        }
        private string name;
        public GamePiece[] GamePieces { get; private set; }
        public PlayerColor Color { get; private set; }

        public enum PlayerColor
        {
            Red,
            Blue,
            Yellow,
            Green
        }

        public Player(int playerNumber, string name, PlayerColor color, int piecesQuantity)
        {
            PlayerNumber = playerNumber;
            Name = name;
            Color = color;
            GamePieces = new GamePiece[piecesQuantity];
        }

        public bool Contains(GamePiece piece)
        {
            for (int i = 0; i < GamePieces.Length; i++)
            {
                if (GamePieces[i] != null && GamePieces[i] == piece) return true;
            }

            return false;
        }

    }
}
