using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Turns
{
    class AddExtraTurn : AddSpecialTurn
    {
        public Elements.Player Player { get; set; }

        public AddExtraTurn(TurnList turnList)
        {
            this.turnList = turnList;
        }

        public override void Attach()
        {
            
        }
    }
}
