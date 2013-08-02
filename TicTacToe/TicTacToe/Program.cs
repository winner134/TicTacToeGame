using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            TicTacToeGame game = new TicTacToeGame();
            TicTacToeGUI gui = new TicTacToeGUI();
            game.setGUI(gui);

            Player p1 = new HumanPlayer("Human", TicTacToeGame.Pieces.X, game, gui);

            // create a computer player with the default game tree search depth
            Player p2 = new AI_Player("Computer", TicTacToeGame.Pieces.O, game);

            gui.setHumanPlayer(p1);
            gui.setComputerPlayer(p2);

            Application.Run(gui);
        }
    }
}
