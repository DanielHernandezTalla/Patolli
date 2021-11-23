using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRun.Elements;

namespace GameRun.GamePathLogic.Squares
{
    public class SerializableSquare
    {
        public Point Location { get; set; }

        public Square.SquareType Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int RelativeWidth
        {
            get
            {
                if (SquareDirection == CardinalDirection.North || SquareDirection == CardinalDirection.South)
                {
                    return Width;
                }
                else if (SquareDirection == CardinalDirection.East || SquareDirection == CardinalDirection.West)
                {
                    return Height;
                }

                throw new Exception("Direccion cardinal no identificada.");
            }
        }
        public int RelativeHeight
        {
            get
            {
                if (SquareDirection == CardinalDirection.North || SquareDirection == CardinalDirection.South)
                {
                    return Height;
                }
                else if (SquareDirection == CardinalDirection.East || SquareDirection == CardinalDirection.West)
                {
                    return Width;
                }

                throw new Exception("Direccion cardinal no identificada.");
            }
        }

        public bool FlipX { get; set; }
        public bool FlipY { get; set; }

        public CardinalDirection SquareDirection { get; set; }

        public void Fill(Square square)
        {
            Location = square.Location;
            Type = square.Type;
            Width = square.Width;
            Height = square.Height;
            SquareDirection = square.SquareDirection;

            if (square.Type == Square.SquareType.Triangle)
            {
                FlipX = ((TriangleSquare)square).FlipX;
                FlipY = ((TriangleSquare)square).FlipY;
            }
        }
    }
}
