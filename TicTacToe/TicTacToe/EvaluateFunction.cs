using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// This class represents a static evaluation function for Tic-Tac-Toe
    /// The value is computed by summing number of game pieces in the rows, columns, and diagonals 
    /// for those rows, columns and diagonals that are still winnable
    /// </summary>
    public class EvaluationFunction
    {

        int functionCalls = 0;  // the number of function calls performed

        public EvaluationFunction()
        {
        }

        /// <summary>
        /// gets the number of times the evaluation function has been called.
        /// </summary>
        public int FunctionCalls
        {
            get { return this.functionCalls; }
        }
        /// <summary>
        /// Evaluates the favorability of the current TicTacToeGame configuration for maxPiece.  Higher values
        /// indicate better configuration for maxPiece
        /// </summary>
        /// <param name="b">the game TicTacToeGame to evaluate</param>
        /// <param name="maxPiece">the piece representing MAX</param>
        /// <returns></returns>
        public double Evaluate(TicTacToeGame b, TicTacToeGame.Pieces maxPiece)
        {
            functionCalls++;

            if (b.hasWinner())
            {
                if (b.getWinningPiece() == maxPiece)
                    return double.MaxValue;
                else
                    return double.MinValue;
            }

            double maxValue = EvaluatePiece(b, maxPiece);
            double minValue = EvaluatePiece(b, TicTacToeGame.getOpponentPiece(maxPiece));

            return maxValue - minValue;



        }

        // sums up all the possible ways to win for the specified TicTacToeGame piece
        private double EvaluatePiece(TicTacToeGame b, TicTacToeGame.Pieces p)
        {

            return EvaluateRows(b, p) + EvaluateColumns(b, p) + EvaluateDiagonals(b, p);
        }


        // over all rows sums the number of pieces in the row if 
        // the specified piece can still win in that row i.e. the row
        // does not contain an opponent's piece
        private double EvaluateRows(TicTacToeGame b, TicTacToeGame.Pieces p)
        {

            int cols = b.Columns;
            int rows = b.Rows;

            double score = 0.0;
            int count;
            // check the rows
            for (int i = 0; i < b.Rows; i++)
            {
                count = 0;
                bool rowClean = true;
                for (int j = 0; j < b.Columns; j++)
                {
                    TicTacToeGame.Pieces TicTacToeGamePiece = b.getPieceAtPoint(i, j);

                    if (TicTacToeGamePiece == p)
                        count++;
                    else if (TicTacToeGamePiece == TicTacToeGame.getOpponentPiece(p))
                    {
                        rowClean = false;
                        break;
                    }
                }

                // if we get here then the row is clean (an open row)
                if (rowClean && count != 0)
                    score += count;
            }

            return score;
        }


        // over all rows sums the number of pieces in the row if 
        // the specified piece can still win in that row i.e. the row
        // does not contain an opponent's piece
        private double EvaluateColumns(TicTacToeGame b, TicTacToeGame.Pieces p)
        {
            int cols = b.Columns;
            int rows = b.Rows;

            double score = 0.0;
            int count;
            // check the rows
            for (int j = 0; j < b.Columns; j++)
            {
                count = 0;
                bool rowClean = true;
                for (int i = 0; i < b.Columns; i++)
                {
                    TicTacToeGame.Pieces TicTacToeGamePiece = b.getPieceAtPoint(i, j);

                    if (TicTacToeGamePiece == p)
                        count++;
                    else if (TicTacToeGamePiece == TicTacToeGame.getOpponentPiece(p))
                    {
                        rowClean = false;
                        break;
                    }
                }

                // if we get here then the row is clean (an open row)
                if (rowClean && count != 0)
                    score += count; //Math.Pow(count, count);

            }

            return score;
        }


        // over both diagonals sums the number of pieces in the diagonal if 
        // the specified piece can still win in that diagonal i.e. the diagonal
        // does not contain an opponent's piece
        private double EvaluateDiagonals(TicTacToeGame b, TicTacToeGame.Pieces p)
        {
            // go down and to the right diagonal first
            int count = 0;
            bool diagonalClean = true;

            double score = 0.0;

            for (int i = 0; i < b.Columns; i++)
            {
                TicTacToeGame.Pieces TicTacToeGamePiece = b.getPieceAtPoint(i, i);

                if (TicTacToeGamePiece == p)
                    count++;

                if (TicTacToeGamePiece == TicTacToeGame.getOpponentPiece(p))
                {
                    diagonalClean = false;
                    break;
                }
            }

            if (diagonalClean && count > 0)
                score += count;// Math.Pow(count, count);

            // now try the other way

            int row = 0;
            int col = 2;
            count = 0;
            diagonalClean = true;

            while (row < b.Rows && col >= 0)
            {
                TicTacToeGame.Pieces TicTacToeGamePiece = b.getPieceAtPoint(row, col);

                if (TicTacToeGamePiece == p)
                    count++;

                if (TicTacToeGamePiece == TicTacToeGame.getOpponentPiece(p))
                {
                    diagonalClean = false;
                    break;
                }

                row++;
                col--;
            }

            if (count > 0 && diagonalClean)
                score += count;

            return score;
        }
    }
}
