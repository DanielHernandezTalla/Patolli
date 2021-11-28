using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Events
{
    public struct Event
    {
        public string EventType { get; set; }
        public string Description { get; set; }
        public object Data { get; set; }
        public bool ToGame { get; set; }

        public object Sender { get; set; }

        public void Fill(Eventos.Event e)
        {
            EventType = e.EventType;
            Description = e.Description;
            ToGame = e.ToGame;

            //  La Data se llenara dependiendo de su tipo.
            if (e.Data is GameRun.GamePathLogic.Squares.Square[] squares)
            {
                Game.Square[] entitySqueares = new Game.Square[squares.Length];

                for (int i = 0; i < squares.Length; i++)
                    entitySqueares[i].Fill(squares[i]);

                Data = entitySqueares;
            }

            else if (e.Data is GameRun.Elements.Player player)
            {
                Connection.User user = new Connection.User();
                user.Fill(player);

                Data = user;
            }

            else if (e.Data is GameRun.Elements.GamePiece piece)
            {
                Game.Piece entityPiece = new Game.Piece();
                entityPiece.Fill(piece);

                Data = entityPiece;
            }

            else
                Data = e.Data;
        }

        public Eventos.Event MakeCopy()
        {
            Eventos.Event e = new Eventos.Event(EventType)
            {
                Description = this.Description,
                Data = this.Data,
                ToGame = this.ToGame
            };

            return e;
        }
    }
}
