using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    /// <summary>
    /// This class represents a MAX node in the game tree.
    /// </summary>
    public class MaxNode : Node
    {


        /// <summary>
        /// Constructs a new max node
        /// </summary>
        /// <param name="b">The TicTacToeGame that this node represents</param>
        /// <param name="parent">The node's parent</param>
        /// <param name="m">The move made to create this node's TicTacToeGame</param>
        public MaxNode(TicTacToeGame b, Node parent, TicTacToeMove m)
            : base(b, parent, m)
        {
        }




        // Generate Children.  MAX Nodes have MIN children
        protected override void GenerateChildren()
        {
            // create child nodes for each of the availble positions 
            int[] openPositions = TicTacToeGame.OpenPositions;

            foreach (int i in openPositions)
            {
                TicTacToeGame b = (TicTacToeGame)TicTacToeGame.Clone();
                TicTacToeMove m = new TicTacToeMove(i, myPiece);

                b.makeMove(i, myPiece);
                children.Add(new MinNode(b, this, m));

            }
        }

        // Evaluates how favorable the TicTacToeGame configuration is for this node
        protected override void Evaluate()
        {
            this.Value = evaluator.Evaluate(this.TicTacToeGame, myPiece);
        }


        // does this node have a winning game configuration
        protected override bool IsWinningNode()
        {

            return this.Value == double.MaxValue;
        }

        // returns a List of this nodes children sorted in descending order 
        protected override List<Node> SortChildren(List<Node> unsortedChildren)
        {
            List<Node> sortedChildren = unsortedChildren.OrderByDescending(n => n.Value).ToList();
            return sortedChildren;
        }

    }
}
