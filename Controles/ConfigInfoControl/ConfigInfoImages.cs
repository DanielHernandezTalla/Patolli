using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles.ConfigInfo
{
    class ConfigInfoImages
    {
        private static string Path
        {
            get
            {
                return "..\\..\\resources\\config_info\\";
            }
        }

        internal static Bitmap DefaultBackground
        {
            get
            {
                string fullPath = Path + "ControladorDatosJugadorFondo200x300.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }

        internal static Bitmap Player
        {
            get
            {
                string fullPath = Path + "TablaJugador.png";
                return (Bitmap)Image.FromFile(fullPath);

            }
        }
    }
}
