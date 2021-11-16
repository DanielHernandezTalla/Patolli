using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Elements;

namespace LogicaDeNegocio.Turns
{
    public class TurnsController //TEST es internal
    {
        // Se supone que no debe haber dos instancias identicas en memoria 
        // dentro de la playerTurns porque puede fallar.
        public readonly TurnList playerTurns = new TurnList(); //TEST es private
        private readonly Throwers.IThrower thrower;
        private PlayerTurn CurrentPlayerTurn { get { return (PlayerTurn)playerTurns.GetCurrent(); } }
        public bool PlayerTurnIsReady { get { return CurrentPlayerTurn.IsReady; } }
        public bool PieceTurnIsReady { get { return CurrentPlayerTurn.CurrentPieceTurn.IsReady; } }

        public TurnsController(Throwers.IThrower thrower)
        {
            this.thrower = thrower;
        }


        public void AddPlayerTurn(Player player)//TEST es internal
        {
            for (int i = 0; i < playerTurns.Count; i++)
            {
                if (playerTurns.Exists(turn => ((PlayerTurn)turn).Player == player))
                {
                    throw new Exception("Ya se agregó un turno para este Jugador. Si se desea agregar otro turno " +
                        "para este jugador es necesario hacerlo mediante un Turno Especial.");
                }
            }

            PlayerTurn playerTurn = new PlayerTurn(player);
            playerTurns.Add(playerTurn);
        }

        internal void AddExtraTurn(Player player)
        {
            AddExtraTurn specialTurn = new AddExtraTurn(playerTurns);
            specialTurn.Player = player;
            specialTurn.Attach();
        }

        internal void AddPieceTurn(GamePiece piece)
        {
            if(CurrentPlayerTurn != null && CurrentPlayerTurn.Player.Contains(piece))
            {
                CurrentPlayerTurn.AddPieceTurn(piece);
            }
        }

        internal void AddSpecificPieceTurn(GamePiece piece)
        {
            if (CurrentPlayerTurn != null)
            {
                CurrentPlayerTurn.AddSpecificTurn(piece);
            }
        }

        public void RemovePlayer(Player player)//TEST es internal
        {
            playerTurns.RemoveAll(playerTurn => ((PlayerTurn)playerTurn).Player == player);
        }
     
        internal void UpdatePlayerTurn()
        {
            if(CurrentPlayerTurn == null || !CurrentPlayerTurn.IsReady)
            {
                playerTurns.NextTurn();
                CurrentPlayerTurn.IsReady = true;

                thrower.IsEnable = true;
            }      
        }

        internal void UpdatePieceTurn()
        {
            if(CurrentPlayerTurn.IsReady)
                CurrentPlayerTurn.UpdatePieceTurn();
        }

        internal Player GetCurrentPlayerTurn()
        {
            if (CurrentPlayerTurn != null) 
                return CurrentPlayerTurn.Player;
            else 
                return null;
        }

        internal GamePiece GetCurrentPieceTurn()
        {
            if (CurrentPlayerTurn != null)
                if (CurrentPlayerTurn.CurrentPieceTurn != null)
                    return CurrentPlayerTurn.CurrentPieceTurn.GamePiece;

            return null;
        }

        public bool TurnIsReady()
        {
            return (CurrentPlayerTurn != null && CurrentPlayerTurn.IsReady) &&
                (CurrentPlayerTurn.CurrentPieceTurn != null && CurrentPlayerTurn.CurrentPieceTurn.IsReady);
        }

        public void ClearTurn()
        {
            if(CurrentPlayerTurn != null)
            {
                CurrentPlayerTurn.IsReady = false;

                if (CurrentPlayerTurn.CurrentPieceTurn != null)
                    CurrentPlayerTurn.CurrentPieceTurn.IsReady = false;
            }  
        }

    }
}
