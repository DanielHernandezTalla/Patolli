using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Game
{
    public class GameSettings
    {
        public int PlayersQuantity { get; set; }
        public int PiecesQuantity { get; set; }
        public int BladeSize { get; set; }
        public List<Connection.User> Users { get; set; }
        public int CreditAmount { get; set; }
        public int BetAmount { get; set; }
    }
}
