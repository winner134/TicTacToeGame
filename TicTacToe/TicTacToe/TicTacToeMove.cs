using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeMove
    {

        // <summary>
        /// Constructs a TicTacToeMove
        /// </summary>
        /// <param name="position">The position to move to</param>
        /// <param name="piece">The piece that is moving</param>
        public TicTacToeMove(int position, TicTacToeGame.Pieces piece)
        {
            this.Position = position;
            this.Piece = piece;
        }


        /// <summary>
        /// gets or sets the position on the board
        /// </summary>
        public int Position { get; set; }


        /// <summary>
        /// Gets or sets the piece making this move
        /// </summary>
        public TicTacToeGame.Pieces Piece {get; set;}
        
    }

}
