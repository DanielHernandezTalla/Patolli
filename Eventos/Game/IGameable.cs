using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Game
{
    public interface IGameable
    {
        void GameCreated(Event e);

        void TurnChanged(Event e);

        void PieceMoved(Event e);
    }
}
