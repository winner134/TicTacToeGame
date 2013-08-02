using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class HumanPlayer:Player
    {

        protected TicTacToeGUI ticTacToeForm;

        public HumanPlayer(string name, TicTacToeGame.Pieces p, TicTacToeGame game, TicTacToeGUI tttf)
            : base(name, p, game)
        {
            this.ticTacToeForm = tttf;
        }


        /// <summary>
        /// Make a move.  Waits for the player to double click a square 
        /// and then triggers the PlayerMoved Event
        /// </summary>
        /// <param name="gameBoard"></param>
        public override void move()
        {
            // raise the PlayerMovedEvent
            ticTacToeGame.makeMove(currentMove.Position, currentMove.Piece);
            ticTacToeGame.updateDisplay(currentMove.Position, currentMove.Piece);
            onPlayerMoved();
        }


    }
}
