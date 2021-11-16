using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDeNegocio.GamePathLogic.Squares
{
    abstract class LocationGenerator
    {
        abstract public void GenerateLocations(GamePath gamePath);
    }
}
