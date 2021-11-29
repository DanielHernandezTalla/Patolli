using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Game
{
    public class PieceMovement
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Time { get; set; }

        public void Fill(GameRun.Elements.PieceMovement movement)
        {
            X = movement.Location.X;
            Y = movement.Location.Y;
            Time = movement.Time;
        }
    }
}
