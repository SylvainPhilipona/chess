using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Piece
    {
        protected List<(int x, int y)> movements;
        protected int x;
        protected int y;

        public string Tag { get; } = "";


        public Piece(int x, int y, string tag)
        {
            this.x = x;
            this.y = y;
            this.Tag = tag;
        }

        public List<(int x, int y)> GetPossiblesMoves(int maxSize)
        {
            List<(int x, int y)> possiblesMoves = new List<(int x, int y)>();

            // Go trought all possibles moves
            foreach((int x, int y) move in movements)
            {
                // Check if the move isn't outside of the array
                if(move.x >= 0 && move.y >= 0)
                {
                    // Check if the move dosen't overflow the array
                    if(move.x <= maxSize-1 && move.y <= maxSize - 1)
                    {
                        possiblesMoves.Add(move);
                    }
                }
            }

            return possiblesMoves;
        }



    }
}
