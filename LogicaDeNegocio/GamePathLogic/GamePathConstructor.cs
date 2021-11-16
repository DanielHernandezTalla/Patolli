using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.GamePathLogic
{
    internal class GamePathConstructor 
    {
        private IGamePathBuilder builder;
        private GamePath result;

        internal void SetBuilder(IGamePathBuilder builder)
        {
            this.builder = builder;
        }

        internal void Construct(int playersQuantity, int playerPiecesQuantity, int squaresQuantity, Actions.Receiver receiver)
        {
            builder.PlayersQuantity = playersQuantity;
            builder.PlayerPiecesQuantity = playerPiecesQuantity;
            builder.BladeSize = squaresQuantity;
            builder.Receiver = receiver;

            builder.Create();
            builder.BuildSquares();
            builder.BuildLocations();

            result = builder.GetResult();
        }

        internal GamePath GetResult()
        {
            return result;
        }
    }
}
