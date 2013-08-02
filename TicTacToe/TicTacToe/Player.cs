using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{

    // This delegate is used to respond to moves by a player
    public delegate void PlayerMoveEventHandler(object sender, PlayerMoveEventArgs args);

    public abstract class Player
    {
        public const int X_TURN = 1;
        public const int Y_TURN = 2;
        protected TicTacToeGame ticTacToeGame;
        protected TicTacToeMove currentMove;
        //Listen for a move made by a player
        public event PlayerMoveEventHandler playerMove;

        public Player(string name, TicTacToeGame.Pieces p, TicTacToeGame game)
        {
            this.Name = name;
            this.PlayerPiece = p;
            this.ticTacToeGame = game;
        }

        public abstract void move();


        /// <summary>
        /// This is invoked by subclasses to indicate that the player decided on a move
        /// </summary>
        public virtual void onPlayerMoved()
        {
            if (playerMove != null)
                playerMove(this, new PlayerMoveEventArgs(currentMove, this));
        }

        /// <summary>
        /// Get or Set the player's piece
        /// </summary>
        public TicTacToeGame.Pieces PlayerPiece { get; set; }

        /// <summary>
        /// Get or set the player's name
        /// </summary>
        public string Name { get; set; }

        public void setCurrentMove(TicTacToeMove move)
        {
            currentMove = move;    
        }

        public TicTacToeGame getGame()
        {
            return ticTacToeGame;
        }
    }

    /// A class for encapuslating a player moved
    /// This is passed along with PlayerMoved events
    /// </summary>
    public class PlayerMoveEventArgs : System.EventArgs
    {
        protected TicTacToeMove move;
        private Player player;

        /// <summary>
        /// Constructs a new PlayerMovedArgs object with the specified Move and Player
        /// </summary>
        /// <param name="m">The move to make</param>
        /// <param name="player">The player making the move</param>
        public PlayerMoveEventArgs(TicTacToeMove m, Player player)
            : base()
        {
            this.player = player;
            this.move = m;
        }

        public TicTacToeMove Move
        {
            get { return move; }
        }

        public Player Player
        {
            get { return player; }
        }
    }
}
