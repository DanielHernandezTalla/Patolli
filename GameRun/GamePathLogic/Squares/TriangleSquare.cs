using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRun.Actions;
using GameRun.Elements;

namespace GameRun.GamePathLogic.Squares
{

    public class TriangleSquare : Square
    {
        public bool FlipX { get; internal set; }
        public bool FlipY { get; internal set; }

        public TriangleSquare(Receiver receiver)
        {
            AddAction(new MoveBackAction(receiver));
            AddAction(new PayBetAction(receiver));

            Type = SquareType.Triangle;
        }

        public TriangleSquare(Receiver receiver, bool FlipX, bool FlipY) : this(receiver)
        {
            this.FlipX = FlipX;
            this.FlipY = FlipY;
        }

        /// <summary>
        /// Metodo utilizado para asignar los Flips de las casillas Triangulo en un Aspa. Los Flips
        /// correspondientes a la dirección de la Aspa.
        /// </summary>
        /// <param name="blade">Arreglo de Casillas que forman la estructura de una Aspa del tablero.</param>
        /// <param name="direction">Dirección de la Aspa.</param>
        public static void SetSquareFlips(Square[] blade, CardinalDirection direction)
        {
            try
            {
                Square[] triangles = new Square[4];
                int counter = 0;

                for (int i = 0; i < blade.Length; i++)
                {
                    if (blade[i].Type == SquareType.Triangle)
                    {
                        if (counter < 4)
                        {
                            triangles[counter] = blade[i];
                            counter++;
                        }
                    }
                }

                if (direction == CardinalDirection.North || direction == CardinalDirection.South)
                {
                    ((TriangleSquare)triangles[0]).FlipX = false;
                    ((TriangleSquare)triangles[0]).FlipY = false;

                    ((TriangleSquare)triangles[1]).FlipX = false;
                    ((TriangleSquare)triangles[1]).FlipY = true;

                    ((TriangleSquare)triangles[2]).FlipX = true;
                    ((TriangleSquare)triangles[2]).FlipY = true;

                    ((TriangleSquare)triangles[3]).FlipX = true;
                    ((TriangleSquare)triangles[3]).FlipY = false;
                }
                else if (direction == CardinalDirection.East || direction == CardinalDirection.West)
                {
                    ((TriangleSquare)triangles[0]).FlipX = false;
                    ((TriangleSquare)triangles[0]).FlipY = false;

                    ((TriangleSquare)triangles[1]).FlipX = true;
                    ((TriangleSquare)triangles[1]).FlipY = false;

                    ((TriangleSquare)triangles[2]).FlipX = true;
                    ((TriangleSquare)triangles[2]).FlipY = true;

                    ((TriangleSquare)triangles[3]).FlipX = false;
                    ((TriangleSquare)triangles[3]).FlipY = true;
                }
            }
            catch(Exception e)
            {
                throw new Exception("No se pudo asignar correctamente los Flips de las casillas triangulo.\n" + e.Message);
            }
            


        }
    }
}
