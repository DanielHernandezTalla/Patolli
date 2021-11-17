using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Elements;
using LogicaDeNegocio.GamePathLogic.Squares;

namespace Controles
{
    struct BoardImages
    {
        private static string Path
        {
            get
            {
                return "..\\..\\..\\resources\\";
            }
        }

        public static Bitmap GetImageSquare(Square square)
        {
            Square.SquareType type = square.Type;
            CardinalDirection direction = square.SquareDirection;

            switch (type)
            {
                case Square.SquareType.Default:
                    return GetDefaultSquare(direction);

                case Square.SquareType.Center:
                    return CenterSquare;

                case Square.SquareType.Triangle:
                    return GetTriangleSquare(direction, ((TriangleSquare)square).FlipX, ((TriangleSquare)square).FlipY);

                case Square.SquareType.Goal:
                    return GetGoalSquare(direction);

                case Square.SquareType.Corner:
                    return GetCornerSquare(direction);

                default:
                    return GetDefaultSquare(direction);
            }
        }


        public static Bitmap GetDefaultSquare(CardinalDirection direction)
        {
            if(direction == CardinalDirection.North || direction == CardinalDirection.South)
            {
                return DefaultSquare;
            }
            else if(direction == CardinalDirection.East || direction == CardinalDirection.West)
            {
                return DefaultSquareRotated;
            }
            else
                throw new Exception();           
        }

        internal static Bitmap DefaultSquare
        {
            get
            {
                string fullPath = Path + "default_square.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }

        internal static Bitmap DefaultSquareRotated
        {
            get
            {
                Bitmap square = DefaultSquare;
                square.RotateFlip(RotateFlipType.Rotate90FlipX);
                return square;
            }
        }

        internal static Bitmap CenterSquare
        {
            get
            {
                string fullPath = Path + "center_square.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }

        internal static Bitmap GetTriangleSquare(CardinalDirection rotate, bool flipX, bool flipY)
        {
            Bitmap defaultSquare = GetDefaultSquare(rotate);
            Bitmap triangle = GetTriangleFlag(rotate, flipX, flipY);

            Bitmap result = ImageEditor.AddImages(defaultSquare, triangle);

            return result; 
        }

        internal static Bitmap GetTriangleFlag(CardinalDirection direction, bool flipX, bool flipY)
        {
            return ImageEditor.RotateFlip(TriangleFlag, direction, flipX, flipY);
        }

        internal static Bitmap TriangleFlag
        {
            get
            {
                string fullPath = Path + "triangle.png";
                return (Bitmap)Image.FromFile(fullPath); 
            }
        }

        internal static Bitmap GetGoalSquare(CardinalDirection direction)
        {
            if (direction == CardinalDirection.North || direction == CardinalDirection.South)
            {
                return GoalSquare;
            }
            else if (direction == CardinalDirection.East || direction == CardinalDirection.West)
            {
                return GoalSquareRotated;
            }
            else
                throw new Exception();
        }

        internal static Bitmap GoalSquare
        {
            get
            {
                string fullPath = Path + "goal_square.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }

        internal static Bitmap GoalSquareRotated
        {
            get
            {
                Bitmap square = GoalSquare;
                square.RotateFlip(RotateFlipType.Rotate90FlipX);
                return square;
            }
        }

        internal static Bitmap Background
        {
            get
            {
                string fullPath = Path + "background.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }

        public static Bitmap GetCornerSquare(CardinalDirection direction)
        {
            if (direction == CardinalDirection.North || direction == CardinalDirection.South)
                return CornerSquare;

            else if (direction == CardinalDirection.East || direction == CardinalDirection.West)
                return CornerSquareRotated;

            else
                throw new Exception();
        }

        internal static Bitmap CornerSquare
        {
            get
            {
                string fullPath = Path + "corner_square.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }

        internal static Bitmap CornerSquareRotated
        {
            get
            {
                Bitmap square = CornerSquare;
                square.RotateFlip(RotateFlipType.Rotate90FlipX);
                return square;
            }
        }
    }
}
