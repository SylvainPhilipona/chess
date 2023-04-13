using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Knight : Piece
    {
        public Knight(int x, int y, Colors color) : base(x, y, color)
        {
            base.movements = new List<(int x, int y)>()
            {
                // Top
                (-1,-2),
                (+1,-2),

                // Middle top
                (-2,-1),
                (+2,-1),

                // Middle bottom
                (-2,+1),
                (+2,+1),

                // Bottom
                (-1,+2),
                (+1,+2),
            };

        }
    }
}
