using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicaDeNegocio.Actions;
using LogicaDeNegocio.Elements;

namespace LogicaDeNegocio.GamePathLogic.Squares
{
    public abstract class Square : ISquareState
    {
        #region Campos

        public const int WIDTH = 55;
        public const int HEIGHT = 40;

        #endregion

        #region Propiedades

        public string Name { get { return Type.ToString(); } }
        public Point Location { get; internal set; } = new Point();
        public bool IsOccupied { get; internal set; }
        public Point PlayerPiece { get; internal set; }

        internal Square Next { get; set; }
        internal List<IAction> Actions { get; private set; }

        public SquareType Type { get; protected set; }
        public int Width { get; protected set; } = WIDTH;
        public int Height { get; protected set; } = HEIGHT;
        public int RelativeWidth 
        { 
            get 
            {
                if(SquareDirection == CardinalDirection.North || SquareDirection == CardinalDirection.South)
                {
                    return Width;
                }
                else if (SquareDirection == CardinalDirection.East || SquareDirection == CardinalDirection.West)
                {
                    return Height;
                }

                throw new Exception("Direccion cardinal no identificada.");
            } 
        }
        public int RelativeHeight
        {
            get
            {
                if (SquareDirection == CardinalDirection.North || SquareDirection == CardinalDirection.South)
                {
                    return Height;
                }
                else if (SquareDirection == CardinalDirection.East || SquareDirection == CardinalDirection.West)
                {
                    return Width;
                }

                throw new Exception("Direccion cardinal no identificada.");
            }
        }
        

        public CardinalDirection SquareDirection { get; internal set; }

        #endregion

        public enum SquareType
        {
            Default,
            Center,
            Corner,
            Triangle,
            Goal
        }

        #region Metodos

        internal void AddAction(IAction action)
        {
            if (Actions == null)
                Actions = new List<IAction>();

            Actions.Add(action);
        }

        internal bool ExecuteActions()
        {
            ISquareState squareState = this;
            bool canMove = true;

            foreach (IAction action in Actions)
            {
                canMove = canMove && action.Execute(squareState);
            }

            return canMove;
        }

        public static void SetSquareDirections(Square[] squares, CardinalDirection direction)
        {
            for (int i = 0; i < squares.Length; i++)
            {
                squares[i].SquareDirection = direction;
            }
        }

        #endregion
    }
}
