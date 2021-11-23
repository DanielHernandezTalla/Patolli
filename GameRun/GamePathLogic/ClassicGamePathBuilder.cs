using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRun.Actions;
using GameRun.GamePathLogic.Squares;

namespace GameRun.GamePathLogic
{
    internal class ClassicGamePathBuilder : IGamePathBuilder
    {
        private GamePath gamePath;

        public int PlayersQuantity { get; set; } = Game.MINIMUM_PLAYERS_QUANTITY;
        public int PlayerPiecesQuantity { get; set; } = Game.MINIMUM_PLAYER_PIECES_QUANTITY;
        public int BladeSize { get; set; } = Game.MINIMUM_BLADE_SIZE;
        public Receiver Receiver { get; set; }   

        public void Create()
        {
            gamePath = new GamePath(PlayersQuantity, PlayerPiecesQuantity); 
        }

        public void BuildSquares()
        {
            if (gamePath == null) throw new Exception("Se intentó construir las Casillas del GamePath sin crear el objeto antes.");
            if (Receiver == null) throw new Exception("Se intentó construir el GamePath sin especificar su Receiver.");

            ResizableBladeFactory bladeFactory = new ResizableBladeFactory(Receiver, BladeSize);
            CenterSquaresFactory centerFactory = new CenterSquaresFactory(Receiver);

            // Agregar 4 veces un Aspa y un Centro para formar el tablero Clasico.
            for (int i = 0; i < 4; i++)
            {
                // Verifica la cantidad de jugadores especificados para asignar o no un GoalSquare en el Aspa.
                if(PlayersQuantity == 2 && (i == 0 || i == 2))
                    bladeFactory.HasStartSquare = true;
                else if (PlayersQuantity != 2 && i < PlayersQuantity)
                    bladeFactory.HasStartSquare = true;

                // Crea las casillas del Aspa y la casilla Centro.
                Square[] blade = bladeFactory.FactoryMethod();
                Square[] centerSquare = centerFactory.FactoryMethod();

                // Asigna la dirección cardinal del Aspa y los Flips correspondientes de las Casillas Triangulo. 
                switch(i)
                {
                    case 0: 
                        Square.SetSquareDirections(blade, Elements.CardinalDirection.East);
                        TriangleSquare.SetSquareFlips(blade, Elements.CardinalDirection.East);
                        break;

                    case 1: 
                        Square.SetSquareDirections(blade, Elements.CardinalDirection.North);
                        TriangleSquare.SetSquareFlips(blade, Elements.CardinalDirection.North);
                        break;
                    case 2: 
                        Square.SetSquareDirections(blade, Elements.CardinalDirection.West);
                        TriangleSquare.SetSquareFlips(blade, Elements.CardinalDirection.West);
                        break;
                    case 3: 
                        Square.SetSquareDirections(blade, Elements.CardinalDirection.South);
                        TriangleSquare.SetSquareFlips(blade, Elements.CardinalDirection.South);
                        break;
                }

                // Añade las casillas.
                gamePath.AddSquare(blade);
                gamePath.AddSquare(centerSquare);

                bladeFactory.HasStartSquare = false;
            }

            gamePath.SetPieceStartSquares(bladeFactory.GetStartSquares());
            gamePath.CloseConstruction();
        }

        public void BuildLocations()
        {
            if (gamePath == null) throw new Exception("Se intentó construir las Casillas del GamePath sin crear el objeto antes.");

            ClassicLocationGenerator generator = new ClassicLocationGenerator();

            generator.GenerateLocations(gamePath);
        }

        public GamePath GetResult()
        {
            return gamePath;
        }
    }
}
