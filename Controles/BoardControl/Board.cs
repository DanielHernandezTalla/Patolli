using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameRun.Elements;
using System.Threading;

namespace Controles.BoardControl
{
    public partial class Board : UserControl
    {
        private Bitmap result;

        private Engine2D engine;

        // Variables para el double buffer y evitar el flicker.
        private Bitmap dbBitmap;
        private Graphics dbGraphics;

        public static int BOARD_SIZE { get; private set; } = 690;


        public Board()
        {
            InitializeComponent();

            // Creamos un Bitmap y obtenemos su superficie de dibujo.
            dbBitmap = new Bitmap(this.Width, this.Height);
            dbGraphics = Graphics.FromImage(dbBitmap);

            result = new Bitmap(BOARD_SIZE, BOARD_SIZE);

            engine = new Engine2D(BOARD_SIZE, BOARD_SIZE);
        }


        public void SetGamePath(Entidades.Game.Square[] gamePath)
        {
            // Se crea una capa para dibujar el recorrido del juego.
            engine.CreateLayer("board");

            // Se crea un Sprite para cada casilla del recorrido y agrega.

            for (int i = 0; i < gamePath.Length; i++)
            {
                Bitmap image = BoardImages.GetImageSquare(gamePath[i]);

                Sprite sprite = new Sprite(
                    gamePath[i].X,
                    gamePath[i].Y,
                    gamePath[i].RelativeWidth,
                    gamePath[i].RelativeHeight,
                    image, 0, 0, true, true);

                engine.AddSprite(sprite);
            }

            // Se actualiza el board para que dibuje el recorrido creado.
            UpdateBoard();

            // Se pone no activa la capa "board" para que solo sea dibujada una vez.
            engine.LayerIsActive("board", false);

            //-------------------
        }

        public void ClearBoard()
        {
            engine.ClearLayers();
        }

        

        public void AddPiece(Entidades.Game.Piece piece) 
        {
            if (!engine.LayerExist("pieces"))
                engine.CreateLayer("pieces");

            engine.WorkingLayer = "pieces";

            Bitmap image = BoardImages.GetPiece(piece.Color);

            Sprite pieceSprite = new Sprite(
                    piece.RelativeX,
                    piece.RelativeY,
                    piece.Width,
                    piece.Height,
                    image, 0, 0, true, true);

            engine.AddSprite(pieceSprite);

            //--------------

            UpdateBoard();
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
                g.DrawImage(result, new Rectangle(0, 0, BOARD_SIZE, BOARD_SIZE));

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

        private void Board_SizeChanged(object sender, EventArgs e)
        {
            Size a = Size;

        }
    }
}
