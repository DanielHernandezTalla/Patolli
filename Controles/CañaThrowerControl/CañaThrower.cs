using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controles.CañaThrowerControl
{
    public partial class CañaThrower : UserControl
    {
        public const int THROWER_WIDTH = 240;
        public const int THROWER_HEIGHT = 410;

        CañaThrowerLogic myCaña = new CañaThrowerLogic();
        public int Result { get; private set;}
        public bool IsEnable { get; set; } = true;

        public CañaThrower()
        {
            InitializeComponent();
             
        }
        private void label1_Click_1(object sender, EventArgs e)
        {

           
            if (IsEnable)
            {
                AutoClosingMessageBox.Show("Tirando cañas...", "", 1400);
                myCaña.RollCañas();
                Result = myCaña.GetResult();
                //Image Positivo = CoñaThrower.Properties.Resources.Caña100x200;
                //Image Negativo = Properties.Resources.Cañab100x200;
                bool[] resultado = myCaña.GetCañas();
                /*pictureBox1.Image = (resultado[0]) ? Positivo : Negativo;
                pictureBox2.Image = (resultado[1]) ? Positivo : Negativo;
                pictureBox3.Image = (resultado[2]) ? Positivo : Negativo;
                pictureBox4.Image = (resultado[3]) ? Positivo : Negativo;
                pictureBox5.Image = (resultado[4]) ? Positivo : Negativo;*/

                IsEnable = false;
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
