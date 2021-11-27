using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Controles
{
    class Engine2D
    {
        private List<Sprite> sprites = new List<Sprite>();

        public Bitmap Canvas { get; private set; }

        public int Width { get; private set; }
        public int Height { get; private set; }

        // Control de capas
        private List<Layer> layers = new List<Layer>();
        private int workingLayer = -1;

        public string WorkingLayer 
        {
            get
            {
                return layers[workingLayer].Name;
            }
            set
            {
                for (int i = 0; i < layers.Count; i++)
                {
                    if (layers[i].Name.Equals(value))
                        workingLayer = i;
                }
            }
        }
        public string[] Layers 
        { 
            get 
            {
                int lenght = layers.Count;
                string[] layersName = new string[lenght];

                for (int i = 0; i < lenght; i++)
                {
                    layersName[i] = layers[i].Name;
                }
                return layersName;
            } 
        }
       


        public Engine2D(int width, int height)
        {
            Width = width;
            Height = height;

            Canvas = new Bitmap(width, height);

            DrawBackground();
        }

        // Metodo temporal para pruebas y experimentacion.
        private void DrawBackground()
        {
            Bitmap background = BoardImages.Background;
            
            /*Graphics g = Graphics.FromImage(Canvas);

            g.DrawImage(background, new Point(0,0));*/
            
            
            for (int x = 0; x < Canvas.Width; x++)
            {
                for (int y = 0; y < Canvas.Height; y++)
                {
                    Canvas.SetPixel(x, y, background.GetPixel(x,y));
                }
            }
        }

        public void SetBackground(Bitmap background)
        {
            // Se añade el bitmap que contiene el fondo ¿?
        }

        public void AddSprite(Sprite sprite)
        {
            if(workingLayer != -1)
            {
                if (sprite != null)
                {
                    sprite.SetCanvas(Canvas);
                    layers[workingLayer].Sprites.Add(sprite);
                    sprites.Add(sprite);
                }
            }
            
        }

        public void ClearLayers()
        {
            layers.Clear();
            DrawBackground();
        }

        public void GameCycle()
        {
            foreach (Layer layer in layers)
            {
                if(layer.Active)
                    foreach (Sprite sprite in layer.Sprites)
                    {
                        sprite.Movement();
                        sprite.DrawSprite();
                    }
            }
        }

        public void CreateLayer(string name)
        {
            foreach (Layer layer in layers)
                if (name.Equals(layer.Name))
                    throw new Exception($"Ya existe una Capa con el nombre '{name}'.");

            Layer newLayer = new Layer(name);

            workingLayer = layers.Count;

            layers.Add(newLayer);
        }

        public void LayerIsActive(string name, bool active)
        {
            for (int i = 0; i < layers.Count; i++)
            {
                if (layers[i].Name == name)
                    layers[i].Active = active;
            }
        }

        public bool LayerExist(string name)
        {
            foreach (string layer in Layers)
                if (layer.Equals(name))
                    return true;

            return false;
        }

        private int i = 0;
        public bool TESTDrawSprite()
        {
            if (i < sprites.Count)
            {
                sprites[i].DrawSprite();
                i++;
                return true;
            }
            else
            {
                i = 0;
                return false;
            }
            
        }
    }
}
