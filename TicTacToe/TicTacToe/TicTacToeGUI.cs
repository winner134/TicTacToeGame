using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToeGUI : Form
    {
        private Player humanPlayer;
        private Player computerPlayer;

        public TicTacToeGUI()
        {
            InitializeComponent();
        }

        public void setHumanPlayer(Player p1)
        {
            humanPlayer = p1;
        }

        public void setComputerPlayer(Player p2)
        {
            computerPlayer = p2;
        }

        public void updateDisplay(int position, TicTacToeGame.Pieces piece)
        {

            if (position == 0 && piece == TicTacToeGame.Pieces.X)
                button1.Text = "X";
            if (position == 1 && piece == TicTacToeGame.Pieces.X)
                button2.Text = "X";
            if (position == 2 && piece == TicTacToeGame.Pieces.X)
                button3.Text = "X";
            if (position == 3 && piece == TicTacToeGame.Pieces.X)
                button4.Text = "X";
            if (position == 4 && piece == TicTacToeGame.Pieces.X)
                button5.Text = "X";
            if (position == 5 && piece == TicTacToeGame.Pieces.X)
                button6.Text = "X";
            if (position == 6 && piece == TicTacToeGame.Pieces.X)
                button7.Text = "X";
            if (position == 7 && piece == TicTacToeGame.Pieces.X)
                button8.Text = "X";
            if (position == 8 && piece == TicTacToeGame.Pieces.X)
                button9.Text = "X";

            if (position == 0 && piece == TicTacToeGame.Pieces.O)
                button1.Text = "O";
            if (position == 1 && piece == TicTacToeGame.Pieces.O)
                button2.Text = "O";
            if (position == 2 && piece == TicTacToeGame.Pieces.O)
                button3.Text = "O";
            if (position == 3 && piece == TicTacToeGame.Pieces.O)
                button4.Text = "O";
            if (position == 4 && piece == TicTacToeGame.Pieces.O)
                button5.Text = "O";
            if (position == 5 && piece == TicTacToeGame.Pieces.O)
                button6.Text = "O";
            if (position == 6 && piece == TicTacToeGame.Pieces.O)
                button7.Text = "O";
            if (position == 7 && piece == TicTacToeGame.Pieces.O)
                button8.Text = "O";
            if (position == 8 && piece == TicTacToeGame.Pieces.O)
                button9.Text = "O";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            humanPlayer.setCurrentMove(new TicTacToeMove(0, TicTacToeGame.Pieces.X));
            if(!humanPlayer.getGame().hasWinner())
                humanPlayer.move();
            if(computerPlayer.getGame().OpenPositions.Length !=0 && !computerPlayer.getGame().hasWinner())
                computerPlayer.move();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            humanPlayer.setCurrentMove(new TicTacToeMove(1, TicTacToeGame.Pieces.X));
            if (!humanPlayer.getGame().hasWinner())
                humanPlayer.move();
            if (computerPlayer.getGame().OpenPositions.Length != 0 && !computerPlayer.getGame().hasWinner())
                computerPlayer.move();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            humanPlayer.setCurrentMove(new TicTacToeMove(2, TicTacToeGame.Pieces.X));
            if (!humanPlayer.getGame().hasWinner())
                humanPlayer.move();
            if (computerPlayer.getGame().OpenPositions.Length != 0 && !computerPlayer.getGame().hasWinner())
                computerPlayer.move();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            humanPlayer.setCurrentMove(new TicTacToeMove(3, TicTacToeGame.Pieces.X));
            if (!humanPlayer.getGame().hasWinner())
                humanPlayer.move();
            if (computerPlayer.getGame().OpenPositions.Length != 0 && !computerPlayer.getGame().hasWinner())
                computerPlayer.move();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            humanPlayer.setCurrentMove(new TicTacToeMove(4, TicTacToeGame.Pieces.X));
            if (!humanPlayer.getGame().hasWinner())
                humanPlayer.move();
            if (computerPlayer.getGame().OpenPositions.Length != 0 && !computerPlayer.getGame().hasWinner())
                computerPlayer.move();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            humanPlayer.setCurrentMove(new TicTacToeMove(5, TicTacToeGame.Pieces.X));
            if (!humanPlayer.getGame().hasWinner())
                humanPlayer.move();
            if (computerPlayer.getGame().OpenPositions.Length != 0 && !computerPlayer.getGame().hasWinner())
                computerPlayer.move();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            humanPlayer.setCurrentMove(new TicTacToeMove(6, TicTacToeGame.Pieces.X));
            if (!humanPlayer.getGame().hasWinner())
                humanPlayer.move();
            if (computerPlayer.getGame().OpenPositions.Length != 0 && !computerPlayer.getGame().hasWinner())
                computerPlayer.move();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            humanPlayer.setCurrentMove(new TicTacToeMove(7, TicTacToeGame.Pieces.X));
            if (!humanPlayer.getGame().hasWinner())
                humanPlayer.move();
            if (computerPlayer.getGame().OpenPositions.Length != 0 && !computerPlayer.getGame().hasWinner())
                computerPlayer.move();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            humanPlayer.setCurrentMove(new TicTacToeMove(8, TicTacToeGame.Pieces.X));
            if (!humanPlayer.getGame().hasWinner())
                humanPlayer.move();
            if (computerPlayer.getGame().OpenPositions.Length != 0 && !computerPlayer.getGame().hasWinner())
                computerPlayer.move();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";
            button5.Text = "";
            button6.Text = "";
            button7.Text = "";
            button8.Text = "";
            button9.Text = "";

            TicTacToeGame game = new TicTacToeGame();
            game.setGUI(this);

            Player p1 = new HumanPlayer("Human", TicTacToeGame.Pieces.X, game, this);

            // create a computer player with the default game tree search depth
            Player p2 = new AI_Player("Computer", TicTacToeGame.Pieces.O, game);

            this.setHumanPlayer(p1);
            this.setComputerPlayer(p2);
        }
    }
}
