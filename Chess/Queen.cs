using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(int x, int y, Colors color) : base(x, y, color)
        {
            base.movements = new List<(int x, int y)>();
            for (int i = -Configs.BOARD_SIZE; i < Configs.BOARD_SIZE; i++)
            {
                base.movements.Add((i, 0));
                base.movements.Add((0, i));

                base.movements.Add((i, i));
                base.movements.Add((-i, i));
            }
        }
    }
}
