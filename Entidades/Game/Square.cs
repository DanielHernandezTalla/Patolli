using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Game
{
    struct Square
    {
        public int X { get; set; }
        public int Y { get; set; }

        public SquareType Type { get; set; }
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

        public void Fill(GameRun.GamePathLogic.Squares.Square square)
        {
            X = square.Location.X;
            Y = square.Location.Y;
            Type = (SquareType)square.Type;
            Width = square.Width;
            Height = square.Height;
            SquareDirection = (CardinalDirection)square.SquareDirection;

            if (square.Name.Equals(GameRun.GamePathLogic.Squares.Square.SquareType.Triangle.ToString()))
            {
                FlipX = ((GameRun.GamePathLogic.Squares.TriangleSquare)square).FlipX;
                FlipY = ((GameRun.GamePathLogic.Squares.TriangleSquare)square).FlipY;
            }
        }

        // Este enum es una copia de un enum con el mismo nombre que se encuentra en GameRun.GamePathLogic.Squares.Square
        public enum SquareType
        {
            Default,
            Center,
            Corner,
            Triangle,
            Goal
        }
    }
}
