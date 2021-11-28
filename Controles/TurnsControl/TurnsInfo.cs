using Entidades.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controles.TurnsControl
{
    public partial class TurnsInfo : UserControl
    {
        private Panel[] panels;
        private Label[] labelsName;
        private Label[] labelsMoney;
        private Label[] labelsPieces;

        public TurnsInfo()
        {
            InitializeComponent();

            Clear();
        }

        private void Clear()
        {
            panels = new Panel[4];
            panels[0] = pnlJ1;
            panels[1] = pnlJ2;
            panels[2] = pnlJ3;
            panels[3] = pnlJ4;

            labelsName = new Label[4];
            labelsName[0] = txtNombre1;
            labelsName[1] = txtNombre2;
            labelsName[2] = txtNombre3;
            labelsName[3] = txtNombre4;

            labelsMoney = new Label[4];
            labelsMoney[0] = txtMoney1;
            labelsMoney[1] = txtMoney2;
            labelsMoney[2] = txtMoney3;
            labelsMoney[3] = txtMoney4;

            labelsPieces = new Label[4];
            labelsPieces[0] = txtPices1;
            labelsPieces[1] = txtPices2;
            labelsPieces[2] = txtPices3;
            labelsPieces[3] = txtPices4;

            for (int i = 0; i < 4; i++)
            {
                panels[i].Visible = false;
                labelsName[i].Text = "";
                labelsMoney[i].Text = "";
                labelsPieces[i].Text = "";
            }
        }

        public void ShowData(StatePlayer[] statePlayer)
        {
            int sizeControl = (statePlayer.Length * 125) + 32;
            this.Size = new Size(230, sizeControl);

            for (int i = 0; i < statePlayer.Length; i++)
            {
                panels[i].Visible = true;

                

                labelsName[i].Text = statePlayer[i].User.Name;
                labelsMoney[i].Text = statePlayer[i].User.Number.ToString();

                if (statePlayer[i].IsMyTurn)
                    panels[i].BackgroundImage = TurnsInfoImages.PlayerSelected;
                else
                    panels[i].BackgroundImage = TurnsInfoImages.Player;

                string txtPieces = "";
                for (int j = 0; j < statePlayer[i].Pieces.Length; j++)
                    if (statePlayer[i].Pieces[j].IsAlive)
                        txtPieces += " |";
                    else
                        txtPieces += " x";

                labelsPieces[i].Text = txtPieces;
            }
        }
    }
}
