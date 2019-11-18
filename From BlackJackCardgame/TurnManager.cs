using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameAndAIUtilities;
//By Ingeborg Asplund 2019
namespace BlackJackSimple
{
    /// <summary>
    /// This is a object that uses the gameboard and is owned by the Playerhand  which enables indirect communication
    /// between the two objects. The player hand can privately call nethods from this class which in turn triggers functions
    /// in the game board
    /// </summary>
    public class TurnManager
    {
        private GameBoard gm;
        /// <summary>
        /// property for the gameboard
        /// </summary>
        public GameBoard GameMaster
        {
            set { gm = value; }
        }
        /// <summary>
        /// called whenever the player runs out of draws or chooses to prematurely end their turn
        /// </summary>
        public void StartTurnSwitcher()
        {
            gm.SwitchCurrentTurn();
        }
        /// <summary>
        /// Calls method in the gameboard object that update the graphics for the dealer.
        /// This makes communiction with this object 
        /// </summary>
        public void UpdateDealerGraphics()
        {
            gm.UpdateGameBoard();
        }
        
    }
}
