using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Turns
{
    class AddSpecificPieceTurn : AddSpecialTurn
    {
        public Elements.GamePiece Piece { get; set; }

        public AddSpecificPieceTurn(TurnList turnList)
        {
            this.turnList = turnList;
        }

        public override void Attach()
        {
            
        }
    }
}
