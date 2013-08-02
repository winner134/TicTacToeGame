using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// This class represents a Node in the search Tree.
    /// Each Node contains a particular TicTacToeGame configuration.  Nodes 0 or more children
    /// that represent subsequent moves from that Node's TicTacToeGame.  
    /// 
    /// </summary>
    public abstract class Node
    {

        // this nodes children
        protected List<Node> children;

        // the value associated with the node -- this is the result of the
        // evaluatio function for leaf nodes
        protected double value;


        // The child node that represents the best move
        // for a node.
        protected Node bestMoveNode;

        // the TicTacToeGame that this node represents
        protected TicTacToeGame TicTacToeGame;

        // the evaluation function 
        protected static EvaluationFunction evaluator;


        protected TicTacToeGame.Pieces myPiece; // the piece representing the node's piece
        protected TicTacToeGame.Pieces opponentPiece; // the opponents piece

        // the move that was made from the parent node that created this node
        TicTacToeMove move;
        Node parent = null;


        /// <summary>
        /// Constructs a new Node
        /// </summary>
        /// <param name="b">The TicTacToeGame that the Node will use to evaluate itself and generate its children</param>
        /// <param name="parent">The parent of this node</param>
        /// <param name="move">The move from the parent's TicTacToeGame that generated this node's TicTacToeGame</param>
        public Node(TicTacToeGame b, Node parent, TicTacToeMove move)
        {
            this.TicTacToeGame = b;
            this.parent = parent;
            this.move = move;
            if (parent != null)
                myPiece = TicTacToeGame.getOpponentPiece(parent.MyPiece);
            children = new List<Node>();
        }


        /// <summary>
        /// The game piece that this node 'has' 
        /// </summary>
        public TicTacToeGame.Pieces MyPiece
        {
            get { return myPiece; }
            set
            {
                myPiece = value;
                opponentPiece = TicTacToeGame.getOpponentPiece(value);
            }
        }


        /// <summary>
        /// sets the evaluation function used by this node to calculate
        /// its value
        /// </summary>
        public EvaluationFunction Evaluator
        {
            set { evaluator = value; }
        }



        /// <summary>
        /// The value of this node either computed by the evaluation function
        /// or the value selected from among child nodes,
        /// </summary>
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }



        protected abstract void Evaluate();

        /// <summary>
        /// Selects the best move node for the node
        /// </summary>
        public void SelectBestMove()
        {
            // if no children there is no best move for the node
            if (children.Count == 0)
            {
                bestMoveNode = null;
                return;
            }


            // sort the children so that the first element contains the 'best' node
            List<Node> sortedChildren = SortChildren(this.children);

            this.bestMoveNode = sortedChildren[0];
            Value = bestMoveNode.Value;
        }


        /// <summary>
        /// Finds the best move for the node by doing a pseudo-depth-f
        /// </summary>
        /// <param name="depth">The depth to search</param>
        public virtual void FindBestMove(int depth)
        {
            if (depth > 0)
            {
                // expand this node -- subclasses provide their own implementation of this
                GenerateChildren();

                // evaluate each child
                // if there is a winner there is no need to go further down
                // the tree
                // sends the Evaluate() message to each child node, which is implemented
                // by subclasses
                EvaluateChildren();

                // check for a winner
                bool haveWinningChild = children.Exists(c => c.IsGameEndingNode());

                if (haveWinningChild)
                {
                    // the best move depends on the subclass
                    SelectBestMove();
                    return;
                }
                else
                {
                    foreach (Node child in children)
                    {
                        child.FindBestMove(depth - 1);
                    }
                    SelectBestMove();
                }
            }

        }


        /// <summary>
        /// Generate the nodes children
        /// </summary>
        protected abstract void GenerateChildren();

        /// <summary>
        /// Checks to see if the node is either a winner or MAX or MIN
        /// </summary>
        /// <returns>true if either 'X' or 'O'</returns>
        public virtual bool IsGameEndingNode()
        {
            return Value == double.MaxValue || Value == double.MinValue;
        }


        /// <summary>
        /// The best move from this node's board configuration
        /// </summary>
        public TicTacToeMove getBestMove
        {
            get { return this.bestMoveNode.move; }
        }


        // evaluate the child nodes
        protected void EvaluateChildren()
        {
            foreach (Node child in this.children)
            {
                child.Evaluate();
            }
        }


        protected abstract List<Node> SortChildren(List<Node> unsortedChildren);

        // does the node's configuration represent a winner
        // for the node in question
        protected abstract bool IsWinningNode();


    }
}
