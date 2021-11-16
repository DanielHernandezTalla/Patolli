using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.GamePathLogic.Squares
{
    class ResizableBladeFactory : BladeFactory
    {
        private readonly int constantSquares = 4;
        private List<Square> startSquares = new List<Square>();
        public bool HasStartSquare { get; set; }


        public ResizableBladeFactory(Actions.Receiver receiver, int size)
        {
            this.receiver = receiver;
            this.size = size;
        }

        public override Square[] FactoryMethod()
        {
            if (receiver == null)
                throw new Exception("Se intentó crear una Casilla con un Receptor nulo.");
            else
            {
                if (size >= constantSquares)
                {
                    Square[] blade = new Square[size * 2];
                    int variableSquares = size - constantSquares;

                    if(HasStartSquare)
                    {
                        Square startSquare = new GoalSquare(receiver);
                        blade[0] = startSquare;
                        startSquares.Add(startSquare);
                    }
                    else blade[0] = new DefaultSquare(receiver);


                    for (int i = 0; i < variableSquares; i++)
                        blade[1 + i] = new DefaultSquare(receiver);

                    blade[variableSquares + 1] = new TriangleSquare(receiver);
                    blade[variableSquares + 2] = new TriangleSquare(receiver);

                    blade[variableSquares + 3] = new CornerSquare(receiver);
                    blade[variableSquares + 4] = new CornerSquare(receiver);

                    blade[variableSquares + 5] = new TriangleSquare(receiver);
                    blade[variableSquares + 6] = new TriangleSquare(receiver);

                    for (int i = 0; i < variableSquares; i++)
                        blade[variableSquares + 7 + i] = new DefaultSquare(receiver);

                    blade[variableSquares * 2 + 7] = new DefaultSquare(receiver);

                    return blade;
                }
                else throw new Exception($"Se intentó crear una Aspa de recorrido menor a {constantSquares}");

            }
        }

        public Square[] GetStartSquares()
        {
            return startSquares.ToArray();
        }
    }
}
