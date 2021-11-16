using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Turns
{
    public class PieceTurn : Turn
    {
        public Elements.GamePiece GamePiece { get; private set; }

        public PieceTurn(Elements.GamePiece piece)
        {
            GamePiece = piece;
        }
    }
}
