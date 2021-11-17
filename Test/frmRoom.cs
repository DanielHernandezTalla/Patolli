using SocketsForms.Client;
using SocketsLibrary.Models;
using SocketsLibrary.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Test
{
    public partial class frmRoom : Form
    {
        public frmRoom()
        {
            InitializeComponent();
        }

        private void frmRoom_Load(object sender, EventArgs e)
        {
            if (Session.Role == Session.SessionRole.Server)
                this.Text = "RoomForm (Server)";

            txtIp.Text = Session.IP;
            txtPuerto.Text = Session.Port.ToString();
            txtNombre.Text = Session.User.Name;

            
            loadPanel();

            //var test = Session.Controller.TestRoutes();

            //MessageBox.Show(test.ToString());

            //if (!frmIpPort.IsServer)
            //{
            //    User user = (User)frmRoom.controller.AddNewUser();

            //    addUser(user);
            //}
        }

        public delegate void UpdateDelegate(User user);

        public void newUpdate(User user)
        {
            if (this.InvokeRequired)
            {
                UpdateDelegate delegado = new UpdateDelegate(addUser);
                this.Invoke(delegado, user);
            }
            else
                addUser(null);
        }


        #region Cargar Panel y Agregar Users

        private Panel pnl;
        private int Y = 10;

        private void loadPanel()
        {
            pnl = new Panel();
            pnl.SuspendLayout();
            pnl.Location = new Point(32, 32);
            pnl.Name = "pnUser";
            pnl.Size = new Size(220, 750);
            pnl.BorderStyle = BorderStyle.None;
            pnl.BackColor = Color.White;

            Label lbl = new Label();
            lbl.Location = new Point(0, 0);
            lbl.Name = "lblTitleUser";
            lbl.Size = new Size(220, 40);
            lbl.Text = "Usuarios"; 
            lbl.Font = fontBold();
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.ForeColor = Color.White;
            lbl.BackColor = Color.FromArgb(252, 75, 8);

            pnl.Controls.Add(lbl);
            pnl.ResumeLayout(false);

            this.Controls.Add(pnl);
        }

        private void addUser(User user)
        {
            Y = Y + 40;

            Label NewlblImg = new Label();
            NewlblImg.Location = new Point(10, Y);
            NewlblImg.Name = "lblImg" + Y;
            NewlblImg.Size = new Size(32, 40);
            NewlblImg.TextAlign = ContentAlignment.MiddleLeft;
            NewlblImg.BackColor = Color.Transparent;
            NewlblImg.Image = Image.FromFile("C:\\Users\\Daniel\\source\\repos\\Sockets.Client\\SocketsForms\\Source\\Images\\Icons\\user32x32.png");

            Label Newlbl = new Label();
            Newlbl.Location = new Point(50, Y);
            Newlbl.Name = "lblUser" + Y;
            Newlbl.Size = new Size(160, 40);
            Newlbl.Text = user.Name;
            Newlbl.Font = fontRegular();
            Newlbl.TextAlign = ContentAlignment.BottomLeft;
            Newlbl.ForeColor = Color.FromArgb(10, 10, 10);
            Newlbl.BackColor = Color.White;

            pnl.Controls.Add(NewlblImg);
            pnl.Controls.Add(Newlbl);
        }

        private Font fontRegular()
        {
            FontFamily fontFamily = new FontFamily("Dubai");
            Font fontRegular = new Font(
               fontFamily,
               16,
               FontStyle.Regular,
               GraphicsUnit.Pixel);

            return fontRegular;
        }

        private Font fontBold()
        {
            FontFamily fontFamily = new FontFamily("Dubai");
            Font fontBold = new Font(
               fontFamily,
               20,
               FontStyle.Bold,
               GraphicsUnit.Pixel);

            return fontBold;
        }

        #endregion

        private void frmRoom_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cerramos el server, el thread y la applicacion 
            // Form Room

            Session.ServerClient.Close();
            Session.User = null;
            Session.Controller = null;
            Session.ThreadClient = null;

            Environment.Exit(Environment.ExitCode);
        }
    }
}
