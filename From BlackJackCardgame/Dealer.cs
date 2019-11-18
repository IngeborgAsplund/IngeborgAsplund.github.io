using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameUtilities;
//By Ingeborg Asplund 2018-2019 
namespace GameAndAIUtilities
{
    /// <summary>
    /// This class is meant to handle the dealer ai and since a dealer shall be able to do(at least after what I have read) draws similar to a player
    /// but with internal logics deciding and constraining what it can do
    /// </summary>
    public class Dealer
    {
        //Instance variables               
        private List<Card> dealerHand;
        private Card dealerCard;
        private Deck currentDeck;
        private int score;
        private int cardLimit;
        bool won;//set true if the dealer ends up in a situation where she has won the game
        //properties
        /// <summary>
        /// Get property for the active dealercard
        /// </summary>
        public Card DealCard
        {
            get { return dealerCard; }
        }
        /// <summary>
        /// Set property for the deck used in this game;
        /// </summary>
        public Deck d
        {
            set { currentDeck = value; }
        }
        /// <summary>
        /// this bool is turned true when the game class identifies a situation where the dealer has the highest score
        /// </summary>
        public bool Winner
        {
            get { return won; }
            set { won = value; }
        }
        /// <summary>
        /// Property for the current score of the dealer
        /// </summary>
        public int DealScore
        {
            get { return score; }
            set { score = value; }
        }
        /// <summary>
        /// Constructor for the dealerclass
        /// </summary>
        public Dealer()
        {
            score = 0;
            cardLimit = 3;
            dealerHand = new List<Card>();
        }
        /// <summary>
        /// When the dealer starts its turn it follows the instructions in this method to decide if it should discard
        /// a card or draw a new one, basically the dealer will always draw a new card if the cardlimit is not reached or the
        /// dealers score is close to 21(if >=18)
        /// </summary>
        public void DealersTurn()
        {
            //if we have less than 2 cards on hand
            if (dealerHand.Count < cardLimit)
            {
                //if our score is lower than or equal to 18
                if (score <= 13)
                {
                    DrawCard();                   
                }
                else
                    DiscardCard();
            }
            else
                DiscardCard();
            UpdateDealersScore();
        }
        /// <summary>
        /// This method takes a card as an argument which it places at the top of the dealerhand and 
        /// put itself as the active card
        /// </summary>
        public void ReactToSwitch(Card switched)
        {
            if (switched != null)
            {
                dealerHand.Remove(dealerCard);
                dealerHand.Add(switched);
                dealerCard = switched;
                UpdateDealersScore();
            }
            else
                throw new ArgumentNullException();
        }
        /// <summary>
        /// Method that draws cards from the deck
        /// </summary>
        private void DrawCard()
        {
            Card drawNew = currentDeck.DrawCard();
            dealerHand.Add(drawNew);
            dealerCard = drawNew;
        }
        /// <summary>
        /// Method that discard a card from the hand in case it got full and the dealer cannot draw a new one
        /// it selects the card with the lowest cardvalue to discard, this removes a high card meaning that jacks,
        /// kings queens and aces are more likely to be sorted out of the dealer hand
        /// </summary>
        private void DiscardCard()
        {
            Card disc = null;
            Card ace = null; 
            //do we have any aces in the pile of cards
            foreach (Card c in dealerHand)
            {
                if (c.CardValue == 1)
                {
                    ace = c;      //if so sort it out and break the loop            
                    break;
                }

            }
            //do we have any aces?
            if (ace == null)
            {
                //if not the card to discard is the highest of the remaining cards
                dealerHand.Sort();
                disc = dealerHand[dealerHand.Count - 1];
            }
            else
            {
                //se the discardcard is our ace
                disc = ace;
            }
            dealerHand.Remove(disc);
            dealerCard = dealerHand[dealerHand.Count - 1];
        }
        /// <summary>
        /// Updates the score for the dealer each time the dealer have done its round or someone has swapped card with her.
        /// </summary>
        private void UpdateDealersScore()
        {
            score = 0;
            foreach(Card c in dealerHand)
            {
                score = score + c.Score();
            }
        }
        /// <summary>
        /// Reset the dealer when replay is checked
        /// </summary>
        public void ResetDealer()
        {
            dealerHand.Clear();
            dealerCard = null;
            score = 0;
        }
    }
}
