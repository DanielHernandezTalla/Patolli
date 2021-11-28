using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controles.CañasThrowerControl
{
    public partial class CañasThrower : UserControl
    {
        public const int THROWER_WIDTH = 180;
        public const int THROWER_HEIGHT = 140;

        CañasThrowerLogic myCaña = new CañasThrowerLogic();
        public int Result { get; private set;}
        public bool[] Cañas { get; private set; }
        public bool IsEnable { get; private set; }
        public bool CañasThrown { get; set; }

        public CañasThrower()
        {
            InitializeComponent();

            BackgroundImage = CañasThrowerImages.Background;
            BackgroundImageLayout = ImageLayout.Stretch;

            lblButton.Image = CañasThrowerImages.Button;
            lblButton.Location = new Point(lblButton.Location.X + 13, lblButton.Location.Y);

            pictureBox1.Location = new Point(17, pictureBox1.Location.Y);
            pictureBox2.Location = new Point(47, pictureBox2.Location.Y);
            pictureBox3.Location = new Point(77, pictureBox3.Location.Y);
            pictureBox4.Location = new Point(107, pictureBox4.Location.Y);
            pictureBox5.Location = new Point(137, pictureBox5.Location.Y);

            ClearCañas();
        }

        public void AddButtonListener(Action<object, EventArgs> listener)
        {
            lblButton.Click += new EventHandler(listener);
        }

        public void SetCañas(bool[] cañas)
        {
            Image Positivo = CañasThrowerImages.CañaA;
            Image Negativo = CañasThrowerImages.CañaB;

            pictureBox1.Image = (cañas[0]) ? Positivo : Negativo;
            pictureBox2.Image = (cañas[1]) ? Positivo : Negativo;
            pictureBox3.Image = (cañas[2]) ? Positivo : Negativo;
            pictureBox4.Image = (cañas[3]) ? Positivo : Negativo;
            pictureBox5.Image = (cañas[4]) ? Positivo : Negativo;
        }

        public void ClearCañas()
        {
            Image Negativo = CañasThrowerImages.CañaB;
            pictureBox1.Image = Negativo;
            pictureBox2.Image = Negativo;
            pictureBox3.Image = Negativo;
            pictureBox4.Image = Negativo;
            pictureBox5.Image = Negativo;
        }

        public void SetEnable(bool isEnable)
        {
            IsEnable = isEnable;

            if(isEnable)
            { 
                lblButton.BorderStyle = BorderStyle.Fixed3D;
                lblButton.Image = CañasThrowerImages.ButtonBrillo;
            }
            else
            {
                lblButton.BorderStyle = BorderStyle.None;
                lblButton.Image = CañasThrowerImages.Button;
            }
        }

        private void lblButton_Click_1(object sender, EventArgs e)
        {
            if (IsEnable)
            {
                AutoClosingMessageBox.Show("Tirando cañas...", "", 1400);

                myCaña.RollCañas();

                Result = myCaña.GetResult();
                Cañas = myCaña.GetCañas();

                bool[] resultado = myCaña.GetCañas();

                SetCañas(resultado);
                SetEnable(false);

                CañasThrown = true;
            }

        }

        public class AutoClosingMessageBox
        {
            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        }
    }
}
