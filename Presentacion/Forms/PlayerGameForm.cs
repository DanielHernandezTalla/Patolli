﻿using System;
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
using Presentacion.User;

namespace Presentacion.Forms
{
    public partial class PlayerGameForm : Form, Eventos.Game.IGameable
    {
        private readonly FormsController controller;

        private readonly Board Board;
        private readonly CañaThrower CañaThrower;

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
            CañaThrower = new CañaThrower();
            CañaThrower.MinimumSize = new Size(CañaThrower.THROWER_WIDTH, CañaThrower.THROWER_HEIGHT);
            CañaThrower.Size = new Size(CañaThrower.THROWER_WIDTH, CañaThrower.THROWER_HEIGHT);

            InitializeComponent();

            // Establecer tamaños minimos y tamaños por defecto de los paneles contenedores.
            this.MinimumSize = new Size(1320, 740);

            panBackground.Size = new Size(panBackground.Size.Width, 700);

            panBoard.MinimumSize = new Size(panBoard.Size.Width, 700);
            panBoard.Size = new Size(panBoard.Size.Width, 700);

            // Centrar Board
            CenterControl(panBoard, Board);

            // Centrar CañaThrower
            CenterControl(panControls, CañaThrower);
            CañaThrower.Location = new Point(CañaThrower.Location.X, panControls.Height - CañaThrower.Height - 30);

            // Agregar controles.
            panBoard.Controls.Add(Board);
            panControls.Controls.Add(CañaThrower);
            

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
            CañaThrower.ClearCañas();
            CañaThrower.SetEnable(isMyTurn);
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

        }

        // Eventos recibidos

        public void GameCreated(Event e)
        {
            Entidades.Game.Square[] gamePath = Transporte.Serialization.Serialize.JobjToObject<Entidades.Game.Square[]>(e.Data); ;
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

        #endregion


    }
}
