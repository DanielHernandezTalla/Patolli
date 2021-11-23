using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRun.Turns
{
    public class TurnList
    {
        private Turn start;

        private Turn currentTurn = null;

        public int Count { get; set; } = 0;

        public Turn this[int index]
        {
            get
            {
                if(Count > 0 && index >= 0 && index < Count)
                {
                    Turn current = start;
                    for (int i = 0; i < index; i++)
                    {
                        current = current.next;
                    }
                    return current;
                }
                throw new Exception("Index fuera del rango.");
            }
        }


        public void Insert(Turn turn, int index)
        {
            if (index == Count)
            {
                Add(turn);
                return;
            }
            if (index >= 0 && index < Count)
            {
                Turn current = this[index];

                turn.prior = current.prior;
                turn.next = current;
                current.prior.next = turn;
                current.prior = turn;

                if (index == 0) start = turn;

                Count++;
            }
        }

        public void Add(Turn turn)
        {
            if (start == null)
            {
                turn.next = turn;
                turn.prior = turn;
                start = turn;
            }
            else
            {
                Turn end = start.prior;
                turn.next = start;
                turn.prior = end;
                start.prior = turn;
                end.next = turn;
            }

            Count++;
        }

        public void Remove(Turn turn)
        {
            if (turn == start)
            {
                if (Count == 1)
                {
                    start = null;
                    Count--;
                    return;
                }
                start = turn.next;
            }
            turn.prior.next = turn.next;
            turn.next.prior = turn.prior;

            Count--;
        }

        public void RemoveAll(Predicate<Turn> match)
        {
            Turn current = start;
            for (int i = 0; i < Count; i++)
            {
                if (match(current))
                {
                    current = current.prior;
                    Remove(this[i]);
                    i--;
                }

                current = current.next;
            }
        }

        public bool Exists(Predicate<Turn> match)
        {
            Turn current = start;
            for (int i = 0; i < Count; i++)
            {
                if (match(current)) return true;

                current = current.next;
            }
            return false;
        }

        internal void NextTurn()
        {
            if(currentTurn == null)
            {
                currentTurn = start;
            }
            else
            {
                currentTurn = currentTurn.next;
            }
        }

        internal Turn GetCurrent()
        {
            return currentTurn;
        }

        

        
    }
}
