using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Controles
{
    public class Sprite
    {
        private Bitmap image;

        private Bitmap canvas;
        private Bitmap imageCropping;


        public int X { get; set; }
        public int Y { get; set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        // Propiedades para controlar animaciones
        public int Frames { get; private set; }
        public int CurrentFrame { get; set; }
        public int Animations { get; private set; }
        public int CurrentAnimation { get; set; }

        public bool Active { get; set; }
        public bool Visible { get; set; }

        // Movimiento
        public int DeltaX { get; set; }
        public int DeltaY { get; set; }

        // Cropping. Limpiar estela de dibujo
        private bool useCopy;
        private int Xcopy, Ycopy;
        private int widthCopy, heightCopy;


        public Sprite(int X, int Y, int width, int height, string image, int frames, int animations, bool active, bool visible)
        {
            this.X = X;
            this.Y = Y;
            Width = width;
            Height = height;
            Frames = frames;
            Animations = animations;
            Active = active;
            Visible = visible;

            CurrentFrame = 0;
            CurrentAnimation = 0;
        }
        public Sprite(int X, int Y, int width, int height, Bitmap image, int frames, int animations, bool active, bool visible)
        {
            this.X = X;
            this.Y = Y;
            Width = width;
            Height = height;
            this.image = image;
            Frames = frames;
            Animations = animations;
            Active = active;
            Visible = visible;

            CurrentFrame = 0;
            CurrentAnimation = 0;

            imageCropping = new Bitmap(Width, Height);
        }


        public void SetCanvas(Bitmap canvas) => this.canvas = canvas;

        public void SetImage(Bitmap image) => this.image = image;

        public void SetDelta(int dX, int dY)
        {
            DeltaX = dX;
            DeltaY = dY;
        }

        public void Movement()
        {
            X += DeltaX;
            Y += DeltaY;
        }

        public void CopyBackground()
        {
            // Si el sprite esta fuera del canvas no sera necesario el proceso de copiado.
            if ((Y + Height < 0 || Y >= canvas.Height)
                || (X + Width < 0 || X >= canvas.Width))
            {
                useCopy = false;
                return;
            }
            else
                useCopy = true;

            // Variable del rectangulo de recorte.
            int x = X;
            int y = Y;
            int limx = X + Width;
            int limy = Y + Height;

            // Verificar clipping a la izquierda
            if (X < 0)
                x = 0;

            // Verificar clipping a la derecha
            else if (X + Width >= canvas.Width)
                limx = canvas.Width;

            // Verificar clipping arriba
            if (Y < 0)
                y = 0;

            // Verificar clipping a la abajo
            else if (Y + Height >= canvas.Height)
                limy = canvas.Height;

            // Proceso de copiado del area.
            Xcopy = x;
            Ycopy = y;
            widthCopy = limx - x;
            heightCopy = limy - y;

            Graphics g = Graphics.FromImage(imageCropping);

            g.DrawImage(canvas, x, y, widthCopy, heightCopy);

        }

        public void DrawSprite()
        {
            // Si existe imagen dibujala
            if( image != null)
            {
                Graphics g = Graphics.FromImage(canvas);

                g.DrawImage(image, new Rectangle(X, Y ,image.Width, image.Height));
            } 
            else
            {
                for (int x = X; x < X + Width; x++)
                {
                    for (int y = Y; y < Y + Height; y++)
                    {
                        canvas.SetPixel(x, y, Color.Violet);
                    }
                }
            }
            
        }
    }
}
