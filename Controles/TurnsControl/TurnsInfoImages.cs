using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controles.TurnsControl
{
    class TurnsInfoImages
    {
        private static string Path
        {
            get
            {
                return "..\\..\\resources\\Turns\\";
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
        
        internal static Bitmap PlayerSelected
        {
            get
            {
                string fullPath = Path + "TablaJugadorSelected.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }
    }
}
