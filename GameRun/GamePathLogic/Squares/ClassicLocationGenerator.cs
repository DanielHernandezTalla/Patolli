using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRun.Elements;

namespace GameRun.GamePathLogic.Squares
{
    class ClassicLocationGenerator : LocationGenerator
    {
        public Point Center { get; set; } = new Point(344, 344); //60, 35
        public int Separation { get; set; } = 1; // 0
        public bool IsClockwise { get; set; } = false;

        public override void GenerateLocations(GamePath gamePath)
        {
            try
            {
                Generator generator = new Generator(Center, Separation, CardinalDirection.East);
                
                // El primer paso se da conciderando que inicias en una casilla tipo Center.
                generator.XMove = Square.WIDTH;
                generator.YMove = Square.WIDTH;

                generator.MoveForward();

                for (int i = 0; i < gamePath.Count; i++)
                {
                    // Se asigna la locación actual.
                    gamePath[i].Location = generator.CurrentLocation;

                    // Se ajusta la dirección del movimiento.
                    switch (gamePath[i].Type)
                    {
                        case Square.SquareType.Corner:
                            generator.TurnLeft();
                            break;

                        case Square.SquareType.Center:
                            generator.TurnRight();
                            break;
                    }

                    // Si la direccion de movimiento es hacia arriba o izquirda: El tipo de movimiento
                    // corresponderá a la siguiente casilla, si es que la hay.
                    // Si no: El tipo de movimiento será correspondiente a la casilla actual.
                    if (generator.Direction == CardinalDirection.North || generator.Direction == CardinalDirection.West)
                    {
                        if(i + 1 < gamePath.Count)
                        {
                            generator.XMove = gamePath[i + 1].RelativeWidth;
                            generator.YMove = gamePath[i + 1].RelativeHeight;
                        }
                    }
                    else
                    {
                        generator.XMove = gamePath[i].RelativeWidth;
                        generator.YMove = gamePath[i].RelativeHeight;
                    }

                    // Realiza movimiento.
                    generator.MoveForward();
                }
            }
            catch(Exception e)
            {
                throw new Exception("Algo falló al intentar generar la Locaciones de las Casillas del Recorrido.\n" + e.Message);
            }
        }
    }

    class Generator
    {
        internal Point CurrentLocation { get; private set; }
        internal CardinalDirection Direction { get; private set; }

        public int XMove { get; set; } = Square.WIDTH; // 7
        public int YMove { get; set; } = Square.HEIGHT; // 4
        public int Separation { get; set; } = 0; // 0

        public Generator(Point start, int separation, CardinalDirection startDirection)
        {
            CurrentLocation = start;
            Separation = separation;

            Direction = startDirection;
        }

        public void MoveForward()
        {
            int x = CurrentLocation.X;
            int y = CurrentLocation.Y;
            int fx, fy;

            switch(Direction)
            {
                case CardinalDirection.North:
                    fx = x;
                    fy = y - YMove - Separation;
                    break;

                case CardinalDirection.East:
                    fx = x + XMove + Separation;
                    fy = y;
                    break;

                case CardinalDirection.South:
                    fx = x;
                    fy = y + YMove + Separation;
                    break;

                case CardinalDirection.West:
                    fx = x - XMove - Separation;
                    fy = y;
                    break;

                default:
                    throw new Exception("Direccion cardinal no valida.");
            }  

            CurrentLocation = new Point(fx, fy);
        }

        public void TurnLeft()
        {
            if((Direction - 1) < 0)
                Direction = CardinalDirection.West;
            else 
                Direction -= 1;
        }

        public void TurnRight()
        {
            if ((int)(Direction + 1) > 3)
                Direction = CardinalDirection.North;
            else
                Direction += 1;
        }

    }
}
