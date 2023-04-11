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
        private readonly Color DEFAULT_COLOR = SystemColors.Control;




        private Button[,] board = new Button[8, 8];
        private Button selction = null;
        private List<Piece> pieces = new List<Piece>()
        {
            new Knight(0,0),
            new Knight(3,0),
            new Knight(4,4)
        };

        public Board()
        {
            InitializeComponent();
        }

        private void Board_Load(object sender, EventArgs e)
        {
            // Create and dispaly the board
            InitBoard();
            DisplayBoard();

            foreach (Piece piece in pieces) {
                DisplayPiece(piece.x, piece.y, piece);
            }
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
                    btn.BackColor = DEFAULT_COLOR;
                    btn.Tag = "";
                    btn.Click += new EventHandler(Case_Click);

                    board[y, x] = btn;
                }
            }
        }

        

        private void Case_Click(object sender, EventArgs e)
        {
            ////////////// Clear the board
            ////////////ClearBoard();

            ////////////// Get the clicked button and get it's board indexes
            ////////////Button btn = (Button)sender;
            ////////////(int x, int y) coords = GetCaseCoords(btn);
            ////////////int x = coords.x;
            ////////////int y = coords.y;

            ////////////// Move the piece at the new coords
            ////////////piece.Move(x, y);

            ////////////// Change the case tag with the piece tag
            ////////////board[x, y].Tag = piece.Tag;
            ////////////board[x, y].Text = piece.Tag;

            ////////////// Display all possibles moves
            ////////////DisplayMoves(piece.GetPossiblesMoves(8));

            // Get the sender button
            Button btn = (Button)sender;

            // Check if it has a selection
            if (selction != null)
            {
                // Clear the old selection
                ClearMoves(GetPieceByCase(selction).GetPossiblesMoves(8));
            }


            // Check if the case contains a piece
            if ((string)btn.Tag != "")
            {
                // Display the possibles moves
                DisplayMoves(GetPieceByCase(btn).GetPossiblesMoves(8));
                selction = btn;
            }







        }

        private Piece GetPieceByCase(Button btn)
        {
            return pieces.Find(p => p.Tag == (string)btn.Tag);
        }

        







        private (int x, int y) GetCaseCoords(Button btn)
        {
            int x = (btn.Location.X - CASES_OFFSET) / CASES_SIZE;
            int y = (btn.Location.Y - CASES_OFFSET) / CASES_SIZE;

            return (x, y);
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

        private void ClearBoard()
        {
            foreach(Button btn in board)
            {
                btn.BackColor = DEFAULT_COLOR;
                btn.Tag = "";
            }
        }

        private void DisplayMoves(List<(int x, int y)> moves)
        {
            foreach ((int x, int y) move in moves)
            {
                board[move.y, move.x].BackColor = Color.Green;
            }
        }

        private void ClearMoves(List<(int x, int y)> moves)
        {
            foreach ((int x, int y) move in moves)
            {
                board[move.y, move.x].BackColor = DEFAULT_COLOR;
            }
        }

        private void DisplayPiece(int x, int y, Piece piece)
        {
            board[y, x].Tag = piece.Tag;
            board[y, x].Text = piece.Tag;
        }


    }
}
