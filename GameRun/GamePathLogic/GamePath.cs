using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRun.GamePathLogic.Squares;

namespace GameRun.GamePathLogic
{
    public class GamePath
    {
        private readonly int DEFAULT_STEP_TIME = 250;

        private Square start;
        private Square end;
        private readonly Square[,] gamePieces;
        private Square[] pieceStartSquares;
        private Square[] assistantList;

        // Retorna referencias: Esta propieda debe retornar Copias de los objetos reales.
        public Square[,] GamePiecesState { get { return (Square[,]) gamePieces.Clone(); } }
        // Retorna referencias: Esta propieda debe retornar Copias de los objetos reales.
        public Square[] GamePathState
        {
            get
            {
                if (IsClosed) 
                    return (Square[]) assistantList.Clone();
                else 
                    throw new Exception("Para obtener el estado de Recorrido es necesario primero Cerrarlo. El Recorrido probablemente aún esta en construcción.");       
            }
        }
        public SerializableSquare[] SerializableGamePath
        {
            get
            {
                Square[] gamePath = GamePathState;
                SerializableSquare[] serializableGamePath = new SerializableSquare[gamePath.Length];

                for (int i = 0; i < serializableGamePath.Length; i++)
                {
                    serializableGamePath[i] = new SerializableSquare();
                    serializableGamePath[i].Fill(gamePath[i]);
                }

                return serializableGamePath;
            }
        }
        public List<Elements.PieceMovement> Steps { get; private set; } = new List<Elements.PieceMovement>();
        public int Count { get; private set; } = 0;
        internal bool IsClosed { get; private set; } = false;
        

        internal Square this[int index]
        {
            get
            {
                if (IsClosed) 
                    return assistantList[index];
                else 
                    throw new Exception("Para utilizar el indexador del Recorrido es necesario primero Cerrarlo. El Recorrido probablemente aún esta en construcción.");
            }
        }

        public GamePath(int playerQuantity, int gamePieceQuantity)
        {
            gamePieces = new Square[playerQuantity, gamePieceQuantity];
        }

        #region Metodos

        internal void AddSquare(Square square)
        {
            if (!IsClosed)
            {
                if (square == null) throw new Exception("Se intentó agregar una casilla Null al recorrido del juego.");

                if (start == null) start = square;
                else end.Next = square;
                end = square;

                Count++;
            }
            else throw new Exception("El Recorrido ya esta cerrado. No es posible agregar mas Casillas en él.");
        }

        internal void AddSquare(Square[] squares)
        {
            for (int i = 0; i < squares.Length; i++)
            {
                AddSquare(squares[i]);
            }
        }

        internal void SetPieceStartSquares(Square[] squares)
        {
            if(!IsClosed)
            {
                if (squares.Length == gamePieces.GetLength(0))
                {
                    pieceStartSquares = squares;
                }
                else throw new Exception("Falló al intentar asignar las Casillas de Inicio de las Fichas. " +
                    "El número de Casillas de Inicio no es igual a la Cantidad de Jugadores.");
            }
        }

        public bool CanStartPiece(int player)
        {
            return !pieceStartSquares[player].IsOccupied;
        }

        internal void CloseConstruction()
        {
            if (!IsClosed)
            {
                if (Count != 0)
                {
                    List<Square> listTemp = new List<Square>();

                    Square current = start;

                    for (int i = 0; i < Count; i++)
                    {
                        listTemp.Add(current);
                        current = current.Next;
                    }

                    assistantList = listTemp.ToArray();

                    // Se cierra el recorrido. Es decir se vuelve circular.
                    end.Next = start;
                    IsClosed = true;
                }
            }
        }

        internal void AddPiece(int player, int piece)
        {
            if (!IsClosed) throw new Exception("Para agregar una Ficha en el Recorrido es necesario primero Cerrarlo. El Recorrido probablemente aún esta en construcción.");
            if (pieceStartSquares == null) throw new Exception("Para agregar una Ficha en el Recorrido primero se deben especificar las Casillas de Inicio.");

            try
            {
                Square square = pieceStartSquares[player];

                if (square.IsOccupied) throw new Exception("Se intentó agregar una Ficha de Jugador en un Casilla ocupada.");

                if (gamePieces[player, piece] != null) throw new Exception("Se intentó agregar una Ficha de Jugador ya existente en la Partida.");

                gamePieces[player, piece] = square;
                square.IsOccupied = true;
                square.PlayerPiece = new Elements.Point(player, piece);
            }
            catch (Exception e)
            {
                throw new Exception($"No se pudo agregar el apuntador de la Ficha {piece} del Jugador {player} en el Recorrido de la Partida.\n" + e.Message);
            }
        }

        internal void RemovePiece(int player, int piece)
        {
            try
            {
                if (gamePieces[player, piece] != null)
                {
                    gamePieces[player, piece].IsOccupied = false;
                    gamePieces[player, piece].PlayerPiece = null;
                    gamePieces[player, piece] = null;
                }
            }
            catch (Exception e)
            {
                throw new Exception($"No se pudo eliminar el apuntador de la ficha {piece} del jugador {player} en el recorrido de la partida.\n" + e.Message);
            }
        }

        internal bool TryMovePiece(int player, int piece, int steps)
        {
            if (gamePieces[player, piece] == null) throw new Exception("Se intento mover un Ficha que no existe.");

            ClearSteps();

            //------Se-busca-la-casilla------

            Square current = gamePieces[player, piece];

            for (int i = 0; i < steps; i++)
            {
                current = current.Next;

                Elements.PieceMovement step = new Elements.PieceMovement(current.Center(Elements.GamePiece.WIDTH, Elements.GamePiece.HEIGHT), DEFAULT_STEP_TIME);
                Steps.Add(step);
            }

            Square targetSquare = current;

            //-----Ejecutar-las-acciones-----

            bool canMove = targetSquare.ExecuteActions();

            //--------Mover-la-ficha---------

            if (canMove)
            {
                MovePiece(player, piece, targetSquare);
            }

            return canMove;
        }

        private void MovePiece(int player, int piece, Square square)
        {
            if (gamePieces[player, piece] == null) throw new Exception("Se intento mover un ficha que no existe.");

            gamePieces[player, piece].IsOccupied = false;
            gamePieces[player, piece].PlayerPiece = null;

            gamePieces[player, piece] = square;

            gamePieces[player, piece].IsOccupied = true;
            gamePieces[player, piece].PlayerPiece = new Elements.Point(player, piece);

        }

        internal void ClearSteps()
        {
            Steps.Clear();
        }

        #endregion


        }
}
