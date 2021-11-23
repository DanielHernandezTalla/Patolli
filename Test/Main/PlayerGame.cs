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
using LogicaDeNegocio.GameEvents;

namespace Test.Main
{
    public partial class PlayerGame : Form, IGameEvents
    {
        private Board Board;

        public PlayerGame()
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

            panBackground.Size = new Size(panBackground.Size.Width , 700);

            panBoard.MinimumSize = new Size(panBoard.Size.Width, 700);
            panBoard.Size = new Size(panBoard.Size.Width, 700);

            // Agregar el Board y centrarlo.
            panBoard.Controls.Add(Board);
            CenterControl(panBoard, Board);
        }

        private void CenterControl(Control c1, Control c2)
        {
            int x = (c1.Width / 2) - (c2.Width / 2);
            int y = (c1.Height / 2) - (c2.Height / 2);

            c2.Location = new Point(x, y);
        }

        #region Eventos del juego

        public void GameCreated(GameCreatedEvent e)
        {
            GameRun.GamePathLogic.Squares.SerializableSquare[] gamePath = (GameRun.GamePathLogic.Squares.SerializableSquare[])e.Data;

            Board.SetGamePath(gamePath);

            Text += ", " + Board.Size.ToString();
        }

        public void TurnChanged(TurnChangedEvent e)
        {
            LogicaDeNegocio.Elements.Player player = (LogicaDeNegocio.Elements.Player)e.Data;

            throw new NotImplementedException();
        }

        public void PieceMoved(PieceMovedEvent e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Eventos del form

        private void PlayerGame_Load(object sender, EventArgs e)
        {
            

            
        }

        private void PlayerGame_SizeChanged(object sender, EventArgs e)
        {
            if(Board != null)
                CenterControl(panBoard, Board);
        }

        private void PlayerGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        #endregion


    }
}
