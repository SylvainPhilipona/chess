using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class King : Piece
    {
        public King(int x, int y) : base (x, y)
        {
            base.movements = new List<(int x, int y)>()
            {
                // Top
                (-1,-1),
                (0,-1),
                (1,-1),

                // Middle
                (-1,0),
                (1,0),

                // Bottom
                (-1,1),
                (0,1),
                (1,1),
            };

        }
    }
}
