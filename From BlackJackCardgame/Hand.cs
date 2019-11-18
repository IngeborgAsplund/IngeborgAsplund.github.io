using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGameUtilities;
//By Ingeborg Asplund 2018
namespace GameAndAIUtilities
{
    /// <summary>
    /// Class descriping the hand of cards a player can have including cardlimmit, actual cards on their hand and current score.
    /// I know that this class in the example on the course web serves as the main interactionpart for the player but 
    /// have choosen to let this class work more as an object subservient of the player. 
    /// </summary>
    public class Hand
    {
        List<Card> hand;//list of cards representing the cards on the players hand
        int score;//depending on how many and which cards the player has on her/his hand
        int maxCardsOnHand;// this many cards are allowed to exist in the hand if hand is full one has to be swapped or discarded
        Card activeCard;//the currently selected card
        //***************************************************************************
        //properties
        /// <summary>
        ///  property for the score used to check if it is over the value of 21 since in the event any playerhand
        /// get over that score of 21 ends the game. It is also used to reset the score of the hand in case the players
        /// want to replay after a match is over
        /// </summary>
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        /// <summary>
        /// Property used to get the information about the cards on a specific player hand, this can be used to add
        /// remove and swap cards with the hand.
        /// </summary>
        public List<Card> Cards
        {
            get { return hand; }
        }
        /// <summary>
        /// property that returns the max amount of cards on hand 
        /// </summary>
        public int MaxCardsOnHand
        {
            get { return maxCardsOnHand; }
        }
        /// <summary>
        /// property that sets and gets the currently active card
        /// </summary>
        public Card AktiveCard
        {
            get { return activeCard; }
            set { activeCard = value; }
        }
        /// <summary>
        /// Constructor setting up the needed for the player hand
        /// </summary>
        public Hand()
        {
            hand = new List<Card>();
            score = 0;
            maxCardsOnHand = 4;
            activeCard = null;            
        }
        //**************************************************************************
        //Methods
        /// <summary>
        /// Called everytime an interaction with the playerhand have been performed it calculates the current score for 
        /// the hand so that the game when checking each players hand between each round can see if the game should end or not
        /// </summary>
        public void UpdateScore()
        {
            int scores = 0;
            foreach(Card c in hand)
            {
                scores = scores + c.Score();
            }
            Score = scores;
        }
    }
}
