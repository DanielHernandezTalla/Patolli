using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameRun.Elements;

namespace Controles
{
    class ImageEditor
    {
        public static Bitmap RotateFlip(Bitmap image, CardinalDirection rotate, bool flipX, bool flipY)
        {
            switch (rotate)
            {
                case CardinalDirection.North:
                    break;

                case CardinalDirection.East:
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;

                case CardinalDirection.South:
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;

                case CardinalDirection.West:
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
            }

            if (flipX)
            {
                if (flipY)
                    image.RotateFlip(RotateFlipType.RotateNoneFlipXY);
                else
                    image.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            else
            {
                if (flipY)
                    image.RotateFlip(RotateFlipType.RotateNoneFlipY);
            }

            return image;
        }

        /// <summary>
        /// Dibuja un imagen arriba de otra. Trabaja modificando "background".
        /// </summary>
        /// <param name="background"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Bitmap AddImages(Bitmap background, Bitmap image)
        {
            Graphics g = Graphics.FromImage(background);

            g.DrawImage(image, new System.Drawing.Point(0, 0));

            return background;

        }
    }
}
