using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRun.GamePathLogic;
using GameRun.Elements;
using GameRun.Actions;
using GameRun.Turns;
using GameRun.Throwers;
using GameRun.GamePathLogic.Squares;
using GameRun.GameEvents;

namespace GameRun
{
    public class Game
    {
        #region constantes
        public const int MINIMUM_PLAYERS_QUANTITY = 2;
        public const int MAXIMUM_PLAYERS_QUANTITY = 4;
        public const int MINIMUM_PLAYER_PIECES_QUANTITY = 2;
        public const int MAXIMUM_PLAYER_PIECES_QUANTITY = 6;
        /// <summary>
        /// Cantidad minima de Casillas por lado de Aspa del Recorrido del tablero.
        /// </summary>
        public const int MINIMUM_BLADE_SIZE = 4;
        /// <summary>
        /// Cantidad maxima de Casillas por lado de Aspa del Recorrido del tablero.
        /// </summary>
        public const int MAXIMUM_BLADE_SIZE = 7;
        private const int START_PIECE_VALUE = 1;
        #endregion

        #region propiedades

        // Propiedades de configuración de partida
        public int PlayersQuantity 
        {
            get
            {
                return playersQuantity;
            }
            private set
            {
                if (value >= MINIMUM_PLAYERS_QUANTITY && value <= MAXIMUM_PLAYERS_QUANTITY)
                    playersQuantity = value;
                else
                    throw new Exception("Se intentó establecer un valor mayor o menor de la cantidad maximas o minimas de Jugadores.");
            }
        }
        private int playersQuantity = MINIMUM_PLAYERS_QUANTITY;
        public int PlayerPiecesQuantity
        {
            get
            {
                return playerPiecesQuantity;
            }
            private set
            {
                if (value >= MINIMUM_PLAYER_PIECES_QUANTITY && value <= MAXIMUM_PLAYER_PIECES_QUANTITY)
                    playerPiecesQuantity = value;
                else
                    throw new Exception("Se intentó establecer un valor mayor o menor de la cantidad maximas o minimas de Fichas por Jugador.");
            }
        }
        private int playerPiecesQuantity = MINIMUM_PLAYER_PIECES_QUANTITY;
        public int BladeSize
        {
            get
            {
                return bladeSize;
            }
            set
            {
                if (value >= MINIMUM_BLADE_SIZE && value <= MAXIMUM_BLADE_SIZE)
                    bladeSize = value;
                else
                    throw new Exception("Se intentó establecer un valor mayor o menor de la cantidad maximas o minimas de Casillas de la partida.");
            }
        }
        private int bladeSize = MINIMUM_BLADE_SIZE;
        public Player.PlayerColor[] PlayerColors { get; set; } = new Player.PlayerColor[]
        {
            Player.PlayerColor.Red,
            Player.PlayerColor.Blue,
            Player.PlayerColor.Yellow,
            Player.PlayerColor.Green
        };
        public string[] PlayerNames { get; set; } = new string[]
        {
            "Jugador 1",
            "Jugador 2",
            "Jugador 3",
            "Jugador 4"
        };

        // Propiedades de estado de partida
        public bool IsCreated { get; private set; }
        public bool IsStarted { get; private set; }

        // Componentes de la partida
        internal GamePath GamePath { get; private set; }
        public Player[] Players { get; private set; } 

        private Receiver Receiver { get; set; } 
        private CañaThower Thrower { get; set; }
        private TurnsController Turns { get; set; }

        // Estatus de la partida
        public GameStatus GameStatus { get; private set; }
        public List<Eventos.IObserver> GameObservers { get; set; } = new List<Eventos.IObserver>();

        #endregion

        private readonly Queue<GamePiece> gamePiecesToDraw = new Queue<GamePiece>();

        public Game()
        {

        }

        public Game(int playersQuantity, int playerPiecesQuantity)
        {
            PlayersQuantity = playersQuantity;
            PlayerPiecesQuantity = playerPiecesQuantity;
        }

        #region metodos
        public void Create()
        {
            if(!IsCreated)
            {
                // Crear los Jugadores.
                Players = new Player[PlayersQuantity];

                InitPlayers();

                // Crear el Receptor.
                Receiver = new Receiver(this);

                // Crear el Recorrido.
                GamePathConstructor constructor = new GamePathConstructor();

                constructor.SetBuilder(new ClassicGamePathBuilder());
                constructor.Construct(PlayersQuantity, PlayerPiecesQuantity, BladeSize, Receiver);
                GamePath = constructor.GetResult();

                // Crear el Lanzador.
                Thrower = new CañaThower();

                // Crear el Control de Turnos.
                Turns = new TurnsController(Thrower);

                for (int i = 0; i < Players.Length; i++)
                    Turns.AddPlayerTurn(Players[i]);

                // Crear el Game Status y asignar los interesados.
                GameStatus = new GameStatus();

                for (int i = 0; i < GameObservers.Count; i++)
                    GameStatus.Subscribe(GameObservers[i]);

                // El juego fue creado.
                IsCreated = true;

                // Se notifica a los interesados del evento.
                GameStatus.NotifyObservers(new GameCreatedEvent(GamePath.GamePathState));
            }
        }

        private void InitPlayers()
        {
            if (PlayerNames == null || PlayerNames.Length < PlayersQuantity) 
                throw new Exception("No se especificó correctamente los nombres de los jugadores al inicializarlos.");
            if (PlayerColors == null || PlayerColors.Length < PlayersQuantity)
                throw new Exception("No se especificó correctamente los colores de los jugadores al inicializarlos.");

            for (int i = 0; i < Players.Length; i++)
            {
                Players[i] = new Player(i, PlayerNames[i], PlayerColors[i], PlayerPiecesQuantity);

                for (int j = 0; j < Players[i].GamePieces.Length; j++)
                {
                    Players[i].GamePieces[j] = new GamePiece(j);
                }
            }
        }

        public void Start() 
        {
            if (IsCreated)
            {
                if(!IsStarted)
                {
                    NextTurn();

                    IsStarted = true;
                }
            }
            else throw new Exception("No es posible Empezar el juego sin antes Crearlo.");
        }

        public void Finish() { }

        private void NextTurn()
        {
            NextPlayerTurn();
        }

        private void NextPlayerTurn()
        {
            Turns.UpdatePlayerTurn();

            GameStatus.NotifyObservers(new TurnChangedEvent(Turns.GetCurrentPlayerTurn()));
        }

        public bool ExecuteTurn(int steps)
        {
            if (Turns.PlayerTurnIsReady)
            {
                // Inicializar nueva ficha si es el caso.
                if (steps == START_PIECE_VALUE)
                {
                    if (TryToStartPiece(Turns.GetCurrentPlayerTurn()))
                    {
                        Turns.ClearTurn();
                        NextTurn();
                        return true;
                    }
                }

                // Actualizar el turnos de la ficha. Si es que la hay.
                NextPieceTurn();

                // Intentar mover. Solo si hay un turno de player y turno de ficha listos.
                if (Turns.TurnIsReady())
                {
                    int player = Turns.GetCurrentPlayerTurn().PlayerNumber;
                    int piece = Turns.GetCurrentPieceTurn().PieceNumber;

                    GamePath.TryMovePiece(player, piece, steps);

                    UpdatePieceLocation(Turns.GetCurrentPieceTurn(), player, piece);
                }

                // Limpiar turno actual y avanzar al siguiente.
                Turns.ClearTurn();
                NextTurn();
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Intenta agregar un Ficha que no este inicializada del jugador especificado por parametro.
        /// Si encuentra una Ficha que no este inicializada le agrega un turno y lo añade al recorrido. 
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Retorna un bool que indica si es se pudo agregar una Ficha o no.</returns>
        private bool TryToStartPiece(Player player)
        {
            if(GamePath.CanStartPiece(player.PlayerNumber))
            {
                GamePiece[] pieces = player.GamePieces;

                for (int i = 0; i < pieces.Length; i++)
                {
                    if (pieces[i].PieceState == GamePiece.GamePieceState.NotInitialized)
                    {
                        int playerNum = Turns.GetCurrentPlayerTurn().PlayerNumber;

                        // Se añade la Ficha a los Turnos.
                        Turns.AddPieceTurn(pieces[i]);

                        // Se añade la Ficha a la Ruta de juego.
                        GamePath.AddPiece(playerNum, i);

                        // Se añade la Ficha a la cola de Fichas pendientes para Dibujar.
                        gamePiecesToDraw.Enqueue(pieces[i]);

                        // Se le asigna la locación a la Ficha.
                        UpdatePieceLocation(pieces[i], playerNum, i);

                        // Cambia el estado de la Ficha.
                        pieces[i].PieceState = GamePiece.GamePieceState.InGame;

                        return true;
                    }
                }
            }

            return false;
        }

        private void NextPieceTurn()
        {
            Turns.UpdatePieceTurn();
        }

        public void RemovePlayer(Player player)
        {
            Turns.RemovePlayer(player);
        }

        public void SpecificPieceTurn(GamePiece piece)
        {
            if(Turns.PlayerTurnIsReady && !Turns.PieceTurnIsReady)
            {
                Turns.AddSpecificPieceTurn(piece);
            }          
        }

        internal void RollAgain(Player player)
        {
            Turns.AddExtraTurn(player);
        }

        public Player GetTurn()
        {
            return Turns.GetCurrentPlayerTurn();
        }

        
        private void UpdatePieceLocation(GamePiece piece, int playerIndex, int pieceIndex)
        {
            Square[,] piecesInGame = GamePath.GamePiecesState;
            piece.Location = piecesInGame[playerIndex, pieceIndex].Location;
        }

        // Metodos para conocer si hay fichas lista para dibujar graficamente
        public bool ExistPiecesToDraw()
        {
            if (gamePiecesToDraw.Count > 0)
                return true;
            else
                return false;
        }

        public GamePiece GetGamePieceToDraw()
        {
            return gamePiecesToDraw.Dequeue();
        }


        public void AddGameObserver(Eventos.IObserver observer)
        {
            if(!IsCreated)
            {
                GameObservers.Add(observer);
            }
            else
            {
                GameObservers.Add(observer);
                GameStatus.Subscribe(observer);
            }
        }

        //------------TEST-------------

        public Square[] TESTGetGamePath()
        {
            return GamePath.GamePathState;
        }

        public Player[] TESTGetPlayerTurns()
        {
            Player[] players = new Player[Turns.playerTurns.Count];
            for (int i = 0; i < players.Length; i++)
            {
                players[i] = ((PlayerTurn)Turns.playerTurns[i]).Player;
            }
            return players;
        }

        public void TESTAddPiece(int player, int piece, int square)
        {
            //GamePath.AddPiece(player, piece, square);
        }

        public void TESTMovePiece(int player, int piece, int steps)
        {
            GamePath.TryMovePiece(player, piece, steps);
        }
        #endregion
    }
}
