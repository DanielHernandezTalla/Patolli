using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Connection
{
    public class User
    {
        public int Number { get; set; }

        public string Name { get; set; }

        public void Fill(GameRun.Elements.Player player)
        {
            Name = player.Name;
            Number = player.PlayerNumber;
        }

        // Este enum es una copia de un enum con el mismo nombre que se encuentra en GameRun.Elements.Player
        public enum PlayerColor
        {
            Red,
            Blue,
            Yellow,
            Green
        }
    }
}
