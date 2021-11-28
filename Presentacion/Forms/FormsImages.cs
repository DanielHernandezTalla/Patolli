using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Forms
{
    class FormsImages
    {
        private static string Path
        {
            get
            {
                return "..\\..\\resources\\player_game\\";
            }
        }

        internal static Bitmap DefaultBackground
        {
            get
            {
                string fullPath = Path + "FondoJuego.jpg";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }
    }
}
