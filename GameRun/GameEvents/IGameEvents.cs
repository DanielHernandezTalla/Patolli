using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.GameEvents
{
    public interface IGameEvents
    {
        void GameCreated(GameCreatedEvent e);

        void TurnChanged(TurnChangedEvent e);

        void PieceMoved(PieceMovedEvent e);
    }
}
