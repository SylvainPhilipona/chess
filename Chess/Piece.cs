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

        public int x { get; private set; }
        public int y { get; private set; }
        public string Tag { get; private set; }


        public Piece(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.Tag = GenerateID();
        }

        public List<(int x, int y)> GetPossiblesMoves(int maxSize)
        {
            List<(int x, int y)> possiblesMoves = new List<(int x, int y)>();

            // Go trought all possibles moves
            foreach((int x, int y) move in movements)
            {
                // Check if the move isn't outside of the array
                if(x + move.x >= 0 && y + move.y >= 0)
                {
                    // Check if the move dosen't overflow the array
                    if(x + move.x <= maxSize-1 && y + move.y <= maxSize - 1)
                    {
                        possiblesMoves.Add((x + move.x, y + move.y));
                    }
                }
            }

            return possiblesMoves;
        }

        public void Move(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        private string GenerateID()
        {
            // https://stackoverflow.com/questions/11313205/generate-a-unique-id
            return Guid.NewGuid().ToString("N");
        }



    }
}
