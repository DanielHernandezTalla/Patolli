using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.GamePathLogic
{
    internal interface IGamePathBuilder
    {
        int PlayersQuantity { get; set; }
        int PlayerPiecesQuantity { get; set; }
        int BladeSize { get; set; }
        Actions.Receiver Receiver { get; set; }

        void Create();

        void BuildSquares();
        void BuildLocations();

        GamePath GetResult();
    }
}
