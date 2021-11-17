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
        private readonly Board Board;

        public PlayerGame()
        {
            // Creación del tablero
            Board = new Board();

            InitializeComponent();
            

            CenterControl(panBoard, Board);
            
            panBoard.Controls.Add(Board);

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
            LogicaDeNegocio.GamePathLogic.Squares.Square[] gamePath = (LogicaDeNegocio.GamePathLogic.Squares.Square[])e.Data;

            Board.SetGamePath(gamePath);
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

        private void PlayerGame_SizeChanged(object sender, EventArgs e)
        {
            CenterControl(panBoard, Board);
        }

        #endregion
    }
}
