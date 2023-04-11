using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Rook : Piece
    {
        public Rook(int x, int y) : base (x, y)
        {
            base.movements = new List<(int x, int y)>();
            for (int i = -Configs.BOARD_SIZE; i < Configs.BOARD_SIZE; i++)
            {
                base.movements.Add((i, 0));
                base.movements.Add((0, i));
            }
        }
    }
}
