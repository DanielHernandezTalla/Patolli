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
using Controles.CañaThrowerControl;
using Controles.TurnsControl;

namespace Presentacion.Forms
{
    public partial class PlayerGameForm : Form, Eventos.Game.IGameable
    {
        private readonly FormsController controller;

        private readonly Board Board;
        private readonly CañaThrower CañaThrower;
        private readonly TurnsInfo TurnsInfo;

        public PlayerGameForm()
        {
            // Creación del tablero
            Board = new Board();
            Board.MinimumSize = new Size(Board.BOARD_SIZE, Board.BOARD_SIZE);
            Board.MaximumSize = new Size(Board.BOARD_SIZE, Board.BOARD_SIZE);
            Board.Size = new Size(Board.BOARD_SIZE, Board.BOARD_SIZE);

            // Creación del CañaThrower
            CañaThrower = new CañaThrower();
            CañaThrower.Dock = DockStyle.Bottom;
            CañaThrower.MinimumSize = new Size(CañaThrower.THROWER_WIDTH, 320);
            CañaThrower.MaximumSize = new Size();
            CañaThrower.Size = new Size(CañaThrower.THROWER_WIDTH, 320);
            CañaThrower.BackColor = Color.Beige;

            // Creación del TurnsInfo
            TurnsInfo = new TurnsInfo();

            InitializeComponent();

            // Establecer tamaños minimos y tamaños por defecto de los paneles contenedores.
            //this.MinimumSize = new Size(1305, 740);
            //this.Size = new Size(1305, 740);
            this.MinimumSize = new Size(1320, 740);

            panBackground.Size = new Size(panBackground.Size.Width, 700);

            panBoard.MinimumSize = new Size(panBoard.Size.Width, 700);
            panBoard.Size = new Size(panBoard.Size.Width, 700);

            // Centrar Board
            CenterControl(panBoard, Board);

            // Agregar controles.
            panBoard.Controls.Add(Board);
            panControls.Controls.Add(CañaThrower);
            panTurnsInfo.Controls.Add(TurnsInfo);

            controller = User.Session.FormsController;

            Text = Size.ToString();
        }

        private void CenterControl(Control c1, Control c2)
        {
            int x = (c1.Width / 2) - (c2.Width / 2);
            int y = (c1.Height / 2) - (c2.Height / 2);

            c2.Location = new Point(x, y);
        }

        private void UpdateTurn(bool isMyTurn)
        {
            // Actualizar el control de informacion de turno..

            // Actualizar el control de cañas

        }

        private void DelegatedUpdateTurn(bool isMyTurn)
        {
            if (this.InvokeRequired)
            {
                UpdateTurnDelegate delegado = new UpdateTurnDelegate(UpdateTurn);
                this.Invoke(delegado, isMyTurn);
            }
                
        }

        public delegate void UpdateTurnDelegate(bool isMyTurn);

        #region Eventos del juego

        // Eventos a lanzar

        public void StartGame()
        {
            controller.NotifyClient(new UserEvents.StartGameEvent());
        }

        // Eventos recibidos

        public void GameCreated(Event e)
        {
            Entidades.Game.Square[] gamePath = Transporte.Serialization.Serialize.JobjToObject<Entidades.Game.Square[]>(e.Data); ;
            Board.SetGamePath(gamePath);

            // Nueva peticion
            StartGame();
        }

        public void TurnChanged(Event e)
        {
            Entidades.Connection.User userTurn = Transporte.Serialization.Serialize.JobjToObject<Entidades.Connection.User>(e.Data);

            if (User.Session.MyUser.Name.Equals(userTurn.Name))
            {
                if (User.Session.MyUser.Number == userTurn.Number)
                {
                    DelegatedUpdateTurn(true);
                }
            }
            else
                DelegatedUpdateTurn(false);
                

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

            Text = Size.ToString();
        }

        private void PlayerGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        #endregion


    }
}
