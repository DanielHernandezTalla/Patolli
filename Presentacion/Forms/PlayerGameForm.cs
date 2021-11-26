using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controles;
using Eventos;
using Presentacion.Controller;

namespace Presentacion.Forms
{
    public partial class PlayerGameForm : Form, Eventos.Game.IGameable
    {
        private FormsController controller;

        private readonly Board Board;

        public PlayerGameForm()
        {
            // Creación del tablero
            Board = new Board();
            Board.MinimumSize = new Size(Board.BOARD_SIZE, Board.BOARD_SIZE);
            Board.MaximumSize = new Size(Board.BOARD_SIZE, Board.BOARD_SIZE);
            Board.Size = new Size(Board.BOARD_SIZE, Board.BOARD_SIZE);

            InitializeComponent();

            // Establecer tamaños minimos y tamaños por defecto de los paneles contenedores.
            this.MinimumSize = new Size(1305, 740);
            this.Size = new Size(1305, 740);

            panBackground.Size = new Size(panBackground.Size.Width, 700);

            panBoard.MinimumSize = new Size(panBoard.Size.Width, 700);
            panBoard.Size = new Size(panBoard.Size.Width, 700);

            // Agregar el Board y centrarlo.
            panBoard.Controls.Add(Board);
            CenterControl(panBoard, Board);

            controller = User.Session.FormsController;
        }

        private void CenterControl(Control c1, Control c2)
        {
            int x = (c1.Width / 2) - (c2.Width / 2);
            int y = (c1.Height / 2) - (c2.Height / 2);

            c2.Location = new Point(x, y);
        }

        #region Eventos del juego

        public void GameCreated(Event e)
        {
            Entidades.Game.Square[] gamePath = Transporte.Serialization.Serialize.JobjToObject<Entidades.Game.Square[]>(e.Data); ;
            Board.SetGamePath(gamePath);

        }

        public void TurnChanged(Event e)
        {
            /*LogicaDeNegocio.Elements.Player player = (LogicaDeNegocio.Elements.Player)e.Data;

            throw new NotImplementedException();*/
            throw new NotImplementedException();
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
