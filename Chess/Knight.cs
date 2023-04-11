using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Knight : Piece
    {
        public Knight(int x, int y) : base (x, y, "Knight")
        {
            base.movements = new List<(int x, int y)>()
            {
                // Top
                (base.x-1,base.y-2),
                (base.x+1,base.y-2),

                // Middle top
                (base.x-2,base.y-1),
                (base.x+2,base.y-1),

                // Middle bottom
                (base.x-2,base.y+1),
                (base.x+2,base.y+1),

                // Bottom
                (base.x-1,base.y+2),
                (base.x+1,base.y+2),
            };

        }




    }
}
