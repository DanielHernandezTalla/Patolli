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
using LogicaDeNegocio.GamePathLogic;
using LogicaDeNegocio.Elements;

namespace Presentacion.Pruebas
{
    public partial class Test : Form
    {
        private LogicaDeNegocio.Game Game;
        private readonly Board Board;
        private readonly GameStatusObserver gameObserver;

        public Test()
        {
            InitializeComponent();

            Board = new Board();
            Board.Location = new System.Drawing.Point(5,5);
            this.Controls.Add(Board);

            gameObserver = new GameStatusObserver(this);
        }

        private void UpdateInfoTurn()
        {
            LogicaDeNegocio.Elements.Player turn = Game.GetTurn();

            
        }



        internal void GameCreated(GameCreatedEvent e)
        {
            /*GamePath gamePath = (GamePath)e.Data;

            Board.SetGamePath(gamePath);*/
        }

        internal void TurnChanged(TurnChangedEvent e)
        {
            Player player = (Player)e.Data;

            if(true)
            {

            }
            else
            {

            }

            lblInfo.Text = player.Name + "\n" + player.Color + "\nNum:" + player.PlayerNumber;
        }

        #region Eventos

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Board.ClearBoard();

            Game = new LogicaDeNegocio.Game(int.Parse(numPlayers.Value.ToString()), 2)
            {
                BladeSize = int.Parse(numBlade.Value.ToString())
            };
            Game.AddGameObserver(gameObserver);


            Game.Create();
            Game.Start();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Board.UpdateBoard();

            UpdateInfoTurn();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Game.ExecuteTurn(int.Parse(numResultado.Value.ToString()));

            if(Game.ExistPiecesToDraw())
            {
                Board.AddPiece(Game.GetGamePieceToDraw());
            }

            btnUpdate.PerformClick();
        }

        

        


        #endregion
    }
}
