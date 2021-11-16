using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.Elements
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public Point()
        {
            this.X = 0;
            this.Y = 0;
        }

        public override string ToString()
        {
            return "{" + X + ", " + Y + "}";
        }

    }
}
