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
    public partial class PlayerHand : Form
    {
        //testvariable used to see how well the player works 
        private Player myplayer;
        private Game currentGame;
        private TurnManager turn;
        private ImageDataHandler mycardimages;
        bool next;
        /// <summary>
        /// property for the player which this class uses, is set via overlaying scripts(Mainly the GameScript)
        /// </summary>
        public Player Pl
        {
            get { return myplayer; }
            set { myplayer = value; }
        }
        public TurnManager TurnManage
        {
            set {turn = value; }
        }
        /// <summary>
        /// Property for the game currently running
        /// </summary>
        public Game Current
        {
            set { currentGame = value; }
        }
        /// <summary>
        /// Constructor for the playerhand class
        /// </summary>
        public PlayerHand()
        {
            InitializeComponent();           
            mycardimages = new ImageDataHandler();
            
        }
        /// <summary>
        /// Function that sets up the ui of the playerhand when first summoned including adding the players name
        /// score currently active card and score to the interface.
        /// </summary>
        public void SetUpHandUI()
        {
            lblPlayerName.Text = myplayer.Name;
            lblNumOfCard.Text = myplayer.MyHand.Cards.Count.ToString();
            lblRemainingDraws.Text = myplayer.DrawsLeft.ToString();
            lblScore.Text = myplayer.MyHand.Score.ToString();
            lblVictories.Text = myplayer.Victories.ToString();
            if (myplayer.MyHand.Cards.Count > 0)
                playerCard.Image = mycardimages.CardImage( myplayer.MyHand.AktiveCard.ToString());
        }
        /// <summary>
        /// Graphical interface update, provides information about one players specific state. This is just the graphical stuff and 
        /// has no logic in it what so ever
        /// </summary>
        private void UpdateUI()
        {
            lblRemainingDraws.Text = myplayer.DrawsLeft.ToString();
            lblNumOfCard.Text = myplayer.MyHand.Cards.Count.ToString();
            lblScore.Text = myplayer.MyHand.Score.ToString();
            if (myplayer.MyHand.AktiveCard != null)
            {
                playerCard.Image = mycardimages.CardImage(myplayer.MyHand.AktiveCard.ToString());
            }
            else
                playerCard.Image = null;
        }
        /// <summary>
        /// Event for drawing a new card from the deck and placing in the players hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawCard_Click(object sender, EventArgs e)
        {
            if (myplayer.MyHand.Cards.Count < myplayer.MyHand.MaxCardsOnHand)
            {
                bool noDrawsleft = RemainingDrawsZero();
                if (!noDrawsleft)
                {
                    myplayer.DrawNewCard();
                    UpdateUI();
                }
                              
            }
            else
            {
                MessageBox.Show("You cannot carry more than 4 cards on hand", "Error");
            }
        }
        /// <summary>
        /// buttonclick event to swap cards with the dealer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSwapCard_Click(object sender, EventArgs e)
        {
            if (myplayer.MyHand.AktiveCard != null)
            {
                bool noDrawsleft = RemainingDrawsZero();
                if (!noDrawsleft)
                {
                    myplayer.SwapCardsWithDealer(currentGame.Betty);
                    turn.UpdateDealerGraphics();
                    UpdateUI();
                }
                                                
            }
            else
                MessageBox.Show("cannot swap cards with the dealer if there is no active card","Faulty input");
        }
        /// <summary>
        /// buttonclick event for discarding a card from the players hand, cannot be done when
        /// no cards are on hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiscard_Click(object sender, EventArgs e)
        {
            if (myplayer.MyHand.AktiveCard != null)
            {
                bool noDrawslef = RemainingDrawsZero();
                if (!noDrawslef)
                {
                    myplayer.DiscardCardOnHand();
                    UpdateUI();
                }
                              
            }
            else
                MessageBox.Show("cannot discard a chard when no card is set to active","faulty input");
        }
        /// <summary>
        /// buttonclick event that shows the previous card if there is more than 1 card on hand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (myplayer.MyHand.Cards.Count > 1)
            {
                next = false;
                myplayer.CardCarousel(next);
                UpdateUI();
            }
            else
                MessageBox.Show("Sorry but the hand must contain more than one card for the application to filter", "faulty input");
            

        }
        /// <summary>
        /// button click event that displays the next card in line if there is more than one card in the 
        /// on the playerhand
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (myplayer.MyHand.Cards.Count > 1)
            {
                next = true;
                myplayer.CardCarousel(next);
                UpdateUI();
            }
            else
                MessageBox.Show("Sorry but the hand must contain more than one card for the application to filter", "faulty input");
        }
        /// <summary>
        /// buttonclick for ending ones turn prematurely
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTurnOver_Click(object sender, EventArgs e)
        {
            if (myplayer.DrawsLeft > 0)
            {
                DialogResult dlg = MessageBox.Show("Are you sure you want to end your turn prematurely", "End turn", MessageBoxButtons.YesNo);
                if (dlg == DialogResult.Yes)
                {
                    myplayer.Turn = false;
                    turn.StartTurnSwitcher();
                }

            }
             else
            {
                myplayer.Turn = false;
                turn.StartTurnSwitcher();
            }
        }
        /// <summary>
        /// This method is called each time a player does something relating to their hand and the game(reshuffling of deck not included)
        /// if the draws remainging equals zero the games switch turn function is called.
        /// </summary>
        private bool RemainingDrawsZero()
        {
            if (myplayer.DrawsLeft == 0)
            {
                myplayer.Turn = false;
                turn.StartTurnSwitcher();
                return true;               
            }
            else
                return false;
        }
    }
}
