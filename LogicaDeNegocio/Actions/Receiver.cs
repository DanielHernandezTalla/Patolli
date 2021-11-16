using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.GamePathLogic.Squares;

namespace LogicaDeNegocio.Actions
{
    public class Receiver
    {
        private readonly Game game;

        public Receiver(Game game)
        {
            this.game = game;
        }

        internal bool RollAgain(ISquareState targetSquare)
        {
            return true;
            throw new NotImplementedException();
        }

        internal bool PayBet(ISquareState targetSquare)
        {
            return true;
            throw new NotImplementedException();
        }

        internal bool MoveBack(ISquareState targetSquare)
        {
            if(targetSquare.IsOccupied)
            {
                // agregar un nuevo Step a la lista de Locations...
                return false;
            }

            return true;
        }

        internal bool EatPiece(ISquareState targetSquare)
        {
            return true;
            throw new NotImplementedException();
        }
    }
}
