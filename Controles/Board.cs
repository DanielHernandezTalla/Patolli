using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaDeNegocio.Elements;
using LogicaDeNegocio.GameEvents;
using LogicaDeNegocio.GamePathLogic;
using LogicaDeNegocio.GamePathLogic.Squares;
using System.Threading;

namespace Controles
{
    public partial class Board : UserControl
    {
        private Bitmap result;

        private Engine2D engine;

        // Variables para el double buffer y evitar el flicker.
        private Bitmap dbBitmap;
        private Graphics dbGraphics;

        public int BoardSize { get; private set; } = 690;


        public Board()
        {
            InitializeComponent();

            // Creamos un Bitmap y obtenemos su superficie de dibujo.
            dbBitmap = new Bitmap(this.Width, this.Height);
            dbGraphics = Graphics.FromImage(dbBitmap);

            result = new Bitmap(BoardSize, BoardSize);

            engine = new Engine2D(BoardSize, BoardSize);
        }


        public void SetGamePath(Square[] gamePath)
        {
            // Se crea una capa para dibujar el recorrido del juego.
            engine.CreateLayer("board");

            // Se crea un Sprite para cada casilla del recorrido y agrega.

            for (int i = 0; i < gamePath.Length; i++)
            {
                Bitmap image = BoardImages.GetImageSquare(gamePath[i]);

                Sprite sprite = new Sprite(
                    gamePath[i].Location.X,
                    gamePath[i].Location.Y,
                    gamePath[i].RelativeWidth,
                    gamePath[i].RelativeHeight,
                    image, 0, 0, true, true);

                engine.AddSprite(sprite);
            }

            // Se actualiza el board para que dibuje el recorrido creado.
            UpdateBoard();

            // Se pone no activa la capa "board" para que solo sea dibujada una vez.
            engine.SetActiveToLayer("board", false);

            /*Square square = new TriangleSquare(null);

            square.Location.X = 100;
            square.Location.Y = 100;
            Bitmap image = BoardImages.GetImageSquare(square);


            Sprite sprite = new Sprite(
                    square.Location.X,
                    square.Location.Y,
                    square.RelativeWidth,
                    square.RelativeHeight,
                    image, 0, 0, true, true);

            sprite.SetDelta(2,4);*/

            //-------------------
        }

        public void ClearBoard()
        {
            engine.ClearLayers();
        }

        public void AddPiece(GamePiece piece) 
        {
            if (!engine.LayerExist("pieces"))
                engine.CreateLayer("pieces");

            engine.WorkingLayer = "pieces";

            Bitmap image = null;

            Sprite pieceSprite = new Sprite(
                    piece.Location.X,
                    piece.Location.Y,
                    piece.Width,
                    piece.Height,
                    image, 0, 0, true, true);

            engine.AddSprite(pieceSprite);
        }

        public void MovePiece(PieceMovement movement) { }

        public void MovePiece(PieceMovement[] movements) { }

        public void FinishPiece(GamePiece piece) { }

        public void EliminatePiece(GamePiece piece) { }

        
        public void UpdateBoard()
        {
            engine.GameCycle();

            result = engine.Canvas;

            // Redibujamos la ventana.
            this.Invalidate();
        }

        private void Board_Paint(object sender, PaintEventArgs e)
        {
            if(result != null)
            {
                Graphics g = e.Graphics;

                // Copiamos la imagen resultado al board.
                g.DrawImage(result, new Rectangle(0, 0, BoardSize, BoardSize));

                // Liberamos el recurso.
                g.Dispose();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (engine.TESTDrawSprite())
            {
                result = engine.Canvas;

                // Redibujamos la ventana.
                this.Invalidate();
            }
            else Timer.Stop();
            
        }
    }
}
