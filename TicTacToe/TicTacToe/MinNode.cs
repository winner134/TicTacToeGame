using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// This class represents a MIN node in the game tree
    /// </summary>
    public class MinNode : Node
    {

        /// <summary>
        /// Constructs a MIN node
        /// </summary>
        /// <param name="b">The TicTacToeGame that this node represents</param>
        /// <param name="parent">This node's parent</param>
        /// <param name="m">The move that was made from the parent to lead to this node's TicTacToeGame</param>
        public MinNode(TicTacToeGame b, Node parent, TicTacToeMove m)
            : base(b, parent, m)
        {

        }



        // Generates the node's children.  MIN nodes have MAX children
        protected override void GenerateChildren()
        {
            int[] openPositions = TicTacToeGame.OpenPositions;

            foreach (int i in openPositions)
            {
                TicTacToeGame b = (TicTacToeGame)TicTacToeGame.Clone();
                TicTacToeMove m = new TicTacToeMove(i, myPiece);

                b.makeMove(i, myPiece);
                children.Add(new MaxNode(b, this, m));

            }

        }

        // determines if this node is a winner
        // by convention a winning node for a MIN node
        // is double.MinValue
        protected override bool IsWinningNode()
        {
            return this.value == double.MinValue;
        }

        // returns a list of the child nodes in ascending order
        // the first node in the list will be the best node for the min node
        protected override List<Node> SortChildren(List<Node> unsortedChildren)
        {
            List<Node> sortedChildren = unsortedChildren.OrderBy(n => n.Value).ToList();
            return sortedChildren;
        }

        /// <summary>
        /// evalutes the value of the node using the evaluation function
        /// </summary>
        protected override void Evaluate()
        {
            Value = evaluator.Evaluate(TicTacToeGame, TicTacToeGame.getOpponentPiece(myPiece));
        }
    }
}
