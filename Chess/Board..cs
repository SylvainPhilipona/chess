using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Board : Form
    {
        /*********************/
        /*     Constants     */
        /*********************/
        private const int CASES_SIZE = 50;
        private const int CASES_OFFSET = 5;



        private Button[,] board = new Button[8, 8];
        private Piece piece;


        public Board()
        {
            InitializeComponent();
        }

        private void Board_Load(object sender, EventArgs e)
        {
            // Create and dispaly the board
            InitBoard();
            DisplayBoard();
        }

        private void InitBoard()
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    // Init the button
                    Button btn = new Button();
                    btn.Size = new Size(CASES_SIZE, CASES_SIZE);
                    btn.Location = new Point(y * CASES_SIZE + CASES_OFFSET, x * CASES_SIZE + CASES_OFFSET);
                    btn.BackColor = SystemColors.Control;
                    btn.Click += new EventHandler(Case_Click);

                    board[y, x] = btn;
                }
            }
        }

        private void DisplayBoard()
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    this.Controls.Add(board[y, x]);
                }
            }
        }

        private void Case_Click(object sender, EventArgs e)
        {
            ClearBoard();
            Button btn = (Button)sender;
            int x = (btn.Location.X - CASES_OFFSET) / CASES_SIZE;
            int y = (btn.Location.Y - CASES_OFFSET) / CASES_SIZE;

            piece = new Knight(x, y);

            board[x, y].Tag = piece.Tag;
            foreach ((int x, int y) move in piece.GetPossiblesMoves(8))
            {
                board[move.x, move.y].BackColor = Color.Green;
            }
        }

        private void ClearBoard()
        {
            foreach(Button btn in board)
            {
                btn.BackColor = SystemColors.Control;
                btn.Tag = "";
            }
        }


    }
}
