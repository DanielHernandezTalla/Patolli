using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Controles.CañaThrowerControl
{
    struct CañaThrowerImages
    {
        private static string Path
        {
            get
            {
                return "..\\..\\resources\\caña_thrower\\";
            }
        }

        internal static Bitmap CañaA
        {
            get
            {
                string fullPath = Path + "Caña100x200.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }

        internal static Bitmap CañaB
        {
            get
            {
                string fullPath = Path + "Cañab100x200.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }

        internal static Bitmap Background
        {
            get
            {
                string fullPath = Path + "TablaCaña.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }

        internal static Bitmap Button
        {
            get
            {
                string fullPath = Path + "BotonNormal.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }

        internal static Bitmap ButtonBrillo
        {
            get
            {
                string fullPath = Path + "BotonBrillo.png";
                return (Bitmap)Image.FromFile(fullPath);
            }
        }
    }
}
