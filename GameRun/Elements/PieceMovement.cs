using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.Elements
{
    public class PieceMovement
    {
        public Point Location { get; internal set; }
        public int Time { get; internal set; }

        public PieceMovement(Point location, int time)
        {
            Location = location;
            Time = time;
        }
    }
}
