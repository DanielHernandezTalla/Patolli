using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Game;
using Entidades;

namespace Controles.BoardControl
{
    struct BoardImages
    {
        private static string Path
        {
            get
            {
                return "..\\..\\resources\\board\\";
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
                    return GetTriangleSquare(direction, square.FlipX, square.FlipY);

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
                string fullPath = Path + "board_background.png";
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

        internal static Bitmap GetPiece(Entidades.Connection.User.PlayerColor color)
        {
            if (color == Entidades.Connection.User.PlayerColor.Red)
                return RedPiece;

            else if (color == Entidades.Connection.User.PlayerColor.Blue)
                return BluePiece;

            else if (color == Entidades.Connection.User.PlayerColor.Green)
                return GreenPiece;

            else if (color == Entidades.Connection.User.PlayerColor.Yellow)
                return YellowPiece;

            throw new Exception("No se encontro el color de la ficha en BoardImages.");
        }

        internal static Bitmap RedPiece
        {
            get
            {
                string fullPath = Path + "piece_red.png";
                return ((Bitmap)Image.FromFile(fullPath));
            }
        }
        internal static Bitmap BluePiece
        {
            get
            {
                string fullPath = Path + "piece_blue.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }
        internal static Bitmap GreenPiece
        {
            get
            {
                string fullPath = Path + "piece_green.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }
        internal static Bitmap YellowPiece
        {
            get
            {
                string fullPath = Path + "piece_yellow.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }
    }
}
