using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.GamePathLogic.Squares
{
    abstract class BladeFactory : SquaresFactory
    {
        protected int size;

        public void SetSize(int size)
        {
            this.size = size;
        }
    }
}
