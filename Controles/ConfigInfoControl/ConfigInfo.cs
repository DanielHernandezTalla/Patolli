using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controles.ConfigInfo
{
    public partial class ConfigInfo : UserControl
    {
        public ConfigInfo()
        {
            InitializeComponent();
        }

        public void ShowData(int montoInicial, int apuesta, int pieces)
        {
            txtMontoInicial.Text = montoInicial.ToString();
            txtApuesta.Text = apuesta.ToString();
            txtPieces.Text = pieces.ToString();
        }
}
}
