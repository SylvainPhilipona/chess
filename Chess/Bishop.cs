using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(int x, int y, Colors color) : base(x, y, color)
        {
            base.movements = new List<(int x, int y)>();

            for (int i = -8; i < 8; i++)
            {
                base.movements.Add((i, i));
                base.movements.Add((-i, i));
            }

        }
    }
}
