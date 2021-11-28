using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Eventos;
using Presentacion.Controller;
using Controles.BoardControl;
using Controles.CañasThrowerControl;
using Controles.TurnsControl;
using Entidades.Game;
using Presentacion.User;

namespace Presentacion.Forms
{
    public partial class PlayerGameForm : Form, Eventos.Game.IGameable
    {
        private readonly FormsController controller;

        private readonly Board Board;
        private readonly CañasThrower CañasThrower;
        private readonly TurnsInfo TurnsInfo;

        // Campos para el turno actual

        private Entidades.Connection.User currentTurn;
        private bool isMyTurn;

        public PlayerGameForm()
        {
            // Creación del tablero
            Board = new Board();
            Board.MinimumSize = new Size(Board.BOARD_SIZE, Board.BOARD_SIZE);
            Board.MaximumSize = new Size(Board.BOARD_SIZE, Board.BOARD_SIZE);
            Board.Size = new Size(Board.BOARD_SIZE, Board.BOARD_SIZE);
            Board.BorderStyle = BorderStyle.Fixed3D;

            // Creación del CañaThrower
            CañasThrower = new CañasThrower();
            CañasThrower.MinimumSize = new Size(CañasThrower.THROWER_WIDTH, CañasThrower.THROWER_HEIGHT);
            CañasThrower.Size = new Size(CañasThrower.THROWER_WIDTH, CañasThrower.THROWER_HEIGHT);
            CañasThrower.AddButtonListener(this.CañasThrowerControl_Click);

            // Creando un arreglo de StatePlayer para prueba
            Piece[] pieces = new Piece[3];
            pieces[0] = new Piece() { IsAlive = true };
            pieces[1] = new Piece() { IsAlive = false };
            pieces[2] = new Piece() { IsAlive = true };
            
            Piece[] pieces2 = new Piece[3];
            pieces2[0] = new Piece() { IsAlive = false };
            pieces2[1] = new Piece() { IsAlive = true };
            pieces2[2] = new Piece() { IsAlive = false };
            
            StatePlayer[] statePlayer = new StatePlayer[2];
            statePlayer[0] = new StatePlayer()
            {
                User = new Entidades.Connection.User() { Name = "Daniel", Number = 500 },
                Pieces = pieces,
                IsMyTurn = false
            };
            statePlayer[1] = new StatePlayer()
            {
                User = new Entidades.Connection.User() { Name = "Missael", Number = 250 },
                Pieces = pieces2,
                IsMyTurn = true
            };

            // Creación del TurnsInfo
            TurnsInfo = new TurnsInfo();
            TurnsInfo.ShowData(statePlayer);

            InitializeComponent();

            // Establecer tamaños minimos y tamaños por defecto de los paneles contenedores.
            this.MinimumSize = new Size(1320, 740);

            panBackground.Size = new Size(panBackground.Size.Width, 700);

            panBoard.MinimumSize = new Size(panBoard.Size.Width, 700);
            panBoard.Size = new Size(panBoard.Size.Width, 700);

            // Centrar Board
            CenterControl(panBoard, Board);

            // Centrar CañaThrower
            CenterControl(panControls, CañasThrower);
            CañasThrower.Location = new Point(CañasThrower.Location.X, panControls.Height - CañasThrower.Height - 30);

            // Agregar controles.
            panBoard.Controls.Add(Board);
            panControls.Controls.Add(CañasThrower);
            panTurnsInfo.Controls.Add(TurnsInfo);

            controller = Session.FormsController;
        }

        private void CenterControl(Control c1, Control c2)
        {
            int x = (c1.Width / 2) - (c2.Width / 2);
            int y = (c1.Height / 2) - (c2.Height / 2);

            c2.Location = new Point(x, y);
        }

        private void UpdateTurn(Entidades.Connection.User user, bool isMyTurn)
        {
            // Actualizar el control de informacion de turno..
            Text = $"Turno de: {user.Name}";

            // Actualizar el control de cañas
            CañasThrower.ClearCañas();
            CañasThrower.SetEnable(isMyTurn);
        }

        private void DelegatedUpdateTurn(Entidades.Connection.User user, bool isMyTurn)
        {
            if (this.InvokeRequired)
            {
                UpdateTurnDelegate delegado = new UpdateTurnDelegate(UpdateTurn);
                this.Invoke(delegado, user, isMyTurn);
            }
                
        }

        public delegate void UpdateTurnDelegate(Entidades.Connection.User user, bool isMyTurn);

        #region Eventos del juego

        // Eventos a lanzar

        public void StartGame()
        {
            controller.NotifyClient(new UserEvents.StartGameEvent());
        }

        public void ThrownCañas()
        {
            controller.NotifyClient(new UserEvents.ThrownCañasEvent(CañasThrower.Cañas));
        }

        public void ExecuteTurn()
        {
            controller.NotifyClient(new UserEvents.ExecuteTurnEvent(CañasThrower.Result));
        }

        // Eventos recibidos

        public void NumbersAssigned(Event e)
        {
            List<Entidades.Connection.User> users = Transporte.Serialization.Serialize.JobjToObject<List<Entidades.Connection.User>>(e.Data);

            // Se actualiza la lista de usuarios con sus respectivos numeros identificadores.
            Session.Users = users;
        }

        public void YourNumberAssigned(Event e)
        {
            int myNumber = Transporte.Serialization.Serialize.JobjToObject<int>(e.Data);

            // Se actualiza mi numero identificador.
            Session.MyUser.Number = myNumber;
        }

        public void GameCreated(Event e)
        {
            Entidades.Game.Square[] gamePath = Transporte.Serialization.Serialize.JobjToObject<Entidades.Game.Square[]>(e.Data);
            Board.SetGamePath(gamePath);

            // Nueva peticion. Solo el servidor la mandará.
            if(Session.Role == Session.SessionRole.Server)
            {
                StartGame();
            }
        }

        public void TurnChanged(Event e)
        {
            Entidades.Connection.User userTurn = Transporte.Serialization.Serialize.JobjToObject<Entidades.Connection.User>(e.Data);

            // Actualizamos el turno actual.
            currentTurn = userTurn;

            // Se verefica si es mi turno.
            if (Session.MyUser.Name.Equals(userTurn.Name))
            {
                if (Session.MyUser.Number == userTurn.Number)
                {
                    isMyTurn = true;
                    DelegatedUpdateTurn(userTurn, true);
                    return;
                }
            }

            isMyTurn = false;
            DelegatedUpdateTurn(userTurn, false);
        }

        public void ThrownCañas(Event e)
        {
            if (!isMyTurn)
            {
                bool[] thrownCañas = Transporte.Serialization.Serialize.JobjToObject<bool[]>(e.Data);

                CañasThrower.SetCañas(thrownCañas);
            }

            // Nueva peticion. Solo el servidor la mandará.
            if (Session.Role == Session.SessionRole.Server)
            {
                ExecuteTurn();
            }
        }

        public void PieceStarted(Event e)
        {
            Piece piece = Transporte.Serialization.Serialize.JobjToObject<Piece>(e.Data);

            Controles.ShowMessageControl.Show(e.Description, "Avisó", 500);

            Text = e.Description;
        }

        public void PieceMoved(Event e)
        {
            throw new NotImplementedException();
        }



        #endregion

        #region Eventos del form

        private void PlayerGameForm_SizeChanged(object sender, EventArgs e)
        {
            if (Board != null)
                CenterControl(panBoard, Board);
        }

        private void PlayerGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        public void CañasThrowerControl_Click(object sender, EventArgs e)
        {
            if(CañasThrower.CañasThrown)
            {
                ThrownCañas();
                CañasThrower.CañasThrown = false;
            }
            
        }

        #endregion


    }
}
