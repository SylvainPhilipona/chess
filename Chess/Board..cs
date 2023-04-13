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
        
        private readonly Color DEFAULT_COLOR = SystemColors.Control;


        private PictureBox[,] board = new PictureBox[Configs.BOARD_SIZE, Configs.BOARD_SIZE];
        private PictureBox selection = null;
        private List<(int x, int y)> posssibleMoves = null;
        private List<Piece> pieces = new List<Piece>()
        {
            new Rook(0, 7, Piece.Colors.White),
            new Knight(1,7, Piece.Colors.White),
            new Bishop(2,7, Piece.Colors.White),
            new King(3,7, Piece.Colors.White),
            new Queen(4,7, Piece.Colors.White),
            new Bishop(5,7, Piece.Colors.White),
            new Knight(6,7, Piece.Colors.White),
            new Rook(7, 7, Piece.Colors.White),
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

            foreach (Piece piece in pieces)
            {
                DisplayPiece(piece.x, piece.y, piece);
            }
        }

        private void InitBoard()
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    // Init the PictureBox
                    PictureBox pib = new PictureBox();
                    pib.Size = new Size(Configs.CASES_SIZE, Configs.CASES_SIZE);
                    pib.Location = new Point(x * Configs.CASES_SIZE + Configs.CASES_OFFSET, y * Configs.CASES_SIZE + Configs.CASES_OFFSET);
                    pib.BackColor = DEFAULT_COLOR;
                    pib.BorderStyle = BorderStyle.FixedSingle;
                    pib.TabStop = false;
                    pib.Tag = "";
                    pib.Click += new EventHandler(Case_Click);
                    //pib.MouseDown += new MouseEventHandler(pictureBox1_MouseDown);
                    //pib.MouseMove += new MouseEventHandler(pictureBox1_MouseMove);
                    //pib.MouseUp += new MouseEventHandler(pictureBox1_MouseUp);


                    
                        
                        

                    board[x, y] = pib;
                }
            }
        }

        

        private void Case_Click(object sender, EventArgs e)
        {
            // Get the sender PictureBox
            PictureBox pib = (PictureBox)sender;

            /*****************************************/
            /* Hide the possibles moves by the piece */ 
            /*****************************************/

            // Check if it has a selection
            if(selection != null)
            {
                // Check if the case not have the last selected piece on it 
                if (GetPieceByCase(selection).x != -1)
                {
                    // Clear last possibles moves
                    ClearMoves(GetPieceByCase(selection).GetPossiblesMoves());
                }
            }


            /************************************************/
            /* Move the last piece selected in the new case */
            /************************************************/

            if (posssibleMoves != null)
            {
                if (posssibleMoves.Contains(GetCaseCoords(pib)))
                {
                    // Get the piece and move it
                    Piece piece = GetPieceByCase(selection);
                    (int x, int y) coords = GetCaseCoords(pib);
                    piece.Move(coords.x, coords.y);

                    selection.Text = "";
                    selection.Tag = "";
                    selection.Image = null;
                    posssibleMoves = null;

                    DisplayAllPieces();
                }
            }


            /***********************************/
            /* Display all the possibles moves */
            /***********************************/

            // Check if the case contains a piece
            if ((string)pib.Tag != "")
            {
                // Display the possibles moves
                posssibleMoves = GetPieceByCase(pib).GetPossiblesMoves();
                DisplayMoves(posssibleMoves);
            }

            selection = pib;
        }

        private Piece GetPieceByCase(PictureBox pib)
        {
            try
            {
                return pieces[pieces.FindIndex(p => p.Tag == (string)pib.Tag)];
            }
            catch
            {
                return new Piece(-1,-1, Piece.Colors.White);
            }
        }

        private (int x, int y) GetCaseCoords(PictureBox pib)
        {
            int x = (pib.Location.X - Configs.CASES_OFFSET) / Configs.CASES_SIZE;
            int y = (pib.Location.Y - Configs.CASES_OFFSET) / Configs.CASES_SIZE;

            return (x, y);
        }

        private void DisplayBoard()
        {
            foreach(PictureBox b in board)
            {
                this.Controls.Add(b);
            }
        }

        private void ClearBoard()
        {
            foreach(PictureBox pib in board)
            {
                pib.BackColor = DEFAULT_COLOR;
                pib.Tag = "";
                pib.Text = "";
            }
        }

        private void DisplayMoves(List<(int x, int y)> moves)
        {
            foreach ((int x, int y) move in moves)
            {
                board[move.x, move.y].BackColor = Color.Green;
            }
        }

        private void ClearMoves(List<(int x, int y)> moves)
        {
            foreach ((int x, int y) move in moves)
            {
                board[move.x, move.y].BackColor = DEFAULT_COLOR;
            }
        }

        private void DisplayPiece(int x, int y, Piece piece)
        {
            board[x, y].Tag = piece.Tag;
            board[x, y].Text = piece.Tag;

            switch (piece.GetType().ToString())
            {
                case "Chess.Rook":
                    board[x, y].Image = Properties.Resources.Rook;
                    break;

                case "Chess.Knight":
                    board[x, y].Image = Properties.Resources.Knight;
                    break;

                case "Chess.Bishop":
                    board[x, y].Image = Properties.Resources.Bishop;
                    break;

                case "Chess.King":
                    board[x, y].Image = Properties.Resources.King;
                    break;

                case "Chess.Queen":
                    board[x, y].Image = Properties.Resources.Queen;
                    break;
            }

        }

        private void DisplayAllPieces()
        {
            foreach (Piece piece in pieces)
            {
                DisplayPiece(piece.x, piece.y, piece);
            }
        }
















































        private void Board_MouseMove(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("sedafkljzfg");
        }

        bool isDragging;

        int currentX;
        int currentY;

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;

            currentX = e.X;
            currentY = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                pictureBox1.Top = pictureBox1.Top + (e.Y - currentY);
                pictureBox1.Left = pictureBox1.Left + (e.X - currentX);
            }


        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
