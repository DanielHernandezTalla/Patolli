using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.Turns
{
    public class PlayerTurn : Turn
    {
        private TurnList pieceTurns = new TurnList();

        public Elements.Player Player { get; private set; }
        public PieceTurn CurrentPieceTurn { get { return (PieceTurn)pieceTurns.GetCurrent(); } }

        public PlayerTurn(Elements.Player player)
        {
            Player = player;
        }

        public PlayerTurn(Elements.Player player, bool isTemporal)
        {
            Player = player;
            IsTemporal = isTemporal;
        }

        internal void UpdatePieceTurn()
        {
            if(pieceTurns.Count > 0)
            {
                pieceTurns.NextTurn();
                CurrentPieceTurn.IsReady = true;
            }
        }

        internal void AddPieceTurn(Elements.GamePiece piece)
        {
            for (int i = 0; i < pieceTurns.Count; i++)
            {
                if (pieceTurns.Exists(turn => ((PieceTurn)turn).GamePiece == piece))
                {
                    throw new Exception("Se intentó agregar un turno de Ficha ya existente. Si se desea agregar otro turno de ficha" +
                        "para este misma ficha es necesario hacerlo mediante un Turno Especial.");
                }
            }

            PieceTurn pieceTurn = new PieceTurn(piece);
            pieceTurns.Add(pieceTurn);
        }

        internal void AddSpecificTurn(Elements.GamePiece piece)
        {
            AddSpecificPieceTurn specialTurn = new AddSpecificPieceTurn(pieceTurns);
            specialTurn.Piece = piece;
            specialTurn.Attach();
        }

        internal void CopyPieceTurns(PlayerTurn playerTurn)
        {
            playerTurn.pieceTurns = this.pieceTurns;
        }
    }
}
