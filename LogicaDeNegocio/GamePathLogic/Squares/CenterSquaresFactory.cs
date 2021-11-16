using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.GamePathLogic.Squares
{
    class CenterSquaresFactory : SquaresFactory
    {
        public CenterSquaresFactory(Actions.Receiver receiver)
        {
            this.receiver = receiver;
        }

        public override Square[] FactoryMethod()
        {
            if (receiver == null)
                throw new Exception("Se intentó crear una Casilla con un Receptor nulo.");
            else
                return new Square[] { new CenterSquare(receiver) };
        }
    }
}
