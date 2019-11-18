using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CardGameUtilities;
using GameAndAIUtilities;

namespace BlackJackSimple
{
    public partial class Settings : Form
    {
        private GameBoard g;//reference to the gameboard
        /// <summary>
        /// Constructor that takes the argument of one gameboard(input as this)
        /// </summary>
        /// <param name="gm"></param>
        public Settings(GameBoard gm)
        {
            InitializeComponent();
            SetUp();
            g = gm;
        }
        /// <summary>
        /// function that sets which ui elements starts toggled on and off respectively
        /// </summary>
        private void SetUp()
        {
            btnAddPlayer.Enabled = false;
            txtPlayerName.Enabled = false;
            btnOK.Enabled = false;
            cmbNumOfDecks.Items.AddRange(Enum.GetNames(typeof(NumberOfDecks)));
            cmbNumOfDecks.SelectedIndex = (int)NumberOfDecks.One;
        }
        /// <summary>
        /// Unlocks the fields used for adding players to the game while locking the settings related fields
        /// </summary>
        private void UnlockPlayerAdding()
        {
            btnAddPlayer.Enabled = true;
            txtPlayerName.Enabled = true;          
            btnConfirmSettings.Enabled = false;
            txtNumOfPlayers.Enabled = false;
            txtGameName.Enabled = false;
        }
        /// <summary>
        /// Updates and clears the user interface of the settings
        /// </summary>
        private void ClearUI()
        {
            txtGameName.Text = string.Empty;
            txtNumOfPlayers.Text = string.Empty;
            txtPlayerName.Text = string.Empty;
            cmbNumOfDecks.SelectedIndex = (int)NumberOfDecks.One;
        }
        /// <summary>
        /// Buttonclick event for accepting of the initial settings for a game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirmSettings_Click(object sender, EventArgs e)
        {
            bool input = TestInput();
            if (input)
            {
                int numOfPl = int.Parse(txtNumOfPlayers.Text.Trim());
                string gamename = txtGameName.Text.Trim();
                NumberOfDecks nodecks = (NumberOfDecks)cmbNumOfDecks.SelectedIndex;
                g.game = new Game();
                g.game.CreateDeck(nodecks, gamename, numOfPl);
                UnlockPlayerAdding();
                ClearUI();
            }
            else
            {
                MessageBox.Show("The name of your new game and the number of players must be assigned before confirmation, number of players also need to be assigned with whole numbers", "Incorrect input");
                ClearUI();
            }
                
        }        
        /// <summary>
        /// Add a player to the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPlayer_Click(object sender, EventArgs e)
        {            
            bool playerNameOk = InputOK(txtPlayerName.Text);
            if (playerNameOk)
            {
                g.game.AddPlayer(txtPlayerName.Text.Trim());
                ClearUI();
            }
            else
            {
                MessageBox.Show("You must assign a name for the players before you can add the ");
            }
            CheckNumOfPlayer();
        }
        /// <summary>
        /// Method that checks if the number of players added is equal to or higher than the assigned number of players in game
        /// and if so unlocks the ok button
        /// </summary>
        private void CheckNumOfPlayer()
        {
            if (g.game.PlayersInGame >= g.game.PlayerLimit)
                btnOK.Enabled = true;
        }
        /// <summary>
        /// Main input test function
        /// </summary>
        /// <returns></returns>
        private bool TestInput()
        {
            bool gameIdOK = InputOK(txtGameName.Text.Trim());
            bool noPlOk = CanParse(txtNumOfPlayers.Text.Trim());
            return gameIdOK && noPlOk;
        }
        /// <summary>
        /// Function used to test that an input string is not empty
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private bool InputOK(string text)
        {
            if (!string.IsNullOrEmpty(text))
                return true;
            else
               return false;
        }
        /// <summary>
        /// Function that test the number of players input to see if it is parsable
        /// </summary>
        /// <param name="noPlayers"></param>
        /// <returns></returns>
        private bool CanParse(string noPlayers)
        {
            int result = 0;
            bool parsable = int.TryParse(noPlayers,out result);
            return parsable;
        }
    }
}
