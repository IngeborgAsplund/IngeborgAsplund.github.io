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
//By Ingeborg Asplund 2018-2019
namespace BlackJackSimple
{
    public partial class GameBoard : Form
    {
        //private Deck deck;// testvariable this will be instanciated by other classes so this is merly to see if the deck generation works
        Game ongoing;
        TurnManager trn;
        SaveLoadManager saver;
        ImageDataHandler cardImg;     
        PlayerHand currentPlayer;
        SavedGames loadForm;
        Settings mysettings;
        /// <summary>
        /// Property for the game class 
        /// </summary>
        public Game game
        {
            get { return ongoing; }
            set { ongoing = value; }
        }        
        /// <summary>
        /// constructor for the gameboard class  initializes the components needed for the class in question to work
        /// </summary>
        public GameBoard()
        {
            InitializeComponent();
            btnReplay.Enabled = false;
            btnSaveGame.Enabled = false;
            cardImg = new ImageDataHandler();
            trn = new TurnManager();
            saver = new SaveLoadManager();
            trn.GameMaster = this;
        }
        /// <summary>
        /// Method that activates a new turn each time a new turn is triggered by the game object as well as in the beginning of a new game or replay
        /// </summary>
        private void ActivateNewTurn()
        {
            game.Betty.DealersTurn();
            UpdateGameBoard();
            currentPlayer = new PlayerHand();
            currentPlayer.Current = ongoing;
            currentPlayer.TurnManage = trn;
            currentPlayer.Pl = ongoing.ActivePlayer;
            currentPlayer.SetUpHandUI();
            currentPlayer.Show();
        }
        /// <summary>
        /// Method that calls the turn switching method of the underlaying class game
        /// </summary>
        public void SwitchCurrentTurn()
        {
            ongoing.CheckWinningConditions();
            Player win = ongoing.Winner();
            if(win!=null)
            {
                string name = win.Name;
                string score = win.MyHand.Score.ToString();
                int victories = win.Victories + 1;
                win.Victories = victories;
                MessageBox.Show(name +" has won the game of blackjack with a score of"+score,"Winner");
                EndGame();
            }
            else
            {
                if(ongoing.Betty.Winner ==true)
                {
                    MessageBox.Show("Game over nobody suceeded to get over the points of the dealer","Game over");
                    EndGame();
                }
                else
                {
                    ongoing.SwitchTurn();
                    currentPlayer.Close();
                    ActivateNewTurn();
                }                    
            }
                     
        }
        /// <summary>
        /// Click event for starting a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStartGame_Click(object sender, EventArgs e)
        {
            mysettings = new Settings(this);
            DialogResult dlg = mysettings.ShowDialog();
            if(dlg == DialogResult.OK)
            {                
                ongoing.StartGame();
                ActivateNewTurn();
                BtnStartGame.Enabled = false;
                btnReplay.Enabled = false;
                btnSaveGame.Enabled = false;
            }
        }
        /// <summary>
        /// click event for schuffle the deck.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReshuffle_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure you want to reshuffle the deck", "Reshuffle",MessageBoxButtons.YesNo);
            if(dlg == DialogResult.Yes)
            {
                ongoing.CurrentDeck.Shuffle();
            }
        }
        /// <summary>
        /// click event for restarting the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReplay_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you sure you want to replay", "Replay", MessageBoxButtons.YesNo);
            if(dlg == DialogResult.Yes)
            {
                ongoing.StartGame();
                ActivateNewTurn();
            }
        }
        /// <summary>
        /// Method to update the graphical interface of the gameboard
        /// </summary>
        public void UpdateGameBoard()
        {
            DealerCard.Image = cardImg.CardImage(game.Betty.DealCard.ToString());
            lbldealerScore.Text = game.Betty.DealScore.ToString();
        }
        /// <summary>
        /// This function reset the interface after a game has ended it also calls subservient methods that reset dealer and 
        /// player hands but not the general information about the players since this will not be reset util one chooses to start a
        /// new game.
        /// </summary>
        private void EndGame()
        {
            //reset buttons
            btnReplay.Enabled = true;
            BtnStartGame.Enabled = true;
            btnSaveGame.Enabled = true;
            currentPlayer.Close();
            //reset dealer hand
            game.Betty.ResetDealer();
            game.ResetGame();
            //resetplayers
            lbldealerScore.Text = string.Empty;
            DealerCard.Image = new Bitmap(Properties.Resources.jb);
        }
        /// <summary>
        /// Button to save the game that was just finished, it is only possible to choose this option after followed through a game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveGame_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Do you want to save the data of this current game? This will make it possible to return later and play with the same profiles and size och deck", "Save", MessageBoxButtons.YesNo);
            if(dlg == DialogResult.Yes)
            {
                saver.SaveGame(ongoing);
            }
        }
        /// <summary>
        /// button click for opening an old save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenOldSave_Click(object sender, EventArgs e)
        {
            string toload;
            loadForm = new SavedGames();
            loadForm.SavesList.Items.AddRange(saver.Saves.ToArray());
            DialogResult dlg = loadForm.ShowDialog();
            if(dlg == DialogResult.OK)
            {
                toload = loadForm.SavesList.SelectedItem.ToString();
                ongoing = saver.LoadedSave(toload);
                ongoing.StartGame();
                ActivateNewTurn();
                BtnStartGame.Enabled = false;
                btnReplay.Enabled = false;
                btnSaveGame.Enabled = false;
            }
        }
        /// <summary>
        /// Shows an information box telling the user how to play 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHowToPlay_Click(object sender, EventArgs e)
        {
            HowToPlay toplay = new HowToPlay();
            toplay.Show();
        }
    }
}
