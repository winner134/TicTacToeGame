using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class AI_Player:Player
    {

        public const int DEFAULT_SEARCH_DEPTH = 2;

      
        /// <summary>
        /// Constructs a new computer player.  The DEFAULT_SEARCH_DEPTH is used
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="p">The piece this player is using in the came</param>
        public AI_Player(string name, TicTacToeGame.Pieces p, TicTacToeGame game)
            : this(name,
            p, game, DEFAULT_SEARCH_DEPTH)
        {
        }


        /// <summary>
        /// Constructs a new computer player
        /// </summary>
        /// <param name="name">The name of the player</param>
        /// <param name="p">The piece the player is using</param>
        /// <param name="searchDepth">The depth to search for moves in the game tree.</param>
        public AI_Player(string name, TicTacToeGame.Pieces p, TicTacToeGame game, int searchDepth) :base(name, p, game)
        {
            this.searchDepth = searchDepth;
        }


        /// <summary>
        /// gets or sets the search depth which is the number of moves
        /// the computer player will look ahead to determine it's move
        /// Greater values yield better computer play
        /// </summary>
        public int searchDepth { get; set; }

        /// <summary>
        /// Start the computer searching for a move
        /// Clients should listen to the OnPlayerMoved event to be notified 
        /// when the computer has found a move
        public override void move()
        {
             //to make things interesting we move randomly if the TicTacToeGame we
             //are going first (i.e. the TicTacToeGame is empty)
            if (this.ticTacToeGame.OpenPositions.Length == 9)
            {
                currentMove = getRandomMove((TicTacToeGame)this.ticTacToeGame);
                onPlayerMoved();
                return;
            }

            Node root = new MaxNode(this.ticTacToeGame, null, null);
            root.MyPiece = this.PlayerPiece;
            root.Evaluator = new EvaluationFunction();
            root.FindBestMove(DEFAULT_SEARCH_DEPTH);

            currentMove = root.getBestMove;
            ticTacToeGame.makeMove(currentMove.Position, currentMove.Piece);
            ticTacToeGame.updateDisplay(currentMove.Position, currentMove.Piece);
            onPlayerMoved();
        }


        // gets a random move.  this can be used to make game play interesting
        // particularly in the beginning of the game or if you wish to weaken the computer's
        // play by adding randomness.
        protected TicTacToeMove getRandomMove(TicTacToeGame b)
        {
            int openPositions = b.OpenPositions.Length;
            Random rGen = new Random();

            int squareToMoveTo = rGen.Next(openPositions);

            TicTacToeMove move = new TicTacToeMove(squareToMoveTo, this.PlayerPiece);
            return move;
        }

    }
}
