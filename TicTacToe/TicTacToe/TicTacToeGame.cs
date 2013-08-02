using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TicTacToe
{
    public class TicTacToeGame:ICloneable
    {
        private TicTacToeGUI gui;
        public enum Pieces { X, O, Empty };
        public const int NO_WINNER = 0;
        public const int X_HUMAN_WINS = 1;
        public const int O_AI_WINS = 2;
        public const int DRAW = 3;
        public const int COLUMNS = 3;
        public const int ROWS = 3;
        protected const int WINNING_LENGTH = 3;

        private int[,] board; // a two-dimensional array representing the game board

        private bool haveWinner;  // do we have a winner?

        private Pieces winningPiece;  

        // Constucts an empty board
        public TicTacToeGame()
        {
            board = new int[ROWS, COLUMNS];
            initBoard();
        }

        public void setGUI(TicTacToeGUI gui)
        {
            this.gui = gui;
        }

        // <summary>
        /// Constructs a new board from a previous game state.
        /// The game state conventions are as follows:
        /// the first index indicates the board row, the second index represents 
        /// the column.  For example, gameState[1,2] represents the 2nd row and third column
        /// of the board.
        /// 
        /// </summary>
        /// <param name="gameState">a two-dimensional array representing the game state</param>
        public TicTacToeGame(int[,] gameState) : this()
        {
            for (int i = 0; i <= gameState.GetUpperBound(0); i++)
                for (int j = 0; j <= gameState.GetUpperBound(1); j++)
                {
                    this.board[i, j] = gameState[i, j];
                }
        }

        
        //set all squares on the board to empty
        private void initBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    board[i, j] = (int)Pieces.Empty;

        }

        public int[,] getBoard()
        {
            return board;
        }

        /// <summary>
        /// Returns the winner's piece (an 'X' or an 'O')
        /// </summary>
        public Pieces getWinningPiece()
        {
           return winningPiece;
        }

        /// Returns the winner's piece (an 'X' or an 'O')
        /// </summary>
        public void setWinningPiece(Pieces wp)
        {
            this.winningPiece = wp;
        }

        /// <summary>
        /// Returns the number of rows in the game board
        /// </summary>
        public int Rows
        {
            get { return ROWS; }

        }


        /// <summary>
        /// Returns the number of columns in the game board
        /// </summary>
        public int Columns
        {
            get { return COLUMNS; }
        }

        /// <summary>
        /// Returns true if the position is on the board and currently not occupied by 
        /// an 'X' or an 'O'.  Position 0 is the upper-left most square and increases row-by-row
        /// so that first square in the second row is position 3 and position and position 8
        /// is the 3rd square in the 3rd row
        /// 
        /// 0 1 2 
        /// 3 4 5
        /// 6 7 8
        /// 
        /// </summary>
        public bool isValidSquare(int position)
        {
            Point p = getPoint(position);

            if (p.X >= 0 && p.X < ROWS && p.Y >= 0 && p.Y < COLUMNS && isPositionOpen(p.X, p.Y))
                return true;

            return false;
        }

        // maps a board position number to a point containing 
        // the row in the x value and the column in the y value
        private Point getPoint(int position)
        {
            Point p = new Point();

            p.X = position / COLUMNS;
            p.Y = position % ROWS;

            return p;
        }

        // returns the position number given the row and colum
        // p.X is the row
        // p.Y is the column
        private int getPositionFromPoint(Point p)
        {
            return p.X * COLUMNS + p.Y;
        }

        // is the position available
        private bool isPositionOpen(int row, int col)
        {
            return board[row, col] == (int)Pieces.Empty;
        }

        private int getBoardPiece(int position)
        {
            Point p = getPoint(position);

            return board[p.X, p.Y];
        }

        // checks to see if the row and column are on the board
        // p.X is the row, p.Y is the column
        private bool isPointInBounds(Point p)
        {
            if (p.X < 0 || p.X >= ROWS|| p.Y < 0 || p.Y >= COLUMNS)
                return false;

            return true;
        }

        // checks for a winner in the diagonal starting from 
        // the bottom-left corner of the board to the upper-right corner
        private bool isWinnerDiagonallyToRightUp(int position)
        {

            Point p = getPoint(position);
            if (isPositionOpen(p.X, p.Y))
                return false;

            Pieces piece = getPieceAtPosition(position);

            Point last = getPoint(position);
            for (int i = 1; i < WINNING_LENGTH; i++)
            {
                last.X -= 1;
                last.Y += 1;

                if (!isPointInBounds(last))
                    return false;

                if (piece != getPieceAtPosition(getPositionFromPoint(last)))
                    return false;

            }
            return true;

        }

        public int[] OpenPositions
        {
            get
            {
                List<int> positions = new List<int>();
                for (int i = 0; i < board.Length; i++)
                {
                    Point p = getPoint(i);
                    if (isPositionOpen(p.X, p.Y))
                    {
                        positions.Add(i);
                    }
                }

                return positions.ToArray();
            }
        }

        /// <summary>
        /// Returns the piece at the given board position
        /// </summary>
        /// <returns>The piece at the position</returns>
        public Pieces getPieceAtPosition(int position)
        {
            Point p = getPoint(position);

            if (isPositionOpen(p.X, p.Y))
                return Pieces.Empty;

            if (getBoardPiece(position) == (int)Pieces.X)
                return Pieces.X;
            else
                return Pieces.O;
        }

        /// <summary>
        /// Returns the piece representing the opponent
        /// </summary>
        /// <param name="yourPiece">The piece representing the player</param>
        /// <returns></returns>
        public static TicTacToeGame.Pieces getOpponentPiece(TicTacToeGame.Pieces yourPiece)
        {
            if (yourPiece == TicTacToeGame.Pieces.X)
                return TicTacToeGame.Pieces.O;
            else if (yourPiece == TicTacToeGame.Pieces.O)
                return TicTacToeGame.Pieces.X;
            else
                throw new Exception("Invalid Piece!");
        }

        /// <summary>
        /// Retries the Piece at the corresponding row and column on the board
        /// </summary>
        /// <param name="row">The row on the board (0-2)</param>
        /// <param name="column">The column (0-2)</param>
        /// <returns></returns>
        public Pieces getPieceAtPoint(int row, int column)
        {
            return getPieceAtPosition(getPositionFromPoint(new Point(row, column)));
        }

        // checks for a winner diagonally from the specified position
        // to the right
        private bool isWinnerDiagonallyToRightDown(int position)
        {
            Point p = getPoint(position);

            if (isPositionOpen(p.X, p.Y))
                return false;


            Pieces piece = getPieceAtPosition(position);

            // keep moving diagonally until we reach the winningLength
            // or we don't see the same piece
            Point last = getPoint(position);
            for (int i = 1; i < WINNING_LENGTH; i++)
            {
                last.X += 1;
                last.Y += 1;
                if (!isPointInBounds(last))
                    return false;

                if (piece != getPieceAtPosition(getPositionFromPoint(last)))
                    return false;

            }

            return true;
        }

        

        // checks for winner from top to bottom starting the the 
        // specified position
        private bool isWinnerFromTopToBottom(int position)
        {
            Point p = getPoint(position);

            // check if we even have a square here
            if (isPositionOpen(p.X, p.Y))
                return false;

            // do we have the room to go down from here?
            if (p.X + WINNING_LENGTH - 1 >= ROWS)
                return false;

            Pieces piece = getPieceAtPosition(position);

            // if we get here then we know we at least have
            // the potential for a winner from top to bottom
            for (int i = 1; i < WINNING_LENGTH; i++)
            {
                if (piece != getPieceAtPosition(position + 3 * i))
                    return false;

            }

            return true;
        }

        // checks for a winner from the specified position to the right
        private bool isWinnerToTheRight(int position)
        {
            Point p = getPoint(position);

            // check if we even the square is occupied
            // if it's not then we don't have a winner 
            // starting here
            if (isPositionOpen(p.X, p.Y))
                return false;

            // check if we have room to the right?
            if (p.Y + WINNING_LENGTH - 1 >= COLUMNS)
                return false;

            Pieces piece = getPieceAtPosition(position);

            for (int i = 1; i < WINNING_LENGTH; i++)
            {
                if (getPieceAtPosition(position + i) != piece)
                    return false;
            }
            return true;
        }

        // helper method for checking for a winner
        private bool isWinnerAt(int position)
        {
            // check each position for winner to the right
            if (isWinnerToTheRight(position) || isWinnerFromTopToBottom(position)
                || isWinnerDiagonallyToRightUp(position) || isWinnerDiagonallyToRightDown(position))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks the board configuration to see if it is currently a draw.
        /// A draw occurs when all the positions are full and there isn't a winner.
        /// </summary>
        /// <returns>returns true if there is a draw and false otherwise</returns>
        public bool isDraw()
        {

            if (hasWinner())
                return false;

            for (int i = 0; i < board.Length; i++)
            {
                Point p = getPoint(i);
                if (isPositionOpen(p.X, p.Y))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Checks the board to see if there is a winner
        /// </summary>
        /// <returns>True if there is a winner or false otherwise</returns>
        public bool hasWinner()
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (isWinnerAt(i))
                {
                    haveWinner = true;
                    setWinnerAtPosition(i);
                    return true;
                }
            }

            return false;
        }

        // gets the internal representation of the
        // piece
        private int getPieceNumber(Pieces p)
        {
            if (p == Pieces.O)
                return (int)Pieces.O;
            else
                return (int)Pieces.X;
        }

        /// <summary>
        /// Make a move on the board
        /// </summary>
        /// <param name="position">the board position to take</param>
        /// <param name="piece"></param>
        public void makeMove(int position, Pieces piece)
        {


            if (!isValidSquare(position))
                throw new InvalidMoveException();

            int pieceNumber = getPieceNumber(piece);

            Point point = getPoint(position);

            board[point.X, point.Y] = pieceNumber;
        }

        public void updateDisplay(int position, TicTacToeGame.Pieces piece)
        {
            gui.updateDisplay(position, piece);
        }


        private void setWinnerAtPosition(int position)
        {
            // get the piece at i
            winningPiece = getPieceAtPosition(position);
        }

        #region ICloneable Members

        public object Clone()
        {
            TicTacToeGame ticTacToe = new TicTacToeGame(this.board);
            return ticTacToe;

        }

        #endregion

    }

    /// <summary>
    /// An Exception representing an invalid move
    /// </summary>
    public class InvalidMoveException : Exception
    {
        public InvalidMoveException()
            : base()
        {
        }

        public InvalidMoveException(string msg)
            : base(msg)
        {
        }
    }
}
