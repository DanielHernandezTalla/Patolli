using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Turns
{
    abstract class AddSpecialTurn
    {
        protected TurnList turnList;

        public abstract void Attach();
    }
}
