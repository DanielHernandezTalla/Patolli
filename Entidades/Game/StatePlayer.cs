using Entidades.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Game
{
    public class StatePlayer
    {
        public User User;
        public Piece[] Pieces;
        public bool IsMyTurn;
    }
}
